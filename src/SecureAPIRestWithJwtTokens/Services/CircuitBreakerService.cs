using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using Microsoft.Data.SqlClient;
using Polly;
using Polly.CircuitBreaker;
using System.Collections.Concurrent;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Services
{
    /// <summary>
    /// Gestiona políticas de Circuit Breaker para conexiones a bases de datos.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="configuration"></param>
    public class CircuitBreakerService(ILogger<CircuitBreakerService> logger, ApiConfiguration configuration) : ICircuitBreakerService
    {
        private readonly ILogger<CircuitBreakerService> _logger = logger;
        private readonly ApiConfiguration _configuration = configuration;
        // Un diccionario thread-safe para almacenar un Circuit Breaker por cada servidor.
        // Internal para que pueda ser accesible desde las pruebas unitarias.
        // Se añade al proyecto FarmaciasTrebolERP.API.Test mediante InternalsVisibleTo en el .csproj
        internal static readonly ConcurrentDictionary<string, AsyncCircuitBreakerPolicy> _circuitBreakers = new();

        /// <summary>
        /// Obtiene una política de Circuit Breaker para una clave de servidor única.
        /// </summary>
        /// <param name="serverKey">Clave del servidor.</param>
        /// <returns>Política de Circuit Breaker.</returns>
        public AsyncCircuitBreakerPolicy GetCircuitBreaker(string serverKey)
        {
            return _circuitBreakers.GetOrAdd(serverKey, key =>
            {
                _logger.LogInformation("Creando nueva política de Circuit Breaker para {ServerKey}", key);
                return CreateCircuitBreakerPolicy(key);
            });
        }

        /// <summary>
        /// Crea una política de Circuit Breaker para una clave de servidor única.
        /// </summary>
        /// <param name="serverKey">Clave del servidor.</param>
        /// <returns>Política de Circuit Breaker.</returns>
        private AsyncCircuitBreakerPolicy CreateCircuitBreakerPolicy(string serverKey)
        {
            var exceptionsBeforeBreaking = _configuration.Resilience.CircuitBreaker.ExceptionsBeforeBreaking;
            var durationOfBreakSeconds = _configuration.Resilience.CircuitBreaker.DurationOfBreakSeconds;

            return Policy
                .Handle<SqlException>(ex => ex.Number == -2 || ex.Number == 53 || ex.Number == 4060) // Errores de conexión/timeout
                .Or<TimeoutException>()
                .CircuitBreakerAsync(
                    exceptionsAllowedBeforeBreaking: exceptionsBeforeBreaking,
                    durationOfBreak: TimeSpan.FromSeconds(durationOfBreakSeconds),
                    onBreak: (exception, breakDelay) =>
                    {
                        _logger.LogWarning(exception, "🔴 Circuit Breaker ABIERTO para {ServerKey} durante {BreakDelay}s", serverKey, breakDelay.TotalSeconds);
                    },
                    onReset: () =>
                    {
                        _logger.LogInformation("🟢 Circuit Breaker CERRADO para {ServerKey}. El servicio vuelve a estar operativo.", serverKey);
                    },
                    onHalfOpen: () =>
                    {
                        _logger.LogInformation("🟡 Circuit Breaker SEMI-ABIERTO para {ServerKey}. Se intentará una nueva conexión.", serverKey);
                    }
                );
        }
    }
}