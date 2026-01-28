using SecureAPIRestWithJwtTokens.Authorization;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Responses;
using SecureAPIRestWithJwtTokens.Services;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.AspNetCore.Mvc;

namespace SecureAPIRestWithJwtTokens.Controllers
{
    /// <summary>
    /// Controller para gestionar operaciones relacionadas con avisos internos.
    /// </summary>
    /// <param name="avisoService">Servicio para operaciones de avisos internos.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class AvisosController(IGenericService<AvisoInternoDto> avisoService) : ControllerBase
    {
        private readonly IGenericService<AvisoInternoDto> _avisoService = avisoService;

        /// <summary>
        /// Obtiene la lista de todos los avisos internos.
        /// </summary>
        /// <param name="idUsuario">ID del usuario para filtrar los avisos.</param>
        /// <param name="vistos">Indica si se deben incluir los avisos ya vistos.</param>
        /// <param name="antiguos">Indica si se deben incluir avisos antiguos.</param>
        /// <returns></returns>
        /// <response code="200">Operación exitosa. Lista de avisos internos recuperada.</response>
        /// <remarks>
        /// Ejemplo:\
        /// GET api/Avisos/1 \
        /// Devuelve la lista de todos los avisos internos para el usuario con ID 1, excluyendo los ya vistos y los antiguos.\
        /// GET api/Avisos/2?vistos=false&amp;antiguos=true \
        /// Devuelve la lista de avisos internos para el usuario con ID 2, excluyendo los vistos e incluyendo no vistos antiguos.\
        /// GET api/Avisos/2?antiguos=true \
        /// Devuelve la lista de avisos internos para el usuario con ID 2, excluyendo los vistos e incluyendo no vistos antiguos.\
        /// GET api/Avisos/2?vistos=true \
        /// Devuelve la lista de avisos internos para el usuario con ID 2, incluyendo los vistos e excluyendo antiguos.\
        /// Requiere autorización para acceder.
        /// </remarks>
        [ProcesoAuthorize (ProcessConstants.Avisos)]
        [HttpGet]
        [Route ("{idUsuario}")]
        [ProducesResponseType(typeof(ApiResponse<List<AvisoInternoDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromRoute] int idUsuario,
                                                [FromQuery] bool vistos = true,
                                                [FromQuery] bool antiguos = false)
        {
            // Deshabilitar caché para avisos internos
            ResponseCacheHelper.DisableCache(Response);
            
            var filtros = new Dictionary<string, object>();
            List<AvisoInternoDto>? avisos;

            if (idUsuario <= 0)
            {
                avisos = [];
            }
            else
            {
                filtros.Add(FilterConstants.ID_USUARIO, idUsuario);
                filtros.Add(FilterConstants.VISTOS, vistos ? FilterConstants.TRUE : FilterConstants.FALSE);
                filtros.Add(FilterConstants.ANTIGUOS, antiguos ? FilterConstants.TRUE : FilterConstants.FALSE);
                avisos = await _avisoService.GetAllAsync(filtros);
            }
            
            var response = ApiResponseBuilder.Success(avisos, 
                                                      $"{EntitiesConstants.AVISOSINTERNOS} {GenericConstants.RESPONSE_EXITO_PLURAL_MASCULINO}");
            return Ok(response);
        }
    }
}
