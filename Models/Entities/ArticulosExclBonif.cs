namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ArticulosExclBonif
{
    public int UnnId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
