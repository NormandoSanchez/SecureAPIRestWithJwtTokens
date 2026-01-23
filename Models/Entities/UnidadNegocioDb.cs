namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnidadNegocioDb
{
    public int UnnId { get; set; }

    public string UnnDbserver { get; set; } = null!;

    public string UnnDbuser { get; set; } = null!;

    public string? UnnDbpass { get; set; }

    public string UnnDbname { get; set; } = null!;

    public string? UnnDbserverLs { get; set; }

    public string? UnnDbnameLs { get; set; }

    public virtual UnidadNegocio UnidadNegocio { get; set; } = null!;
}
