using Microsoft.Data.SqlClient;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Tools;

/// <summary>
/// Helper para obtener y desencriptar la cadena de conexión desde appsettings.json
/// </summary>
public class ConnectionStringHelper(ICryptoGraphicService cryptoService)
{
    private readonly ICryptoGraphicService _cryptoService = cryptoService;

    /// <summary>
    /// Recupera y desencripta la cadena de conexión para el contexto principal (TrebolDbContext)
    /// </summary>
    /// <returns>Cadena de conexión desencriptada</returns>
    public async Task<string?> GetDecriptedConnectionStringOfContext()
    {
        return await GetConnectionString(
            EnvironmentConstants.DB_PASSWORD,
            EnvironmentConstants.DB_STRING_CONNECTION,
            EnvironmentConstants.DB_PASSWORD_TOKEN);
    }

    public async Task<FarmaciaDBConnectionInternal?> GetComunDBConnection()
    {
        var connectionString = await GetDecriptedConnectionStringOfComun();
        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            var dbConnection = new FarmaciaDBConnectionInternal
            {
                Server = builder.DataSource,
                DataBase = builder.InitialCatalog,
                User = builder.UserID,
                EncriptedPassword = builder.Password 
            };
            return dbConnection;
        }
        return null;
    }

    /// <summary>
    /// Recupera y desencripta la cadena de conexión para la conexión a común 
    /// </summary>
    /// <returns>Cadena de conexión desencriptada</returns>
    public async Task<string?> GetDecriptedConnectionStringOfComun()
    {
        return await GetConnectionString(
            EnvironmentConstants.DBCOMUN_PASSWORD,
            EnvironmentConstants.DBCOMUN_STRING_CONNECTION,
            EnvironmentConstants.DB_COMUN_PASSWORD_TOKEN,
            false);
    }

    /// <summary>
    /// Método privado común para obtener y procesar la cadena de conexión desde variables de entorno,
    /// con opción de desencriptar la contraseña o no
    /// opción de desencriptar la contraseña o no (para casos como la conexión común donde no se desencripta)
    /// </summary>
    /// <param name="passwordEnvKey">Clave de la variable de entorno para la contraseña</param>
    /// <param name="connectionStringEnvKey">Clave de la variable de entorno para la cadena de conexión</param>
    /// <param name="passwordToken">Token en la cadena de conexión que se reemplazará por la contraseña</param>
    /// <param name="decryptPassword">Indica si se debe desencriptar la contraseña (true por defecto)</param>
    /// <returns>Cadena de conexión procesada o null si falta información</returns>
    private async Task<string?> GetConnectionString(
        string passwordEnvKey,
        string connectionStringEnvKey,
        string passwordToken,
        bool decryptPassword = true)
    {
        string dbPassword = Environment.GetEnvironmentVariable(passwordEnvKey) ?? string.Empty;
        string dbConnectionString = Environment.GetEnvironmentVariable(connectionStringEnvKey) ?? string.Empty;
        if (string.IsNullOrEmpty(dbPassword) || string.IsNullOrEmpty(dbConnectionString))
        {
            return null;
        }

        var decryptedPassword = decryptPassword ? await _cryptoService.DecriptAsync(dbPassword) : dbPassword;

        return dbConnectionString.Replace(passwordToken, decryptedPassword);
    }
}