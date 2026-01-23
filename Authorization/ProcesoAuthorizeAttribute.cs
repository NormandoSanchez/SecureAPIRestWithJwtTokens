using Microsoft.AspNetCore.Authorization;

namespace SecureAPIRestWithJwtTokens.Authorization;

/// <summary>
/// Atributo de autorización para procesos específicos.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class ProcesoAuthorizeAttribute : AuthorizeAttribute
{
    public const string PolicyPrefix = "Proceso_";
    public string[] ProcesoIds { get; }

    public ProcesoAuthorizeAttribute(params string[] procesoIds)
    {
        ProcesoIds = procesoIds;
        Policy = PolicyPrefix + string.Join("_", procesoIds);
    }
}
