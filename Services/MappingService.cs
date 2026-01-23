using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Tools;

namespace SecureAPIRestWithJwtTokens.Services;

/// <summary>
/// Interfaz para el servicio de mapeo
/// </summary>
public interface IMappingService
{
    UserInfoDto MapUsuarioToUserInfo(Usuario usuario);
    Task<UserInfoDto> MapUsuarioToUserInfoAsync(Usuario usuario);
}

/// <summary>
/// Servicio para mapeos específicos de la aplicación
/// </summary>
public class MappingService(IMapper mapper, ILogger<MappingService> logger) : IMappingService
{
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<MappingService> _logger = logger;

    /// <summary>
    /// Mapea un Usuario a UserInfo con logging
    /// </summary>
    public UserInfoDto MapUsuarioToUserInfo(Usuario usuario)
    {
        if (usuario == null)
        {
            _logger.LogWarning("Intento de mapear Usuario null a UserInfo");
            throw new ArgumentNullException(nameof(usuario));
        }

        try
        {
            var userInfo = _mapper.Map<UserInfoDto>(usuario);
            _logger.LogInformation("Usuario mapeado exitosamente: {UserId} -> {Username}",
                                    userInfo.Id, Sanitizer.Sanitize(userInfo.UserName));

            return userInfo;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error mapeando Usuario {UsrId} a UserInfo", usuario.UsrId);
            throw;
        }
    }

    /// <summary>
    /// Versión asíncrona del mapeo (para futuras extensiones)
    /// </summary>
    public async Task<UserInfoDto> MapUsuarioToUserInfoAsync(Usuario usuario)
    {
        // Por ahora es síncrono, pero está preparado para operaciones async futuras
        await Task.CompletedTask;
        return MapUsuarioToUserInfo(usuario);
    }

    /// <summary>
    /// Mapea una Direccion a string direccion completa
    /// </summary>
    public string? MapDireccionToString(Direccion dir)
    {
        if (dir == null)
        {
            return null;
        }

        try
        {
            string direccionCompleta = _mapper.Map<string>(dir);
            _logger.LogInformation("Direccion mapeada exitosamente a string: {Direccion}",
                                    Sanitizer.Sanitize(direccionCompleta, maxLength: 256));



            return direccionCompleta;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error mapeando Direccion a string");
            throw;
        }
    }
}