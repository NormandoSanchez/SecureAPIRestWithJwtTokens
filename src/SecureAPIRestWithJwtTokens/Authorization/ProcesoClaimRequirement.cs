using SecureAPIRestWithJwtTokens.Constants;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Authorization
{
    /// <summary>
    /// Requiere que el usuario tenga uno o más claims de proceso.
    /// </summary>
    /// <param name="procesoIds"></param>
    public class ProcesoClaimRequirement(string[] procesoIds) : IAuthorizationRequirement
    {
        public string[] ProcesoIds { get; } = procesoIds;
    }

    /// <summary>
    /// Handler de autorización que valida si el usuario tiene acceso a los procesos requeridos consultando dinámicamente los permisos
    /// asociados a su usuario y perfil mediante AuthService.
    /// </summary>
    /// <remarks>
    /// Este manejador extrae el identificador de usuario y el identificador de perfil desde los claims del token JWT,
    /// consulta la lista de procesos permitidos para ese usuario/perfil usando AuthService.GetCodeProcessByUserAndProfileAsync,
    /// y verifica que todos los procesos requeridos estén presentes en dicha lista. Si se cumple el requisito, el contexto de autorización se marca como exitoso.
    /// </remarks>
    public class ProcesoClaimHandler(IAuthService authService) : AuthorizationHandler<ProcesoClaimRequirement>
    {
        private readonly IAuthService _authService = authService;

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, 
                                                             ProcesoClaimRequirement requirement)
        {
            // Si no hay procesos requeridos, autorizar directamente
            if (requirement.ProcesoIds == null || requirement.ProcesoIds.Length == 0)
            {
                context.Succeed(requirement);
                return;
            }

            // Extraer userId y perfilId de los claims
            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var perfilIdClaim = context.User.FindFirst(AuthConstants.INFRAESTRUCTURE_CLAIMS_PERFILID)?.Value;
            
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId) ||
                string.IsNullOrEmpty(perfilIdClaim) || !int.TryParse(perfilIdClaim, out int perfilId))
            {
                return;
            }

            var procesos = await _authService.GetCodeProcessByUserAndProfileAsync(userId, perfilId) ?? [];
            if (requirement.ProcesoIds.All(id => procesos.Contains(id)))
            {
                context.Succeed(requirement);
            }
        }
    }
}
