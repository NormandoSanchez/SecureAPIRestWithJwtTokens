using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using System.Data;

namespace SecureAPIRestWithJwtTokens.Services
{
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

    /// <summary>
    /// Interfaz para servicios de acceso a datos SQL con soporte para operaciones asíncronas y gestión de conexiones.
    /// </summary>
    public interface ISqlDataService : IAsyncDisposable
    {
        Task<bool> GetConnection(FarmaciaDBConnectionInternal connectionInfo, int timeout = 40);
        Task<DataTable> ExecuteQueryAsync(string query, CommandType tipo, bool longTimeOut = false, Dictionary<string, object>? parameters = null);
        Task<int> ExecuteNonQueryAsync(string query, CommandType tipo, bool longTimeOut = false, Dictionary<string, object>? parameters = null);
    }
}
