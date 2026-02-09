using System.Data;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;

namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

 public interface IParallelSqlExecutor<T>
{
    /// <summary>
    /// Orquesta la ejecución de consultas SQL en paralelo contra múltiples servidores.
    /// T - DataTable para consultas que devuelven datos, int para comandos.        
    /// </summary>
    Task<MultiServerExecutionSummary<T>> ExecuteOnMultipleServersAsync(
        List<FarmaciaDBConnectionInternal> connections,
        string query,
        CommandType type = CommandType.Text,
        bool longTimeOut = false,
        Dictionary<string, object>? parameters = null);
}