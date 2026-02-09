using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Tools
{
    /// <summary>
    /// Helper para obtener y desencriptar la cadena de conexión desde appsettings.json
    /// </summary>
    public class ConnectionStringHelper(ICryptoGraphicService cryptoService)
    {
        private readonly ICryptoGraphicService _cryptoService = cryptoService;

        /// <summary>
        /// Recupera y desencripta la cadena de conexión para el contexto especificado
        /// </summary>
        /// <returns>Cadena de conexión desencriptada</returns>
        public async Task<string?> GetDecriptedConnectionStringOfContext()
        {
            string dbPassword = Environment.GetEnvironmentVariable(EnvironmentConstants.DB_PASSWORD) ?? string.Empty;
            string dbConnectionString = Environment.GetEnvironmentVariable(EnvironmentConstants.DB_STRING_CONNECTION) ?? string.Empty;
            if (!string.IsNullOrEmpty(dbPassword) && !string.IsNullOrEmpty(dbConnectionString))
            {
                var decryptedPassword = await _cryptoService.DecriptAsync(dbPassword);
                dbConnectionString = dbConnectionString.Replace("${DB_PASSWORD}", decryptedPassword);
                return dbConnectionString;
            }
            
            return null;
        }
    }

    /// <summary>
    /// Funciones comunes de utilidad
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Determina si un filtro en un diccionario es nulo o vacío
        /// </summary>
        /// <param name="dic">Diccionario con los filtros</param>
        /// <param name="key">Clave que debe contener</param>
        /// <param name="nullValue">Valor nulo a comparar</param>
        /// <returns></returns>
        public static bool IsFilterEmptyOrNull(IDictionary<string, object>? dic, string key, string nullValue = "")
        {
            if (dic != null && dic.TryGetValue(key, out object? value) && value != null)
            {
                if (nullValue == "")
                {
                    return string.IsNullOrWhiteSpace(value.ToString());
                }
                else
                {
                    return value.ToString() == nullValue;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Parsea un filtro booleano desde un diccionario de filtros
        /// </summary>
        /// <param name="filtros"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ParseBoolFilter(IDictionary<string, object>? filtros, string key, bool defaultValue)
        {
            if (filtros == null)
                return defaultValue;
            if (!IsFilterEmptyOrNull(filtros, key, defaultValue.ToString()) &&
                bool.TryParse(filtros[key].ToString(), out bool result))
            {
                return result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Parsea un filtro entero desde un diccionario de filtros
        /// </summary>
        /// <param name="filtros"></param>
        /// <param name="key"></param>  
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ParseIntFilter(IDictionary<string, object>? filtros, string key, int defaultValue)
        {
            if (filtros == null)
                return defaultValue;
            if (!IsFilterEmptyOrNull(filtros, key, defaultValue.ToString()) &&
                int.TryParse(filtros[key].ToString(), out int retvalue))
            {
                return retvalue;
            }

            return defaultValue;
        }

        /// <summary>
        /// Parsea un filtro string desde un diccionario de filtros
        /// </summary>
        /// <param name="filtros"></param>
        /// <param name="key"></param>  
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string? ParseStringFilter(IDictionary<string, object>? filtros, string key, string defaultValue = "")
        {
            if (filtros == null)
                return defaultValue;
            if (!IsFilterEmptyOrNull(filtros, key, defaultValue))
            {
                var value = filtros[key]?.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
            }
            return defaultValue;
        }
    }
}
