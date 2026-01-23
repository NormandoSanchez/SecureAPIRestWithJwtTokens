using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace SecureAPIRestWithJwtTokens.Authorization;

/// <summary>
/// Proporciona políticas de autorización basadas en procesos. 
/// </summary>
/// <param name="options"></param>
public class ProcesoAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : IAuthorizationPolicyProvider
{
    private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider = new(options);

    /// <summary>
    /// Obtiene una política de autorización basada en el nombre de la política.
    /// </summary>
    /// <param name="policyName"></param>
    /// <returns></returns>
    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(ProcesoAuthorizeAttribute.PolicyPrefix, StringComparison.OrdinalIgnoreCase))
        {
            var ids = policyName[ProcesoAuthorizeAttribute.PolicyPrefix.Length..].Split('_', StringSplitOptions.RemoveEmptyEntries);
            var policy = new AuthorizationPolicyBuilder()
                .AddRequirements(new ProcesoClaimRequirement(ids))
                .Build();
            return Task.FromResult<AuthorizationPolicy?>(policy);
        }
        return _fallbackPolicyProvider.GetPolicyAsync(policyName);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => _fallbackPolicyProvider.GetDefaultPolicyAsync();
    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => _fallbackPolicyProvider.GetFallbackPolicyAsync();
}
