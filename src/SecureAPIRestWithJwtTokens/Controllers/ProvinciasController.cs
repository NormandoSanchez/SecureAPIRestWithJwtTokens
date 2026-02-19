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

namespace SecureAPIRestWithJwtTokens.Controllers
{
    /// <summary>
    /// Controlador para gestionar las provincias
    /// </summary>
    /// <remarks>
    /// Necesita autorización para acceder a sus endpoints. 
    /// </remarks>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinciasController(IGenericService<ProvinciaDto> provinciaService,
                                      IMemoryCache memoryCache,
                                      ApiConfiguration configuration) : ControllerBase
    {
        private readonly IGenericService<ProvinciaDto> _provinciaServ = provinciaService;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly ApiConfiguration _configuration = configuration;
        /// <summary>
        /// Obtiene la lista de todas las provincias
        /// </summary>
        /// <param name="pais">Identificador de País</param>
        /// <param name="comunidadAut">Identificador de ComunidadAut</param>
        /// <param name="clickCollect">Indicador de Click&amp;Collect</param>
        /// <Returns>Retorna 200 OK con la lista de provincias</Returns>
        /// <response code="200">Operación exitosa. Lista de provincias encontrada.</response>
        /// <response code="404">No se encontraron provincias.</response>
        /// <remarks>
        /// Ejemplo:\
        /// GET api/Provincias \
        /// Devuelve la lista de todas las provincias existentes.\
        /// \
        /// GET api/Provincias?Pais=1 \
        /// Devuelve la lista de provincias filtradas por el país con ID 1.\
        /// \
        /// GET api/Provincias?ComunidadAut=2 \
        /// Devuelve la lista de provincias filtradas por la comunidad autónoma con ID 2.\
        /// No es necesario especificar el país si se filtra por comunidad autónoma. Se ignora\
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<ProvinciaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] int? pais = null, [FromQuery] int? comunidadAut = null,
                                                [FromQuery] bool? clickCollect = null)
        {
            // Aplicar Response Cache dinámicamente según configuración
            ResponseCacheHelper.SetResponseCacheHeadersWithVary(
                 Response,
                 _configuration.CacheSettings.ResponseCache.SlowChangeDataDurationSeconds,
                 varyByQueryKeys: "pais, comunidadAut, clickCollect");

            var provincias = await GetProvinciasFromCacheAsync(pais, comunidadAut, clickCollect);

            var response = ApiResponseBuilder.Success(provincias, $"{EntitiesConstants.PROVINCIAS} {GenericConstants.RESPONSE_EXITO_PLURAL_FEMENINO}");

            return Ok(response);
        }

        /// <summary>
        /// Obtiene una provincia por su identificador
        /// </summary>
        /// <param name="id">Identificador de la provincia</param>
        /// <returns>Retorna 200 OK con la provincia encontrada</returns>
        /// <response code="200">Operación exitosa. Provincia encontrada.</response>
        /// <response code="404">No se encontró la provincia.</response>
        /// <remarks>
        /// Ejemplo:
        /// GET api/Provincias/1
        /// Devuelve la provincia con ID 1.
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ProvinciaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // Aplicar Response Cache dinámicamente
            ResponseCacheHelper.SetResponseCacheHeadersWithVary(
                Response,
                _configuration.CacheSettings.ResponseCache.SlowChangeDataDurationSeconds,
                varyByQueryKeys: "id");

            var provincia = await GetProvinciaByIdFromCacheAsync(id);

            var response = ApiResponseBuilder.Success(provincia, $"{EntitiesConstants.PROVINCIA} {GenericConstants.RESPONSE_EXITO_SINGULAR_FEMENINO}");

            return Ok(response);
        }

        #region Métodos privados
        private async Task<List<ProvinciaDto>> GetProvinciasFromCacheAsync(int? pais, int? comunidadAut, bool? clickCollect)
        {
            var filtros = new Dictionary<string, object>();
            if (pais != null) filtros.Add(FilterConstants.PAIS, pais.Value);
            if (comunidadAut != null) filtros.Add(FilterConstants.COMUNIDADAUT, comunidadAut.Value);
            if (clickCollect != null) filtros.Add(FilterConstants.CLICK_COLLECT, clickCollect.Value);

            string baseKey = string.Join("_", CacheConstants.CACHE_KEY_PROVINCIA, CacheConstants.CACHE_KEY_ALL);
            if (pais != null)
            {
                baseKey += "_" + string.Join("_", CacheConstants.CACHE_KEY_PAIS, pais.Value);
            }
            else if (comunidadAut != null)
            {
                baseKey += "_" + string.Join("_", CacheConstants.CACHE_KEY_COMAUT, comunidadAut.Value);
            }
            else if (clickCollect != null)
            {
                baseKey += "_" + string.Join("_", CacheConstants.CACHE_KEY_CLICK_COLLECT, clickCollect.Value);
            }

            var cacheKey = CacheKeyHelper.BuildKey(baseKey, filtros.Count > 0 ? filtros : null);

            if (!_memoryCache.TryGetValue(cacheKey, out List<ProvinciaDto>? provincias))
            {
                provincias = await _provinciaServ.GetAllAsync(filtros.Count > 0 ? filtros : null) ?? throw new SimpleNotFoundException(EntitiesConstants.PROVINCIAS);

                var cacheOptions = MemoryCacheHelper.CreateSlowChangeDataCacheOptions(_configuration);
                _memoryCache.Set(cacheKey, provincias, cacheOptions);
            }

            return provincias!;
        }

        private async Task<ProvinciaDto> GetProvinciaByIdFromCacheAsync(int id)
        {
            var baseKey = string.Join("_", CacheConstants.CACHE_KEY_PROVINCIA, id);

            if (!_memoryCache.TryGetValue(baseKey, out ProvinciaDto? provincia))
            {
                provincia = await _provinciaServ.GetByIdAsync(id) ?? throw new SimpleNotFoundException(EntitiesConstants.PROVINCIAS, id);

                var cacheOptions = MemoryCacheHelper.CreateSlowChangeDataCacheOptions(_configuration);
                _memoryCache.Set(baseKey, provincia, cacheOptions);
            }

            return provincia!;
        }
        #endregion
    }
}
