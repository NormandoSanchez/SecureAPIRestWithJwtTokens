using System.Data;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;

namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

/// <summary>
/// Interfaz para servicios de acceso a datos SQL con soporte para operaciones asíncronas y gestión de conexiones.
/// </summary>
public interface ISqlDataService : IAsyncDisposable
{
    Task<bool> GetConnection(FarmaciaDBConnectionInternal connectionInfo, int timeout = 40);
    Task<DataTable> ExecuteQueryAsync(string query, CommandType tipo, bool longTimeOut = false, Dictionary<string, object>? parameters = null);
    Task<int> ExecuteNonQueryAsync(string query, CommandType tipo, bool longTimeOut = false, Dictionary<string, object>? parameters = null);
}