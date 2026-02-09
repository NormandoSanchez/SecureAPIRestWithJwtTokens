using Polly.CircuitBreaker;

namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

/// <summary>
/// Gestiona políticas de Circuit Breaker para conexiones a bases de datos.
/// Este servicio debe ser registrado como Singleton.
/// </summary>
public interface ICircuitBreakerService
{
    /// <summary>
    /// Obtiene una política de Circuit Breaker para una clave de servidor única.
    /// </summary>
    AsyncCircuitBreakerPolicy GetCircuitBreaker(string serverKey);
}
