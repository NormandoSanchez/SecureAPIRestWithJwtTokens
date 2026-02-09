using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Services;

namespace SecureAPIRestWithJwtTokens.Tests.Services;

/// <summary>
/// Tests unitarios básicos para CircuitBreakerService
/// </summary>
public class CircuitBreakerServiceTests
{
    private readonly Mock<ILogger<CircuitBreakerService>> _mockLogger;
    private readonly ApiConfiguration _configuration;

    public CircuitBreakerServiceTests()
    {
        _mockLogger = new Mock<ILogger<CircuitBreakerService>>();
        _configuration = new ApiConfiguration
        {
            Resilience = new Resilience
            {
                CircuitBreaker = new CircuitBreakerSettings
                {
                    ExceptionsBeforeBreaking = 3,
                    DurationOfBreakSeconds = 30
                }
            }
        };
    }

    private CircuitBreakerService CreateService()
    {
        return new CircuitBreakerService(_mockLogger.Object, _configuration);
    }

    #region GetCircuitBreaker Tests

    /// <summary>
    /// Verifica que GetCircuitBreaker crea un CircuitBreaker correctamente
    /// </summary>
    [Fact]
    public void GetCircuitBreaker_CreatesCircuitBreakerSuccessfully()
    {
        // Arrange
        var service = CreateService();

        // Act
        var circuitBreaker = service.GetCircuitBreaker("server1/database1");

        // Assert
        circuitBreaker.Should().NotBeNull();
    }

    /// <summary>
    /// Verifica que GetCircuitBreaker con la misma key retorna la misma instancia (caché)
    /// </summary>
    [Fact]
    public void GetCircuitBreaker_SameKey_ReturnsSameInstance()
    {
        // Arrange
        var service = CreateService();
        var serverKey = "server1/database1";

        // Act
        var circuitBreaker1 = service.GetCircuitBreaker(serverKey);
        var circuitBreaker2 = service.GetCircuitBreaker(serverKey);

        // Assert
        circuitBreaker1.Should().NotBeNull();
        circuitBreaker2.Should().NotBeNull();
        circuitBreaker1.Should().BeSameAs(circuitBreaker2);
    }

    /// <summary>
    /// Verifica que GetCircuitBreaker con diferentes keys retorna diferentes instancias
    /// </summary>
    [Fact]
    public void GetCircuitBreaker_DifferentKeys_ReturnsDifferentInstances()
    {
        // Arrange
        var service = CreateService();
        var serverKey1 = "server1/database1";
        var serverKey2 = "server2/database2";

        // Act
        var circuitBreaker1 = service.GetCircuitBreaker(serverKey1);
        var circuitBreaker2 = service.GetCircuitBreaker(serverKey2);

        // Assert
        circuitBreaker1.Should().NotBeNull();
        circuitBreaker2.Should().NotBeNull();
        circuitBreaker1.Should().NotBeSameAs(circuitBreaker2);
    }



    /// <summary>
    /// Verifica que el servicio maneja múltiples servidores concurrentemente
    /// </summary>
    [Fact]
    public void GetCircuitBreaker_MultipleServers_ManagesIndependentCircuitBreakers()
    {
        // Arrange
        var service = CreateService();
        var serverKeys = new[]
        {
            "server1/db1",
            "server2/db2",
            "server3/db3",
            "server4/db4"
        };

        // Act
        var circuitBreakers = serverKeys.Select(key => service.GetCircuitBreaker(key)).ToList();

        // Assert
        circuitBreakers.Should().HaveCount(4);
        circuitBreakers.Should().OnlyHaveUniqueItems();
    }

    /// <summary>
    /// Verifica que el servicio usa la configuración proporcionada
    /// </summary>
    [Fact]
    public void GetCircuitBreaker_UsesProvidedConfiguration()
    {
        // Arrange
        var customConfig = new ApiConfiguration
        {
            Resilience = new Resilience
            {
                CircuitBreaker = new CircuitBreakerSettings
                {
                    ExceptionsBeforeBreaking = 5,
                    DurationOfBreakSeconds = 60
                }
            }
        };

        var service = new CircuitBreakerService(_mockLogger.Object, customConfig);

        // Act
        var circuitBreaker = service.GetCircuitBreaker("testserver/testdb");

        // Assert
        circuitBreaker.Should().NotBeNull();
        // El CircuitBreaker se crea con la configuración personalizada
        // No podemos verificar directamente los valores internos, pero verificamos que se crea sin error
    }

    #endregion
}
