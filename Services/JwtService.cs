using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Services
{
    /// <summary>
    /// Servicio para la gestión de tokens JWT
    /// </summary>
    public class JwtService(JwtAuthOptions jwtOptions,
                            ILogger<JwtService> logger) : IJwtService
    {
        private readonly JwtAuthOptions _jwtOptions = jwtOptions;
        private readonly ILogger<JwtService> _logger = logger;

        /// <summary>
        /// Genera un token de acceso JWT para el usuario
        /// </summary>
        public string GenerateAccessToken(UserInfoDto userInfo)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
                new(ClaimTypes.Name, userInfo.UserName),
                new(AuthConstants.INFRAESTRUCTURE_CLAIMS_FULLNAME, userInfo.FullName),
                new(AuthConstants.INFRAESTRUCTURE_CLAIMS_PERFILID, userInfo.PerfilId.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            var expirationMinutes = _jwtOptions.AccessTokenExpirationMinutes;
            var expiration = DateTime.UtcNow.AddMinutes(expirationMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                //audience: _jwtOptions.Audience, // Audiencia no se establece
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            _logger.LogInformation("Token JWT generado para usuario: {UserName}", Sanitizer.Sanitize(userInfo.UserName));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Genera un token de refresco aleatorio
        /// </summary>
        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);

            return Convert.ToBase64String(randomBytes);
        }

        /// <summary>
        /// Valida un token JWT y retorna las claims del usuario
        /// </summary>
        public Task<ClaimsPrincipal?> GetPrincipalFromExpiredToken(string token)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));

                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidIssuer = _jwtOptions.Issuer,
                    ValidateAudience = false,
                    // ValidAudience = _jwtOptions.Audience, // Audiencia no se valida
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

                return Task.FromResult<ClaimsPrincipal?>(principal);
            }
            catch (SecurityTokenException ex)
            {
                _logger.LogWarning(ex, "Token inválido: {Message}", ex.Message);
                return Task.FromResult<ClaimsPrincipal?>(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validando token JWT");
                return Task.FromResult<ClaimsPrincipal?>(null);
            }
        }

        /// <summary>
        /// Verifica si el usuario tiene una sesión activa válida mediante cookies HttpOnly
        /// </summary>
        /// <param name="httpContext">Contexto HTTP que contiene las cookies</param>
        /// <returns>Resultado de la verificación con información del usuario si es válida</returns>
        public async Task<SessionVerifyResult> SessionVerify(HttpContext httpContext)
        {
            var result = new SessionVerifyResult
            {
                IsValid = false,
                IsExpired = false
            };

            if (httpContext == null)
            {
                result.ErrorMessage = "Contexto HTTP no proporcionado";
                _logger.LogWarning("Intento de verificación de sesión sin contexto HTTP");
                return result;
            }

            // Extraer token de acceso desde cookie HttpOnly
            var accessToken = httpContext.Request.Cookies[AuthConstants.AUTH_COOKIE_ACCESS];

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                result.ErrorMessage = "No se encontró token de acceso en las cookies";
                _logger.LogWarning("Intento de verificación de sesión sin cookie de acceso");
                return result;
            }

            try
            {
                var principal = await GetPrincipalFromExpiredToken(accessToken);

                if (principal == null)
                {
                    result.ErrorMessage = "Token inválido o corrupto";
                    _logger.LogWarning("Token inválido en verificación de sesión");
                    return result;
                }

                // Extraer información del usuario de las claims
                var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userNameClaim = principal.FindFirst(ClaimTypes.Name)?.Value;
                var fullNameClaim = principal.FindFirst("FullName")?.Value;
                var permissionsClaim = principal.FindFirst(AuthConstants.INFRAESTRUCTURE_CLAIMS_PERMISSION)?.Value;

                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                {
                    result.ErrorMessage = "Token sin información válida del usuario";
                    _logger.LogWarning("Token sin información de usuario válida");
                    return result;
                }
    
                // Extraer permisos
                List<int>? permissions = null;
                if (!string.IsNullOrEmpty(permissionsClaim))
                {
                    permissions = permissionsClaim
                        .Split(',')
                        .Where(p => int.TryParse(p, out _))
                        .Select(int.Parse)
                        .ToList();
                }

                // Sesión válida
                result.IsValid = true;
                result.UserId = userId;
                result.UserName = userNameClaim;
                result.FullName = fullNameClaim;
                result.Permissions = permissions;

                _logger.LogInformation("Sesión verificada correctamente para usuario: {UserName}", Sanitizer.Sanitize(userNameClaim ?? ""));

                return result;
            }
            catch (SecurityTokenExpiredException ex)
            {
                result.IsExpired = true;
                result.ErrorMessage = "El token ha expirado";
                _logger.LogWarning(ex,"Token expirado en verificación de sesión");
                return result;
            }
            catch (SecurityTokenException ex)
            {
                result.ErrorMessage = $"Token inválido: {ex.Message}";
                _logger.LogWarning(ex, "Error de seguridad en verificación de sesión");
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = "Error al verificar la sesión";
                _logger.LogError(ex, "Error inesperado en verificación de sesión");
                return result;
            }
        }
    }
}