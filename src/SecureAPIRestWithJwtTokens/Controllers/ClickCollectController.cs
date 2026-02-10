using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Responses;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Controllers;

/// <summary>
/// Controlador para recuperar stock de farmacias Click &amp; Collect 
/// Este EndPoint es público y no requiere autenticación. El sistema que lo consume asi lo requiere.  
/// </summary>
[Route("api/[controller]")]
[AllowAnonymous]
[Produces("application/json")]      
public class ClickCollectController(IStockFarmaciaCCResultService stockFarmaciaCCResultService) : ControllerBase
{
    private readonly IStockFarmaciaCCResultService _stockFarmaciaCCResultService = stockFarmaciaCCResultService;

    // GET: api/StockFarmacia
    /// <summary>
    /// Obtiene una Lista de Farmacias donde los articulos tengan el stock indicado 
    /// </summary>
    /// <param name="arts">Lista de CN separados por |</param>
    /// <param name="uds">Lista de unidades stock minimas separadas por |</param>
    /// <param name="farmaini">Identificador de farmacia donde buscar, segun Comun.totalFarmacias. 0000 para todas. Usar /farmaciasCC para recuperarlas</param>
    /// <returns>Respuesta exitosa con código 200 OK y la lista de farmacias.</returns>
    /// <response code="200">List of StockFarmaciaResponse</response>
    /// <response code="422">Validation errors</response>
    /// <remarks>
    /// Ejemplos de llamada (Devuelve una lista de farmacias C&amp;C con un indicador en funcion de tener o superar el stock indicado de cada articulo) \
    /// \
    /// GET /stockFarmacia/000001|000002/1|2/0000 \
    /// Devuelve farmacias C&amp;C que tengan al menos 1 unidad de stock del articulo 000001 y 2 del 000002 con indicador SI \
    /// el resto de farmacias con indicador NO\
    /// \
    /// GET /stockFarmacia/000001|000002/1|2/0003 \
    /// Devuelve la farmacia de Betanzos con indicador  SI si tiene al menos 1 unidad de stock del articulo 000001 y 2 del 000002 \
    /// En caso contrario indicador NO 
    /// \
    /// ¡¡IMPORTANTE!! Por compatibilidad con versiones anteriores mantenemos el endpoint /api/stockFarmacia/{arts}/{uds}/{farmaini}
    /// </remarks>
    [HttpGet("StockFarmacia/{arts}/{uds}/{farmaini}")]
    [ProducesResponseType(typeof(ApiResponse<List<StockFarmaciaDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetStockFarmaciasCC(
        [FromRoute] string arts,
        [FromRoute] string uds,
        [FromRoute] string farmaini)
    {
        ResponseCacheHelper.DisableCache(Response);

        // Crear el objeto request para validación
        var request = new StockFarmaciaCCRequest
        {
            Arts = arts,
            Uds = uds,
            FarmaIni = farmaini
        };

        var validationResults = ValidateRequest(request);

        // Si hay errores, retornar BadRequest
        if (validationResults.Count > 0)
        {
            var errors = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
            throw new ValidationException(errors);
        }

        Dictionary<string, object> filtros = new()
        {
            { FilterConstants.ARTICULOS, arts },
            { FilterConstants.UDS, uds },
            { FilterConstants.FARMAINI, farmaini }
        };

        var stockFarmaciasCC = await _stockFarmaciaCCResultService.GetAllAsync(filtros);

        var response = ApiResponseBuilder.Success(stockFarmaciasCC, $"{EntitiesConstants.FARMACIAS} {GenericConstants.RESPONSE_EXITO_PLURAL_FEMENINO}");

        return Ok(response);
    }

    private static List<ValidationResult> ValidateRequest(StockFarmaciaCCRequest request)
    {
        // Validar manualmente el modelo
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(request);

        // Validar atributos
        bool isValid = Validator.TryValidateObject(request, validationContext, validationResults, validateAllProperties: true);

        // Validar lógica personalizada (IValidatableObject)
        if (isValid)
        {
            var customValidations = request.Validate(validationContext);
            validationResults.AddRange(customValidations);
        }

        return validationResults;
    }
}

