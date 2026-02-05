using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Tools;

namespace SecureAPIRestWithJwtTokens.Repository.Interfaces;
    /// <summary>
    /// Proporciona métodos para acceder a la información de seguridad en la base de datos.
    /// </summary>
    /// <remarks>Este repositorio es responsable de recuperar y gestionar información relacionada con la seguridad,
    /// como usuarios, tokens de actualización y procesos de autorización. Está diseñado para trabajar con el <see
    /// cref="TrebolDbContext"/>.</remarks>
    public interface ISecurityRepo
    {
        Task<Usuario?> GetByCredentialsAsync(LoginApiRequest login);
        Task<Usuario?> GetByIdAsync(int id);
        Task SaveRefreshToken(int userId, string userName, string refreshToken, DateTime expiry);
        Task<string?> GetRefreshToken(int userId);
        Task DeleteRefreshToken(int userId);
        Task<List<string>?> GetCodeProcessByUserAndProfileAsync(int userId, int perfilId); 
        Task<List<AuthProcessDto>?> GetProcessByUserAndProfileAsync(int userId, int perfilId, 
                                                                    ProcessType typeClass, bool? VisibleOn = true,
                                                                    string? idModulo = null);
    }