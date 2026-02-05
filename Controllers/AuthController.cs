using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Models.Responses;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Controllers
{
    /// <summary>
    /// Controlador para autenticación y manejo de tokens JWT
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController(
        IJwtService jwtService,
        ILogger<AuthController> logger,
        ApiConfiguration configuration,
        IMemoryCache memoryCache,
        IAuthService authService) : ControllerBase
    {
        private readonly IJwtService _jwtService = jwtService;
        private readonly ILogger<AuthController> _logger = logger;
        private readonly ApiConfiguration _configuration = configuration;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly IAuthService _authService = authService;

        /// <summary>
        /// Autentica un usuario y devuelve tokens de acceso y refresco
        /// </summary>
        /// <param name="request">Credenciales de login del usuario</param>
        /// <returns>Tokens JWT y información del usuario</returns>
        /// <response code="200">Login exitoso con tokens generados</response>
        /// <response code="400">Credenciales inválidas</response>
        /// <response code="401">Credenciales incorrectas</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse<LoginDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginApiRequest? request)
        {
            string _msg;

            if (request == null)
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE01_FAILED);
                _logger.LogWarning(_msg);
                return BadRequest(ApiResponseBuilder.Error<object>(
                    AuthTextConstants.AUTH_FAILED,
                    StatusCodes.Status400BadRequest,
                    null,
                    HttpContext.TraceIdentifier));
            }
            // Sanitizar y loggear intento de login
            var safeUserName = Sanitizer.Sanitize(request.UserName);
            _msg = string.Format(AuthTextConstants.AUTH_CHALLENGE, safeUserName);
            _logger.LogInformation(_msg);
            
            // Deshabilitar caché para respuestas de autenticación
            ResponseCacheHelper.DisableCache(Response);

            // Comprobar credenciales
            var userInfo = await _authService.ValidateUserCredentialsAsync(request);

            if (userInfo == null)
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, "Credenciales incorrectas.");
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_INCORRECT_CREDENTIALS,
                    HttpContext.TraceIdentifier));
            }

            // Generar tokens
            var accessToken = _jwtService.GenerateAccessToken(userInfo);
            var refreshToken = _jwtService.GenerateRefreshToken();

            // Guardar refresh token en base de datos asociado al usuario
            await _authService.SaveRefreshToken(userInfo.Id, userInfo.UserName, refreshToken);

            // Obtener tiempo de expiración del token de acceso
            var expirationMinutes = _configuration.JwtSettings.AccessTokenExpirationMinutes;

            var loginOk = new LoginDto
            {
                ExpiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes),
                TokenType = "Bearer"
            };

            // Establecer cookies HttpOnly y Secure para tokens
            var accessCookieOptions = CreateSecureCookieOptions(
                DateTimeOffset.UtcNow.AddMinutes(expirationMinutes)
            );
            Response.Cookies.Append(AuthConstants.AUTH_COOKIE_ACCESS, accessToken, accessCookieOptions);
            
            var refreshCookieOptions = CreateSecureCookieOptions(
                DateTimeOffset.UtcNow.AddDays(_configuration.JwtSettings.RefreshTokenExpirationDays)
            );
            Response.Cookies.Append(AuthConstants.AUTH_COOKIE_REFRESH, refreshToken, refreshCookieOptions);

            _msg = string.Format(AuthTextConstants.AUTH_OK, safeUserName);
            var response = ApiResponseBuilder.Success(loginOk, _msg);

            _logger.LogInformation(_msg);

            return Ok(response);
        }

        /// <summary>
        /// Refresca los tokens de acceso usando los tokens de las cookies HttpOnly
        /// </summary>
        /// <returns>Nuevos tokens de acceso y refresco (también en cookies)</returns>
        /// <response code="200">Tokens refrescados exitosamente</response>
        /// <response code="400">Datos invalidos</response>
        /// <response code="401">Token de refresco inválido o expirado</response>
        [HttpPost("refresh")]
        [ProducesResponseType(typeof(ApiResponse<RefreshTokenDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RefreshToken()
        {
            string _msg;

            _logger.LogInformation(AuthTextConstants.AUTH_REFRESH);
            ResponseCacheHelper.DisableCache(Response);

            // Leer tokens exclusivamente desde cookies HttpOnly
            var accessTokenFromCookie = Request.Cookies[AuthConstants.AUTH_COOKIE_ACCESS];
            var refreshTokenFromCookie = Request.Cookies[AuthConstants.AUTH_COOKIE_REFRESH];

            if (string.IsNullOrWhiteSpace(accessTokenFromCookie) || string.IsNullOrWhiteSpace(refreshTokenFromCookie))
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE02_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }

            //Recuperar Principal del token de acceso (desde cookie)
            var principal = await _jwtService.GetPrincipalFromExpiredToken(accessTokenFromCookie);
            if (principal == null)
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE03_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }
            
            // Recuperar Usuario desde Principal
            var Id = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(Id) || !int.TryParse(Id, out int userId))
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE04_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }
            UserInfoDto? userAuth = await _authService.ValidateRefreshTokenAsync(userId, refreshTokenFromCookie);
            
            if (userAuth == null)
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE05_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }
            
            // Generar nuevos tokens
            var newAccessToken = _jwtService.GenerateAccessToken(userAuth);
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            await _authService.SaveRefreshToken(userAuth.Id, userAuth.UserName, newRefreshToken);

            // Obtener tiempo de expiración del token de acceso
            var expirationMinutes = _configuration.JwtSettings.AccessTokenExpirationMinutes;

            var loginOk = new LoginDto
            {
                ExpiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes),
                TokenType = "Bearer"
            };

            // Actualizar cookies HttpOnly con los nuevos tokens
            var accessCookieOptions = CreateSecureCookieOptions(
                DateTimeOffset.UtcNow.AddMinutes(expirationMinutes)
            );
            Response.Cookies.Append(AuthConstants.AUTH_COOKIE_ACCESS, newAccessToken, accessCookieOptions);

            var refreshCookieOptions = CreateSecureCookieOptions(
                DateTimeOffset.UtcNow.AddDays(_configuration.JwtSettings.RefreshTokenExpirationDays)
            );
            Response.Cookies.Append(AuthConstants.AUTH_COOKIE_REFRESH, newRefreshToken, refreshCookieOptions);
    
            _msg = string.Format(AuthTextConstants.AUTH_REFRESH_OK, userId);
            var response = ApiResponseBuilder.Success(loginOk, _msg);

            _logger.LogInformation(_msg);

            return Ok(response);
        }

        /// <summary>
        /// Cierra sesión: revoca el refresh token y elimina cookies de autenticación.
        /// </summary>
        /// <returns>Confirmación de cierre de sesión</returns>
        [HttpPost("logout")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Logout()
        {
            string _msg;

            _logger.LogInformation("Intento de logout");
            ResponseCacheHelper.DisableCache(Response);

            // Recuperar tokens desde cookies HttpOnly
            var accessTokenFromCookie = Request.Cookies[AuthConstants.AUTH_COOKIE_ACCESS] ?? string.Empty;
            var refreshTokenFromCookie = Request.Cookies[AuthConstants.AUTH_COOKIE_REFRESH] ?? string.Empty;

            if (string.IsNullOrWhiteSpace(accessTokenFromCookie) || string.IsNullOrWhiteSpace(refreshTokenFromCookie))
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE02_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }

            // Recuperar Principal del token de acceso (desde cookie)
            var principal = await _jwtService.GetPrincipalFromExpiredToken(accessTokenFromCookie);
            if (principal == null)
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE03_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }

            var idClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(idClaim) || !int.TryParse(idClaim, out int userId))
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE04_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }

            await _authService.DeleteRefreshToken(userId);

            // Eliminar cookies estableciendo expiración pasada
            var expiredCookieOptions = CreateSecureCookieOptions(DateTimeOffset.UtcNow.AddDays(-1));
            Response.Cookies.Append(AuthConstants.AUTH_COOKIE_ACCESS, string.Empty, expiredCookieOptions);
            Response.Cookies.Append(AuthConstants.AUTH_COOKIE_REFRESH, string.Empty, expiredCookieOptions);

            _msg = string.Format(AuthTextConstants.AUTH_EXIT, userId);
            var ok = ApiResponseBuilder.Success(_msg, "Sesión cerrada.");
            _logger.LogInformation(_msg);
            
            return Ok(ok);
        }

        /// <summary>
        /// Verifica si el usuario tiene una sesión activa válida
        /// </summary>
        /// <returns>Información de la sesión si es válida</returns>
        /// <response code="200">Sesión válida con información del usuario</response>
        /// <response code="401">Sesión inválida o expirada</response>
        [HttpGet("session/verify")]
        [ProducesResponseType(typeof(ApiResponse<SessionVerifyResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SessionVerify()
        {
            string _msg;

            _logger.LogInformation(AuthTextConstants.AUTH_SESSION_VERIFICATION);
            ResponseCacheHelper.DisableCache(Response);

            var result = await _jwtService.SessionVerify(HttpContext);

            if (!result.IsValid)
            {
                _msg = string.Format(AuthTextConstants.AUTH_SESSION_VERIFICATION_FAILED, result.ErrorMessage);
                _logger.LogWarning(_msg);
                
                _msg = string.Format(AuthTextConstants.AUTH_SESSION_VERIFICATION_FAILED, "Resultado no válido");
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    _msg,
                    HttpContext.TraceIdentifier));
            }

            _msg = string.Format(AuthTextConstants.AUTH_SESSION_VERIFICATION_OK, result.UserName);
            var response = ApiResponseBuilder.Success(
                result,
                _msg
            );

            _logger.LogInformation(_msg);
            return Ok(response);
        }

        /// <summary>
        /// Obtiene los módulos asociados al perfil del usuario autenticado
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Lista de módulos obtenida exitosamente</response>
        /// <response code="401">Usuario no autenticado o datos inválidos</response>
        [ProducesResponseType(typeof(ApiResponse<List<AuthProcessDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
        [HttpGet("processes/mainModules")]
        public async Task<IActionResult> GetMainModules()
        {
            return await HandleUserProfileAction(
                AuthTextConstants.AUTH_PROFILE_MODULES_RETRIEVAL_ATTEMPT,
                AuthTextConstants.AUTH_PROFILE_MODULES_RETRIEVAL_OK,
                async (userId, perfilId, userName) =>
                {
                    // Intentar obtener de caché MemoryCache
                    string cacheKey = $"{CacheConstants.CACHE_KEY_MODULES}{userId}_{perfilId}";
                    if (_memoryCache.TryGetValue(cacheKey, out List<AuthProcessDto>? cachedModules) && cachedModules != null)
                    {
                        return cachedModules;
                    }
                    var processes = await _authService.GetProcessesByUserAndProfileAsync(userId, perfilId, ProcessType.Modules, true);
                    
                    // Almacenar en caché MemoryCache
                    var cacheOptions = MemoryCacheHelper.CreateVolatileDataCacheOptions();
                    _memoryCache.Set(cacheKey, processes, cacheOptions);

                    return processes;
                }
            );
        }

        /// <summary>
        /// Obtiene los procesos opciones de menú de un modulo, asociados al perfil del usuario autenticado
        /// </summary>
        /// <param name="idModulo">Código del módulo para filtrar las opciones de menú</param>
        /// <returns></returns>
        /// <response code="200">Lista de procesos obtenida exitosamente</response>
        /// <response code="401">Usuario no autenticado o datos inválidos</response>
        [ProducesResponseType(typeof(ApiResponse<List<AuthProcessDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
        [HttpGet("processes/menuOptions")]
        public async Task<IActionResult> GetMenuOptions([FromQuery] string? idModulo = null)
        {
            return await HandleUserProfileAction(
                AuthTextConstants.AUTH_PROFILE_MENU_OPTIONS_RETRIEVAL_ATTEMPT,
                AuthTextConstants.AUTH_PROFILE_MENU_OPTIONS_RETRIEVAL_OK,
                
                async (userId, perfilId, userName) =>
                {
                    // Intentar obtener de caché MemoryCache
                    string cacheKey =  $"{CacheConstants.CACHE_KEY_MENU}{userId}_{perfilId}_{idModulo}";
                    if (_memoryCache.TryGetValue(cacheKey, out List<AuthProcessDto>? cachedMenuOptions) && cachedMenuOptions != null)
                    {
                        return cachedMenuOptions;
                    }
                    var menuOptions = await _authService.GetProcessesByUserAndProfileAsync(userId, perfilId, 
                                                                                           ProcessType.MenuOptions,
                                                                                           true,    
                                                                                           idModulo);

                    // Almacenar en caché MemoryCache
                    var cacheOptions = MemoryCacheHelper.CreateVolatileDataCacheOptions();                          
                    _memoryCache.Set(cacheKey, menuOptions, cacheOptions);

                    return menuOptions;
                }
            );
        }

        /// <summary>
        /// Obtiene los códigos de procesos autorizados del usuario autenticado
        /// </summary>
        /// <returns>Lista de códigos de procesos autorizados</returns>
        /// <response code="200">Lista de códigos de procesos autorizados obtenida exitosamente</response>
        /// <response code="401">Usuario no autenticado o datos inválidos</response>
        [ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
        [HttpGet("processes/Codes")]
        public async Task<IActionResult> GetAuthProcessCodes()
        {
            return await HandleUserProfileAction(
                AuthTextConstants.AUTH_PROFILE_PROCESS_CODES_RETRIEVAL_ATTEMPT,
                AuthTextConstants.AUTH_PROFILE_PROCESS_CODES_RETRIEVAL_OK,
                async (userId, perfilId, userName) =>
                {
                    // Intentar obtener de caché MemoryCache
                    string cacheKey =  $"{CacheConstants.CACHE_KEY_PROCESS}{userId}_{perfilId}";
                    if (_memoryCache.TryGetValue(cacheKey, out List<string>? cachedProcessCodes) && cachedProcessCodes != null)
                    {
                        return cachedProcessCodes;
                    }

                    var process = await _authService.GetCodeProcessByUserAndProfileAsync(userId, perfilId);

                    // Almacenar en caché MemoryCache
                    var cacheOptions = MemoryCacheHelper.CreateVolatileDataCacheOptions();                          
                    _memoryCache.Set(cacheKey, process, cacheOptions);
                    
                    return process;     
                }
            );
        }

        #region Metodos Privados
        /// <summary>
        /// Maneja la obtención de datos de perfil de usuario autenticado, reutilizando lógica común para endpoints similares.
        /// </summary>
        /// <typeparam name="T">Tipo de datos devueltos por la acción específica</typeparam>
        /// <param name="logAttemptMsg">Mensaje de intento para logging</param>
        /// <param name="logSuccessMsg">Mensaje de éxito para logging</param>
        /// <param name="getDataFunc">Función delegada asíncrona que recibe los datos obtenidos en este metodo 
        /// userId, perfilId, userName y retorna los datos</param>
        /// <returns>Resultado IActionResult adecuado</returns>
        private async Task<IActionResult> HandleUserProfileAction<T>(string logAttemptMsg, 
                                                                     string logSuccessMsg, 
                                                                     Func<int, int, string, Task<T>> getDataFunc)   
        {
            string _msg = logAttemptMsg;
            _logger.LogInformation(_msg);
            ResponseCacheHelper.DisableCache(Response);

            var accessTokenFromCookie = Request.Cookies[AuthConstants.AUTH_COOKIE_ACCESS] ?? string.Empty;
            if (string.IsNullOrWhiteSpace(accessTokenFromCookie))
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE02_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }

            var principal = await _jwtService.GetPrincipalFromExpiredToken(accessTokenFromCookie);
            if (principal == null)
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE03_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }

            // Id es auxiliar para obtener claims
            var Id = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(Id) || !int.TryParse(Id, out int userId))
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE04_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }

            var userName = principal.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
            if (string.IsNullOrEmpty(userName))
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE06_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }

            Id = principal.FindFirst(AuthConstants.INFRAESTRUCTURE_CLAIMS_PERFILID)?.Value;
            if (string.IsNullOrEmpty(Id) || !int.TryParse(Id, out int perfilId))
            {
                _msg = string.Format(AuthTextConstants.AUTH_INVALID_DATA, AuthTextConstants.AUTH_MOTIVE07_FAILED);
                _logger.LogWarning(_msg);
                return Unauthorized(ApiResponseBuilder.Unauthorized<object>(
                    AuthTextConstants.AUTH_FAILED,
                    HttpContext.TraceIdentifier));
            }

            var data = await getDataFunc(userId, perfilId, userName);
            _msg = string.Format(logSuccessMsg, userName);
            _logger.LogInformation(_msg);
            var response = ApiResponseBuilder.Success(data, _msg);

            return Ok(response);
        }

        /// <summary>
        /// Crea opciones de cookie seguras con configuración HttpOnly, Secure y SameSite
        /// </summary>
        /// <param name="expirationTime">Tiempo de expiración de la cookie</param>
        /// <returns>Opciones de cookie configuradas de forma segura</returns>
        private static CookieOptions CreateSecureCookieOptions(DateTimeOffset expirationTime)
        {
            return new CookieOptions
            {
                HttpOnly = true,      // Previene acceso desde JavaScript (XSS)
                Secure = true,        // Solo se envía por HTTPS
                SameSite = SameSiteMode.Lax,  // Protección CSRF, permite navegación legítima
                Path = "/",           // Limita el alcance de la cookie
                Expires = expirationTime
            };
        }
        #endregion 
    }
}