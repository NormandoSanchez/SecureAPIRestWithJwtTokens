namespace SecureAPIRestWithJwtTokens.Models.InternalDTO;

/// <summary>
/// Representa la configuración de la aplicación mapeada desde appsettings.json.
/// </summary>
public class ApiConfiguration
{
    public ConnectionStrings ConnectionStrings { get; set; } = new();
    public JwtSettings JwtSettings { get; set; } = new();
    public DatosDocumentacion DatosDocumentacion { get; set; } = new();
    public PropiedadesApi PropiedadesApi { get; set; } = new();
    public Resilience Resilience { get; set; } = new();
    public CacheSettings CacheSettings { get; set; } = new();
    public CorsSettings Cors { get; set; } = new();
    public NotificacionesSettings Notificaciones { get; set; } = new();
}

/// <summary>
/// Configuración de notificaciones y avisos internos
/// </summary>
public class NotificacionesSettings
{
    /// <summary>
    /// Número de meses para filtrar los avisos vistos
    /// </summary>
    public int MesesTopeVistos { get; set; }

    /// <summary>
    /// Número de meses para filtrar los avisos antiguos
    /// </summary>
    public int MesesTopeAntiguos { get; set; }
}

/// <summary>
/// Configuración de CORS
/// </summary>
public class CorsSettings
{
    /// <summary>
    /// Orígenes permitidos para el cliente (e.g., https://app.tu-dom.com)
    /// </summary>
    public string[] AllowedOrigins { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Permitir cualquier encabezado (normalmente true)
    /// </summary>
    public bool AllowAnyHeader { get; set; } = true;

    /// <summary>
    /// Permitir cualquier método (normalmente true)
    /// </summary>
    public bool AllowAnyMethod { get; set; } = true;
}

/// <summary>
/// Configuración de cadenas de conexión.
/// </summary>
public class ConnectionStrings
{
    public string TrebolDBConnection { get; set; } = string.Empty;
}

/// <summary>
/// Configuración para la generación y validación de tokens JWT.
/// </summary>
public class JwtSettings
{
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int AccessTokenExpirationMinutes { get; set; }
    public int RefreshTokenExpirationDays { get; set; }
}

/// <summary>
/// Metadatos para la documentación de Swagger/OpenAPI.
/// </summary>
public class DatosDocumentacion
{
    public string Contacto { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
}

/// <summary>
/// Configuración específica de la API.
/// </summary>
public class PropiedadesApi
{
    public string DBAppName { get; set; } = string.Empty;
}

/// <summary>
/// Configuración de políticas de resiliencia (Polly).
/// </summary>
public class Resilience
{
    public CircuitBreakerSettings CircuitBreaker { get; set; } = new();
    public ParallelizationSettings Parallelization { get; set; } = new();
}

/// <summary>
/// Configuración del patrón Circuit Breaker.
/// </summary>
public class CircuitBreakerSettings
{
    public int ExceptionsBeforeBreaking { get; set; }
    public int DurationOfBreakSeconds { get; set; }
}

/// <summary>
/// Configuración para la ejecución en paralelo de sentencias SQL.
/// </summary>
public class ParallelizationSettings
{
    public int MaxConcurrency { get; set; }
    public int PerServerConnectionTimeoutSeconds { get; set; }
}

/// <summary>
/// Configuración de caché de la aplicación
/// </summary>
public class CacheSettings
{
    public ResponseCacheSettings ResponseCache { get; set; } = new();
    public MemoryCacheSettings MemoryCache { get; set; } = new();
}

/// <summary>
/// Configuración de Response Cache (HTTP)
/// </summary>
public class ResponseCacheSettings
{
    /// <summary>
    /// Duración por defecto en segundos para Response Cache
    /// </summary>
    public int DefaultDurationSeconds { get; set; } = 3600;

    /// <summary>
    /// Duración específica para datos con muy pocos cambios como datos geográficos (países, provincias, etc.)
    /// </summary>
    public int SlowChangeDataDurationSeconds { get; set; } = 86400;
}

/// <summary>
/// Configuración de Memory Cache
/// </summary>
public class MemoryCacheSettings
{
    /// <summary>
    /// Expiración deslizante en horas (se renueva si se accede)
    /// </summary>
    public int SlidingExpirationHours { get; set; } = 12;

    /// <summary>
    /// Expiración absoluta en horas
    /// </summary>
    public int AbsoluteExpirationHours { get; set; } = 24;

    /// <summary>
    /// Expiración absoluta para datos con muy pocos cambios como los datos geográficos, en días
    /// </summary>
    public int SlowChangeDataAbsoluteExpirationDays { get; set; } = 7;
}
