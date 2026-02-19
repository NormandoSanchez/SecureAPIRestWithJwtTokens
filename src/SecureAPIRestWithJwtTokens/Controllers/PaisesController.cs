using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Exceptions;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Models.Responses;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Controllers;
/// <summary>
/// Controller para gestionar operaciones relacionadas con países.
/// </summary>
/// <remarks>
/// Ncesita autorización para acceder a sus endpoints.
/// </remarks>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PaisesController(IGenericService<PaisDto> paisService, 
                              IMemoryCache memoryCache,
                              ApiConfiguration configuration) : ControllerBase
{
    private readonly IGenericService<PaisDto> _paisService = paisService;
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly ApiConfiguration _configuration = configuration;

    /// GET: api/Paises
    /// <summary>
    /// Obtiene la lista de todos los países.
    /// </summary>
    /// <returns>Respuesta exitosa con código 200 OK y la lista de países.</returns>
    /// <response code="200">Operación exitosa. Lista de países recuperada.</response>
    /// <remarks>
    /// Ejemplo:\
    /// GET api/Paises \
    /// Devuelve la lista de todos los países.
    /// </remarks>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<PaisDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        // Aplicar Response Cache dinámicamente según configuración
        ResponseCacheHelper.SetResponseCacheHeaders(
                Response,
                _configuration.CacheSettings.ResponseCache.SlowChangeDataDurationSeconds);

        var paises = await GetAllPaisesFromCacheAsync();

        var response = ApiResponseBuilder.Success(paises, 
                                                    $"{EntitiesConstants.PAISES} {GenericConstants.RESPONSE_EXITO_PLURAL_MASCULINO}");
        return Ok(response);
    }

    /// GET: api/Paises/{id}
    /// <summary>
    /// Obtiene la información de un país por su identificador.
    /// </summary>
    /// <param name="id">Identificador del país.</param>
    /// <returns>Retorna 200 OK si el país existe, o 404 Not Found si no se encuentra.</returns>
    /// <response code="200">Operación exitosa. País encontrado.</response>
    /// <response code="404">No se encontró el país con el identificador proporcionado.</response>
    /// <remarks>
    /// Ejemplo:\
    /// GET api/Paises/1 \
    /// Devuelve la información del país con ID 1.
    /// </remarks>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<PaisDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    //[ProcesoAuthorize("30200000", "30200020")] // 
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        // Aplicar Response Cache dinámicamente
        ResponseCacheHelper.SetResponseCacheHeaders(
            Response,
            _configuration.CacheSettings.ResponseCache.SlowChangeDataDurationSeconds);

        var pais = await GetPaisByIdFromCacheAsync(id);

        var response = ApiResponseBuilder.Success(pais, 
                                                  $"{EntitiesConstants.PAIS} {GenericConstants.RESPONSE_EXITO_SINGULAR_MASCULINO}");

        return Ok(response);
    }

#region Métodos privados
    private async Task<List<PaisDto>> GetAllPaisesFromCacheAsync()
    {
        var baseKey = string.Join("_", CacheConstants.CACHE_KEY_PAIS, CacheConstants.CACHE_KEY_ALL);

        if (!_memoryCache.TryGetValue(baseKey, out List<PaisDto>? paises))
        {
            paises = await _paisService.GetAllAsync();

            var cacheOptions = MemoryCacheHelper.CreateSlowChangeDataCacheOptions(_configuration);
            _memoryCache.Set(baseKey, paises, cacheOptions);
        }

        return paises!;
    }

    private async Task<PaisDto> GetPaisByIdFromCacheAsync(int id)
    {
        var baseKey = string.Join("_", CacheConstants.CACHE_KEY_PAIS, id);

        if (!_memoryCache.TryGetValue(baseKey, out PaisDto? pais))
        {
            pais = await _paisService.GetByIdAsync(id) ?? throw new SimpleNotFoundException(EntitiesConstants.PAISES, id);

            var cacheOptions = MemoryCacheHelper.CreateSlowChangeDataCacheOptions(_configuration);
            _memoryCache.Set(baseKey, pais, cacheOptions);
        }

        return pais!;
    }
#endregion
}