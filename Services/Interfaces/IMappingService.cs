using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;

namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

/// <summary>
/// Interfaz para el servicio de mapeo
/// </summary>
public interface IMappingService
{
    UserInfoDto MapUsuarioToUserInfo(Usuario usuario);
    Task<UserInfoDto> MapUsuarioToUserInfoAsync(Usuario usuario);
}