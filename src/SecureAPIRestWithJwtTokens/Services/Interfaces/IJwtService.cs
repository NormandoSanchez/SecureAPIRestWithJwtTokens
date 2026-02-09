using System.Security.Claims;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;

namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

 /// <summary>
/// Interfaz para el servicio JWT
/// </summary>
public interface IJwtService
{
    string GenerateAccessToken(UserInfoDto userInfo);
    string GenerateRefreshToken();
    Task<ClaimsPrincipal?> GetPrincipalFromExpiredToken(string token);
    Task<SessionVerifyResult> SessionVerify(HttpContext httpContext);
}