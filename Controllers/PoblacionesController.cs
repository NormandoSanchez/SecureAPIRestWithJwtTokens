using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Exceptions;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Models.Responses;
using SecureAPIRestWithJwtTokens.Services;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace SecureAPIRestWithJwtTokens.Controllers
{
    /// <summary>
    /// Controlador para gestionar las poblaciones
    /// </summary>
    /// <remarks>
    /// Necesita autorización para acceder a sus endpoints.
    /// </remarks>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PoblacionesController(IGenericService<PoblacionDto> poblacionService,
                                       IMemoryCache memoryCache,
                                       ApiConfiguration configuration) : ControllerBase
    {
        private readonly IGenericService<PoblacionDto> _poblacionServ = poblacionService;
        private readonly IMemoryCache _cache = memoryCache;
        private readonly ApiConfiguration _configuration = configuration;
        /// <summary>
        /// Obtiene la lista de todas las poblaciones
        /// </summary>
        /// <param name="pais">Identificador de País</param>
        /// <param name="provincia">Identificador de Provincia</param>
        /// <Returns>Retorna 200 OK con la lista de poblaciones</Returns>
        /// <response code="200">Operación exitosa. Lista de poblaciones encontrada.</response>
        /// <response code="404">No se encontraron poblaciones</response>
        /// <remarks>
        /// Ejemplo:\
        /// GET api/Poblaciones \
        /// Devuelve la lista de todas las poblaciones.\
        /// \
        /// GET api/Poblaciones?Provincia=2 \
        /// Devuelve la lista de poblaciones filtradas por la provincia con ID 2.\
        /// No es necesario especificar el país si se filtra por provincia. Se ignora\
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<PoblacionDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] int? pais = null, [FromQuery] int? provincia = null)
        {
            // Aplicar Response Cache dinámicamente según configuración
            ResponseCacheHelper.SetResponseCacheHeadersWithVary(
                 Response,
                 _configuration.CacheSettings.ResponseCache.SlowChangeDataDurationSeconds,
                 varyByQueryKeys: "Pais, Provincia");

            var filtros = new Dictionary<string, object>();

            if (pais != null) filtros.Add(FilterConstants.PAIS, pais.Value); 
            if (provincia != null) filtros.Add(FilterConstants.PROVINCIA, provincia.Value);
            
            var baseKey = string.Join("_", EntitiesConstants.POBLACIONES, CacheConstants.CACHE_KEY_ALL);
            var cacheKey = CacheKeyHelper.BuildKey(baseKey, filtros.Count > 0 ? filtros : null);

            if (!_cache.TryGetValue(cacheKey, out List<PoblacionDto>? poblaciones))
            {
                poblaciones = await _poblacionServ.GetAllAsync(filtros) ?? throw new SimpleNotFoundException(EntitiesConstants.POBLACIONES);

                // Configuracion Memory Cache
                var cacheOptions = MemoryCacheHelper.CreateSlowChangeDataCacheOptions(_configuration);
                _cache.Set(cacheKey, poblaciones, cacheOptions);
            }   

            var response = ApiResponseBuilder.Success(poblaciones, $"{EntitiesConstants.POBLACIONES} {GenericConstants.RESPONSE_EXITO_PLURAL_FEMENINO}");

            return Ok(response);
        }

        /// <summary>
        /// Obtiene la información de una población por su identificador.
        /// </summary>
        /// <param name="id">Id de la población</param>
        /// <returns>PoblacionResponse</returns>
        /// <exception cref="SimpleNotFoundException">No se encontró la población con ID {id}.</exception>
        /// <remarks>
        /// Ejemplo:\
        /// GET api/Poblaciones/1 \
        /// Devuelve la información de la población con ID 1.
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<PoblacionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // Aplicar Response Cache dinámicamente
            ResponseCacheHelper.SetResponseCacheHeadersWithVary(
                Response,
                _configuration.CacheSettings.ResponseCache.SlowChangeDataDurationSeconds,
                varyByQueryKeys: "id");

            var baseKey = string.Join("_", EntitiesConstants.POBLACIONES, id);

            if (!_cache.TryGetValue(baseKey, out PoblacionDto? poblacion))
            {
                poblacion = await _poblacionServ.GetByIdAsync(id) ?? throw new SimpleNotFoundException(EntitiesConstants.POBLACIONES, id);
                // Configuracion Memory Cache
                var cacheOptions = MemoryCacheHelper.CreateSlowChangeDataCacheOptions(_configuration);
                _cache.Set(baseKey, poblacion, cacheOptions);
            }

            var response = ApiResponseBuilder.Success(poblacion, $"{EntitiesConstants.POBLACION} {GenericConstants.RESPONSE_EXITO_SINGULAR_FEMENINO}");

            return Ok(response);
        }
    }
}
