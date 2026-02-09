using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Immutable;
using System.Globalization;
using System.Text;

namespace SecureAPIRestWithJwtTokens.Tools
{
    /// <summary>
    /// Helper para configurar headers de caché HTTP en respuestas de controladores.
    /// </summary>
    public static class ResponseCacheHelper
    {
        /// <summary>
        /// Configura los headers de caché HTTP de la respuesta.
        /// Solo aplica si existe un contexto HTTP válido (evita errores en pruebas unitarias).
        /// </summary>
        /// <param name="response">Objeto HttpResponse del contexto actual</param>
        /// <param name="durationSeconds">Duración del caché en segundos</param>
        public static void SetResponseCacheHeaders(HttpResponse? response, int durationSeconds)
        {
            // Verificar que Response no sea null (puede ser null en pruebas unitarias)
            if (response != null)
            {
                response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
                {
                    Public = true,
                    MaxAge = TimeSpan.FromSeconds(durationSeconds)
                };
            }
        }

        /// <summary>
        /// Configura los headers de caché HTTP con opciones adicionales.
        /// </summary>
        /// <param name="response">Objeto HttpResponse del contexto actual</param>
        /// <param name="durationSeconds">Duración del caché en segundos</param>
        /// <param name="isPublic">Indica si el caché es público (true) o privado (false)</param>
        /// <param name="mustRevalidate">Indica si se debe revalidar al expirar</param>
        public static void SetResponseCacheHeadersExtended(HttpResponse? response, int durationSeconds, bool isPublic = true, bool mustRevalidate = false)
        {
            if (response != null)
            {
                response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
                {
                    Public = isPublic,
                    Private = !isPublic,
                    MaxAge = TimeSpan.FromSeconds(durationSeconds),
                    MustRevalidate = mustRevalidate
                };
            }
        }

        /// <summary>
        /// Configura headers de caché con control de variación por query strings.
        /// </summary>
        /// <param name="response">Objeto HttpResponse del contexto actual</param>
        /// <param name="durationSeconds">Duración del caché en segundos</param>
        /// <param name="varyByQueryKeys">Claves de query string que afectan el caché</param>
        public static void SetResponseCacheHeadersWithVary(HttpResponse? response, int durationSeconds, params string[] varyByQueryKeys)
        {
            if (response != null)
            {
                response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
                {
                    Public = true,
                    MaxAge = TimeSpan.FromSeconds(durationSeconds)
                };

                if (varyByQueryKeys.Length > 0)
                {
                    response.Headers.Vary = string.Join(", ", varyByQueryKeys);
                }
            }
        }

        /// <summary>
        /// Deshabilita completamente el caché HTTP.
        /// </summary>
        /// <param name="response">Objeto HttpResponse del contexto actual</param>
        public static void DisableCache(HttpResponse? response)
        {
            if (response != null)
            {
                response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
                {
                    NoStore = true,
                    NoCache = true,
                    MustRevalidate = true,
                    MaxAge = TimeSpan.Zero
                };
                response.Headers.Pragma = "no-cache";
            }
        }
    }

    /// <summary>
    /// Helper para configurar opciones de Memory Cache de manera centralizada.
    /// </summary>
    public static class MemoryCacheHelper
    {
        /// <summary>
        /// Crea opciones de caché en memoria con configuración estándar.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación</param>
        /// <param name="priority">Prioridad del elemento en caché (por defecto: Normal)</param>
        /// <param name="size">Tamaño relativo del elemento (por defecto: 1)</param>
        /// <returns>Opciones configuradas de MemoryCache</returns>
        public static MemoryCacheEntryOptions CreateCacheEntryOptions(
            ApiConfiguration configuration,
            CacheItemPriority priority = CacheItemPriority.Normal,
            long size = 1)
        {
            return new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(configuration.CacheSettings.MemoryCache.SlidingExpirationHours))
                .SetAbsoluteExpiration(TimeSpan.FromHours(configuration.CacheSettings.MemoryCache.AbsoluteExpirationHours))
                .SetPriority(priority)
                .SetSize(size);
        }

        /// <summary>
        /// Crea opciones de caché en memoria con tiempos de expiración personalizados.
        /// </summary>
        /// <param name="slidingExpirationHours">Horas de expiración deslizante</param>
        /// <param name="absoluteExpirationHours">Horas de expiración absoluta</param>
        /// <param name="priority">Prioridad del elemento en caché (por defecto: Normal)</param>
        /// <param name="size">Tamaño relativo del elemento (por defecto: 1)</param>
        /// <returns>Opciones configuradas de MemoryCache</returns>
        public static MemoryCacheEntryOptions CreateCacheEntryOptions(
            int slidingExpirationHours,
            int absoluteExpirationHours,
            CacheItemPriority priority = CacheItemPriority.Normal,
            long size = 1)
        {
            return new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(slidingExpirationHours))
                .SetAbsoluteExpiration(TimeSpan.FromHours(absoluteExpirationHours))
                .SetPriority(priority)
                .SetSize(size);
        }

        /// <summary>
        /// Crea opciones de caché para datos que cambian lentamente (países, provincias, etc.)
        /// con alta prioridad y expiración prolongada.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación</param>
        /// <returns>Opciones configuradas de MemoryCache con alta prioridad</returns>
        public static MemoryCacheEntryOptions CreateSlowChangeDataCacheOptions(ApiConfiguration configuration)
        {
            return new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(configuration.CacheSettings.MemoryCache.SlidingExpirationHours))
                .SetAbsoluteExpiration(TimeSpan.FromDays(configuration.CacheSettings.MemoryCache.SlowChangeDataAbsoluteExpirationDays))
                .SetPriority(CacheItemPriority.High)
                .SetSize(1);
        }

        /// <summary>
        /// Crea opciones de caché para datos volátiles con baja prioridad.
        /// </summary>
        /// <param name="slidingExpirationMinutes">Minutos de expiración deslizante</param>
        /// <param name="absoluteExpirationMinutes">Minutos de expiración absoluta</param>
        /// <returns>Opciones configuradas de MemoryCache con baja prioridad</returns>
        public static MemoryCacheEntryOptions CreateVolatileDataCacheOptions(
            int slidingExpirationMinutes = 5,
            int absoluteExpirationMinutes = 15)
        {
            return new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(slidingExpirationMinutes))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(absoluteExpirationMinutes))
                .SetPriority(CacheItemPriority.Low)
                .SetSize(1);
        }
    }
    
    public static class CacheKeyHelper
    {
        public static string BuildKey(string prefix, IDictionary<string, object>? filtros = null)
        {
            if (filtros == null || filtros.Count == 0)
            {
                return prefix;
            }

            var ordered = filtros
                .OrderBy(kv => kv.Key, StringComparer.OrdinalIgnoreCase)
                .ToImmutableArray();

            var sb = new StringBuilder(prefix);

            foreach (var (key, value) in ordered)
            {
                sb.Append('|');

                sb.Append(key);
                sb.Append('=');

                sb.Append(ConvertToInvariantString(value));
            }

            return sb.ToString();
        }

        private static string ConvertToInvariantString(object value)
        {
            return value switch
            {
                null => "null",
                IFormattable f => f.ToString(null, CultureInfo.InvariantCulture),
                _ => value.ToString() ?? string.Empty
            };
        }
    }
}