# Ejemplos de uso

## Ejemplo de uso del SqlDataService en un controlador API una conexion a base de datos de farmacia

```csharp
using FarmaciasTrebolERP.API.Models.Internal;
using FarmaciasTrebolERP.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FarmaciasTrebolERP.API.Controllers;
    
[ApiController]
[Route("api/[controller]")]
public class FarmaciaDataController : ControllerBase
{
    private readonly ISqlDataServiceFactory _sqlFactory;
    private readonly ILogger<FarmaciaDataController> _logger;

    public FarmaciaDataController(
           ISqlDataServiceFactory sqlFactory,
           ILogger<FarmaciaDataController> logger)
    {
        _sqlFactory = sqlFactory;
        _logger = logger;
    }

    [HttpGet("productos/{farmaciaId}")]
    public async Task<IActionResult> GetProductosFarmacia(int farmaciaId)
    {
        // Crear una instancia del servicio
        await using var sqlService = _sqlFactory.CreateService();

        try
        {
            // Obtener datos de conexión de la farmacia (ejemplo)
            var connectionInfo = new FarmaciaDBConnectionInternal
            {
                Server = "192.168.1.100",
                DataBase = $"Farmacia_{farmaciaId}",
                User = "appuser",
                EncriptedPassword = "passwordEncriptado123"
            };

            // Establecer conexión
           await sqlService.GetConnection(connectionInfo);

            // Ejecutar consulta
            var query = "SELECT Id, Nombre, Precio FROM Productos WHERE Activo = @Activo";
            var parameters = new Dictionary<string, object>
            {
                { "Activo", 1 }
            };

            var result = await sqlService.ExecuteQueryAsync(
                query,
                CommandType.Text,
                parameters: parameters);

            return Ok(new
                {
                    FarmaciaId = farmaciaId,
                    TotalProductos = result.Rows.Count,
                    Productos = result // Puedes convertir a lista de objetos
                });
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "Error obteniendo productos de farmacia {FarmaciaId}", farmaciaId);
            return StatusCode(500, "Error al obtener datos de la farmacia");
        }
        // ← sqlService se dispone automáticamente aquí (await using)
    }
}
```

## Ejemplo de uso avanzado: Consultar múltiples origenes en paralelo

```csharp
[HttpGet("inventario-consolidado")]
public async Task<IActionResult> GetInventarioConsolidado([FromQuery] int[] farmaciasIds)
{
    if (farmaciasIds == null || farmaciasIds.Length == 0)
    {
        return BadRequest("Debe especificar al menos una farmacia");
    }

    try
    {
        // Crear tareas para consultar múltiples farmacias en paralelo
        var tasks = farmaciasIds.Select(async farmaciaId =>
        {
            // Cada tarea crea su propia instancia de SqlDataService
            await using var sqlService = _sqlFactory.CreateService();

            var connectionInfo = new FarmaciaDBConnectionInternal
            {
                Server = "192.168.1.100",
                DataBase = $"Farmacia_{farmaciaId}",
                User = "appuser",
                EncriptedPassword = "passwordEncriptado123"
            };

            await sqlService.GetConnection(connectionInfo);

            var query = "SELECT COUNT(*) as TotalProductos FROM Productos WHERE Stock > 0";
            var result = await sqlService.ExecuteQueryAsync(query, CommandType.Text);

            return new
            {
                FarmaciaId = farmaciaId,
                TotalProductos = result.Rows.Count > 0 ? Convert.ToInt32(result.Rows[0]["TotalProductos"]) : 0
            };
        });

        // Ejecutar todas las consultas en paralelo
        var resultados = await Task.WhenAll(tasks);

        return Ok(new
        {
            TotalFarmacias = farmaciasIds.Length,
            Inventario = resultados
        });
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error obteniendo inventario consolidado");
        return StatusCode(500, "Error al obtener inventario");
    }
}
