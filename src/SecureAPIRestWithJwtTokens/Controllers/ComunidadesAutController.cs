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
    /// Controller para gestionar operaciones relacionadas con Comunidades Aut.
    /// </summary>
    /// <remarks>
    /// Ncesita autorización para acceder a sus endpoints.
    /// </remarks>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ComunidadesAutController(IGenericService<ComunidadAutDto> comunidadAutService,
                                          IMemoryCache memoryCache,
                                          ApiConfiguration configuration) : ControllerBase
    {
        private readonly IGenericService<ComunidadAutDto> _comunidadAutServ = comunidadAutService;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly ApiConfiguration _configuration = configuration;
        /// GET: api/ComunidadesAut
        /// <summary>
        /// Obtiene la lista de todas las Comunidades Autónomas.
        /// </summary>
        /// <param name="pais">ID del país al que pertenecen las comunidades autónomas.</param>
        /// <Returns>Retorna 200 OK con la lista de países</Returns>
        /// <response code="200">Operación exitosa. Lista de comunidades encontrada.</response>
        /// <response code="404">No se encontraron Comunidades Aut.</response>
        /// <remarks>
        /// Ejemplos:\
        /// GET api/ComunidadesAut \
        /// Devuelve la lista de todas las comunidades autónomas existentes.\ 
        /// \
        /// GET api/ComunidadesAut?Pais=1 \
        /// Devuelve la lista de comunidades autónomas filtradas por el país con ID 1.
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<ComunidadAutDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] int? pais  = null)
        {
            // Aplicar Response Cache dinámicamente según configuración
            ResponseCacheHelper.SetResponseCacheHeadersWithVary(
                 Response,
                 _configuration.CacheSettings.ResponseCache.SlowChangeDataDurationSeconds,
                 varyByQueryKeys: "pais");

            var comunidades = await GetComunidadesFromCacheAsync(pais);

            var response = ApiResponseBuilder.Success(comunidades, $"{EntitiesConstants.COMUNIDADESAUT} {GenericConstants.RESPONSE_EXITO_PLURAL_FEMENINO}");

            return Ok(response);
        }

        /// GET: api/ComunidadesAut/{id}
        /// <summary>
        /// Obtiene la información de una comunidad aut. por su identificador.
        /// </summary>
        /// <param name="id">Identificador de comunidad.</param>
        /// <returns>Retorna 200 OK si existe, o 404 Not Found si no se encuentra.</returns>
        /// <response code="200">Operación exitosa. Comunidad encontrada.</response>
        /// <response code="404">No se encontró una comunidad con el identificador proporcionado.</response>
        /// <remarks>
        /// Ejemplo:\
        /// GET api/ComunidadesAut/1 \
        /// Devuelve la información de la comunidad con ID 1.
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ComunidadAutDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // Aplicar Response Cache dinámicamente
            ResponseCacheHelper.SetResponseCacheHeadersWithVary(
                Response,
                _configuration.CacheSettings.ResponseCache.SlowChangeDataDurationSeconds,
                varyByQueryKeys: "id");

            var comunidadAut = await GetComunidadByIdFromCacheAsync(id);

            var response = ApiResponseBuilder.Success(comunidadAut, $"{EntitiesConstants.COMUNIDADAUT} {GenericConstants.RESPONSE_EXITO_SINGULAR_FEMENINO}");

            return Ok(response);
        }

        #region Métodos privados
        private async Task<List<ComunidadAutDto>> GetComunidadesFromCacheAsync(int? pais)
        {
            var filtros = new Dictionary<string, object>();
            string baseKey;

            if (pais != null)
            {
                filtros.Add(FilterConstants.PAIS, pais.Value);
                baseKey = string.Join("_", EntitiesConstants.COMUNIDADESAUT, CacheConstants.CACHE_KEY_ALL, EntitiesConstants.PAIS, pais.Value);
            }
            else
            {
                baseKey = string.Join("_", EntitiesConstants.COMUNIDADESAUT, CacheConstants.CACHE_KEY_ALL);
            }

            var cacheKey = CacheKeyHelper.BuildKey(baseKey, filtros.Count > 0 ? filtros : null);

            if (!_memoryCache.TryGetValue(cacheKey, out List<ComunidadAutDto>? comunidades))
            {
                comunidades = await _comunidadAutServ.GetAllAsync(filtros) ?? throw new SimpleNotFoundException(EntitiesConstants.COMUNIDADESAUT);

                var cacheOptions = MemoryCacheHelper.CreateSlowChangeDataCacheOptions(_configuration);
                _memoryCache.Set(cacheKey, comunidades, cacheOptions);
            }

            return comunidades!;
        }

        private async Task<ComunidadAutDto> GetComunidadByIdFromCacheAsync(int id)
        {
            var baseKey = string.Join("_", EntitiesConstants.COMUNIDADESAUT, id);

            if (!_memoryCache.TryGetValue(baseKey, out ComunidadAutDto? comunidadAut))
            {
                comunidadAut = await _comunidadAutServ.GetByIdAsync(id) ?? throw new SimpleNotFoundException(EntitiesConstants.COMUNIDADESAUT, id);

                var cacheOptions = MemoryCacheHelper.CreateSlowChangeDataCacheOptions(_configuration);
                _memoryCache.Set(baseKey, comunidadAut, cacheOptions);
            }

            return comunidadAut!;
        }
        #endregion
    }
}
