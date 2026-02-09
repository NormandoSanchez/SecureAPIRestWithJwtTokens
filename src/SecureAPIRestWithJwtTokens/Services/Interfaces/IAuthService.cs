using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Tools;

namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

/// <summary>
/// Proporciona métodos de autenticación y autorización.
/// </summary>
public interface IAuthService
{
    Task<UserInfoDto?> ValidateUserCredentialsAsync(LoginApiRequest loginRequest);
    Task<UserInfoDto?> ValidateRefreshTokenAsync(int userId, string refreshToken);
    Task SaveRefreshToken(int userId, string userName, string refreshToken);
    Task DeleteRefreshToken(int userId);
    Task<List<string>?> GetCodeProcessByUserAndProfileAsync(int userId, int perfilId); 
    Task<List<AuthProcessDto>> GetProcessesByUserAndProfileAsync(int userId, int perfilId, 
                                                                ProcessType typeClass,
                                                                bool? visibleOn = true,
                                                                string? idModulo = null);
}