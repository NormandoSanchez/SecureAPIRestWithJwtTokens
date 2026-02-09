namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

/// <summary>
/// Factory para crear instancias de ISqlDataService con gestión de conexiones independientes.
/// </summary>
public interface ISqlDataServiceFactory
{
    /// <summary>
    /// Crea una nueva instancia de ISqlDataService.
    /// </summary>
    /// <returns>Una nueva instancia de ISqlDataService lista para usar.</returns>
    ISqlDataService CreateService();
}