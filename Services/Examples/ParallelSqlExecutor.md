# Ejemplo de uso de ParallelSqlExecutor

```
using FarmaciasTrebolERP.API.Models.Internal;
using FarmaciasTrebolERP.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmaciasTrebolERP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MultiServerQueryController : ControllerBase
{
    private readonly IParallelSqlExecutor _parallelSqlExecutor;

    public MultiServerQueryController(IParallelSqlExecutor parallelSqlExecutor)
    {
        _parallelSqlExecutor = parallelSqlExecutor;
    }
```

    /// <summary>
    /// Ejecuta una consulta SELECT en una lista de servidores de forma paralela y resiliente.
    /// </summary>
    /// <param name="request">Contiene la lista de conexiones y la consulta a ejecutar.</param>
    /// <returns>Un resumen estadístico y los datos de las ejecuciones exitosas.</returns>
    [HttpPost("execute-query")]
    public async Task<IActionResult> ExecuteQuery([FromBody] MultiServerQueryRequest request)
    {
        if (request.Connections == null || !request.Connections.Any())
        {
            return BadRequest("La lista de conexiones no puede estar vacía.");
        }

        var summary = await _parallelSqlExecutor.ExecuteOnMultipleServersAsync(
                    request.Connections,
                    request.Query,
                    request.Parameters);

        // Devolucion datos. Ojo al devolver los resultados de cada servidor, puede ser mucha información. 
        var response = new
        {
            Summary = new
            {
                summary.Results.Where(r => r.Success),  // Devolvemos los datos completos solo para los resultados exitosos 
                summary.TotalServers,
                summary.SuccessCount,
                summary.FailureCount,
                summary.CircuitBreakerRejections,
                summary.SuccessRate,
                    TotalExecutionTime = summary.TotalExecutionTime.ToString("g")
            },
            SuccessfulResults = summary.Results.Where(r => r.Success).Select(r => new { r.ServerKey, RowCount = r.Data?.Rows.Count, ExecutionTime = r.ExecutionTime.ToString("g") }),
                FailedResults = summary.Results.Where(r => !r.Success).Select(r => new { r.ServerKey, r.ErrorMessage, ExecutionTime = r.ExecutionTime.ToString("g") })
        };
 
        return Ok(response);
    }
}
