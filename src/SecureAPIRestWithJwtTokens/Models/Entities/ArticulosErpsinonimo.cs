namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ArticulosErpsinonimo
{
    public string ArtCodigo { get; set; } = null!;

    public string ArtEan { get; set; } = null!;

    public bool ArtEanprincipal { get; set; }

    public virtual ArticulosErp ArtCodigoNavigation { get; set; } = null!;
}
