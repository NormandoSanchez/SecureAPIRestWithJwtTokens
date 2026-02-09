using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using Polly.CircuitBreaker;
using System.Data;
using System.Diagnostics;
using SecureAPIRestWithJwtTokens.Services.Interfaces;


namespace SecureAPIRestWithJwtTokens.Services
{
    /// <summary>
    /// Ejecutor de consultas SQL en paralelo con resiliencia.
    /// </summary>
    /// <typeparam name="T">Tipo de dato esperado como resultado de la consulta. (DataTable o int)</typeparam>
    /// <param name="sqlDataServiceFactory">Factory para crear instancias de ISqlDataService.</param>
    /// <param name="logger">Logger para registrar eventos e información.</param>
    /// <param name="configuration">Configuración de la API.</param>
    public class ParallelSqlExecutor<T>(
        ISqlDataServiceFactory sqlDataServiceFactory,
        ILogger<ParallelSqlExecutor<T>> logger,
        ApiConfiguration configuration) : IParallelSqlExecutor<T>
    {
        private readonly ISqlDataServiceFactory _sqlDataServiceFactory = sqlDataServiceFactory;
        private readonly ILogger<ParallelSqlExecutor<T>> _logger = logger;
        private readonly ApiConfiguration _configuration = configuration;

        public async Task<MultiServerExecutionSummary<T>> ExecuteOnMultipleServersAsync(
           List<FarmaciaDBConnectionInternal> connections,
           string query,
           CommandType type = CommandType.Text,
           bool longTimeOut = false,
           Dictionary<string, object>? parameters = null)
        {
            var maxConcurrency = _configuration.Resilience.Parallelization.MaxConcurrency;
            var perServerTimeout = TimeSpan.FromSeconds(_configuration.Resilience.Parallelization.PerServerConnectionTimeoutSeconds);

            var summary = new MultiServerExecutionSummary<T> { TotalServers = connections.Count };
            var overallStopwatch = Stopwatch.StartNew();
            using var semaphore = new SemaphoreSlim(maxConcurrency);

            // 1. Declara una variable local para el contador.
            int circuitBreakerRejections = 0;

            var tasks = connections.Select(async conn =>
            {
                await semaphore.WaitAsync();
                var stopwatch = Stopwatch.StartNew();
                var result = new MultiServerQueryResult<T> { ServerKey = $"{conn.Server}/{conn.DataBase}" ,
                                                             IdUnidadNegocioERP = conn.IdUnidadNegocioERP };

                try
                {
                    using var cts = new CancellationTokenSource(perServerTimeout);
                    await using var sqlService = _sqlDataServiceFactory.CreateService();

                    await sqlService.GetConnection(conn, (int)perServerTimeout.TotalSeconds);

                    if (typeof(T) == typeof(DataTable))
                        result.Data = (T)(object)await sqlService.ExecuteQueryAsync(query, type, longTimeOut, parameters);
                    else if (typeof(T) == typeof(int))
                        result.Data = (T)(object)await sqlService.ExecuteNonQueryAsync(query, type, longTimeOut, parameters);

                    result.Success = true;
                }
                catch (BrokenCircuitException)
                {
                    result.Success = false;
                    result.ErrorMessage = "Operación rechazada por Circuit Breaker (servidor no disponible).";
                    // 2. Incrementa la variable local de forma segura.
                    Interlocked.Increment(ref circuitBreakerRejections);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.ErrorMessage = ex.Message;
                    _logger.LogError(ex, "Fallo en la ejecución para el servidor {ServerKey}", result.ServerKey);
                }
                finally
                {
                    stopwatch.Stop();
                    result.ExecutionTime = stopwatch.Elapsed;
                    semaphore.Release();
                }
                return result;
            });

            var results = await Task.WhenAll(tasks);
            overallStopwatch.Stop();

            // 3. Asigna el resultado final al objeto summary.
            summary.CircuitBreakerRejections = circuitBreakerRejections;
            summary.Results.AddRange(results);
            summary.SuccessCount = results.Count(r => r.Success);
            summary.FailureCount = summary.TotalServers - summary.SuccessCount;
            summary.TotalExecutionTime = overallStopwatch.Elapsed;

            _logger.LogInformation(
                "Ejecución paralela completada en {TotalTime}s. {SuccessCount}/{TotalServers} exitosos. Tasa de éxito: {SuccessRate:F2}%",
                summary.TotalExecutionTime.TotalSeconds,
                summary.SuccessCount,
                summary.TotalServers,
                summary.SuccessRate);

            return summary;
        }
    }
}