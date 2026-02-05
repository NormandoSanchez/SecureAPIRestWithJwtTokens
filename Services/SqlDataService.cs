using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using Microsoft.Data.SqlClient;
using System.Data;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Services;

/// <summary>
/// Factory para crear instancias de SqlDataService.
/// </summary>
public class SqlDataServiceFactory(
    ApiConfiguration configuration,
    ICryptoGraphicService cryptoService,
    ICircuitBreakerService circuitBreakerService) : ISqlDataServiceFactory
{
    private readonly ApiConfiguration _configuration = configuration;
    private readonly ICryptoGraphicService _cryptoService = cryptoService;
    private readonly ICircuitBreakerService _circuitBreakerService = circuitBreakerService;

    /// <summary>
    /// Crea una nueva instancia de SqlDataService con dependencias resueltas.
    /// </summary>
    public ISqlDataService CreateService()
    {
        return new SqlDataService(_configuration, _cryptoService, _circuitBreakerService);
    }
}

/// <summary>
/// Crea una nueva instancia de SqlDataService con dependencias resueltas.
/// </summary>
/// <param name="configuration">Configuración de la API.</param>
/// <param name="cryptoService">Servicio de criptografía.</param>
/// <param name="circuitBreakerService">Servicio de Circuit Breaker.</param>
public class SqlDataService(
    ApiConfiguration configuration,
    ICryptoGraphicService cryptoService,
    ICircuitBreakerService circuitBreakerService) : ISqlDataService
{
    private readonly ApiConfiguration _configuration = configuration;
    private readonly ICryptoGraphicService _cryptoService = cryptoService;
    private readonly ICircuitBreakerService _circuitBreakerService = circuitBreakerService;
    
    private SqlConnection? _connection;
    private bool _disposed = false;
    public string? ServerName { get; private set; }
    public string? DbName { get; private set; }

    /// <summary>
    /// Obtiene una conexión a la base de datos de la farmacia.
    /// </summary>
    /// <param name="connectionInfo">Información de conexión a la base de datos.</param>
    /// <param name="timeout">Tiempo de espera para la conexión en segundos.</param>
    /// <returns>True si la conexión se establece correctamente; de lo contrario, false.</returns>
    public async Task<bool> GetConnection(FarmaciaDBConnectionInternal connectionInfo, int timeout = DefaultConstants.DBCONNECTIONTIMEOUT)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        ServerName = connectionInfo.Server;
        DbName = connectionInfo.DataBase;
        string _serverKey = $"{ServerName}/{DbName}";

        var circuitBreaker = _circuitBreakerService.GetCircuitBreaker(_serverKey);

        // Ejecuta la lógica de conexión a través de la política de Circuit Breaker.
        await circuitBreaker.ExecuteAsync(async () =>
        {
            string decryptedPassword = await _cryptoService.DecriptAsync(connectionInfo.EncriptedPassword);
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ServerName,
                UserID = connectionInfo.User,
                Password = decryptedPassword,
                InitialCatalog = DbName,
                ConnectTimeout = DefaultConstants.DBCONNECTIONTIMEOUT,
                ApplicationName = _configuration.PropiedadesApi.DBAppName,
                MultipleActiveResultSets = true,
                TrustServerCertificate = true,
                Pooling = true,
                MaxPoolSize = 100
            };
            _connection = new SqlConnection(builder.ConnectionString);
            await _connection.OpenAsync();
        });

        return _connection?.State == ConnectionState.Open;
    }

    /// <summary>
    /// Ejecuta una consulta SQL y devuelve los resultados en un DataTable.
    /// </summary>
    /// <param name="query">Consulta SQL a ejecutar.</param>
    /// <param name="tipo">Tipo de comando SQL.</param>
    /// <param name="longTimeOut">Indica si se debe usar un tiempo de espera prolongado.</param>
    /// <param name="parameters">Parámetros de la consulta.</param>
    /// <returns></returns>
    public async Task<DataTable> ExecuteQueryAsync(string query, CommandType tipo, bool longTimeOut = false, Dictionary<string, object>? parameters = null)
    {
        ValidateConnection();
        var dataTable = new DataTable();

        using var command = SetSqlCommand(query, longTimeOut, tipo, parameters);
        using var reader = await command.ExecuteReaderAsync();

        var schemaTable = await reader.GetSchemaTableAsync();
        if (schemaTable != null)
        {
            foreach (DataRow row in schemaTable.Rows)
            {
                dataTable.Columns.Add(row["ColumnName"].ToString(), (Type)row["DataType"]);
            }
        }

        while (await reader.ReadAsync())
        {
            var dataRow = dataTable.NewRow();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dataRow[i] = await reader.IsDBNullAsync(i) ? DBNull.Value : reader.GetValue(i);
            }
            dataTable.Rows.Add(dataRow);
        }

        return dataTable;
    }

    /// <summary>
    /// Ejecuta una consulta SQL que no devuelve resultados (INSERT, UPDATE, DELETE).
    /// </summary>
    /// <param name="query">Consulta SQL a ejecutar.</param>
    /// <param name="tipo">Tipo de comando SQL.</param>
    /// <param name="longTimeOut">Indica si se debe usar un tiempo de espera prolongado.</param>
    /// <param name="parameters">Parámetros de la consulta. </param>
    /// <returns></returns>
    public async Task<int> ExecuteNonQueryAsync(string query, CommandType tipo, bool longTimeOut = false, Dictionary<string, object>? parameters = null)
    {
        ValidateConnection();
        using var command = SetSqlCommand(query, longTimeOut, tipo, parameters);
        
        return await command.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Establece un SqlCommand con los parámetros indicados.
    /// </summary>
    /// <param name="query">Consulta SQL a ejecutar.</param>
    /// <param name="longTimeOut">Indica si se debe usar un tiempo de espera prolongado.</param>
    /// <param name="tipo">Tipo de comando SQL.</param>
    /// <param name="parameters">Parámetros de la consulta.</param>
    /// <returns></returns>
    public SqlCommand SetSqlCommand(string query, bool longTimeOut, CommandType tipo, Dictionary<string, object>? parameters = null)
    {
        ValidateConnection();
        var command = new SqlCommand(query, _connection);
        if (longTimeOut)
        {
            command.CommandTimeout = DefaultConstants.DBCOMMANDLONGTIMEOUT;
        }
        command.CommandType = tipo;
        if (parameters != null)
        {
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue($"@{param.Key}", param.Value ?? DBNull.Value);
            }
        }
        return command;
    }

    /// <summary>
    /// Valida que la conexión esté activa.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    private void ValidateConnection()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            throw new InvalidOperationException("No hay una conexión activa. Llame primero a GetConnection().");
        }
    }

    /// <summary>
    /// Dispose asíncrono del servicio.
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;
        if (_connection != null)
        {
            await _connection.DisposeAsync();
        }
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}