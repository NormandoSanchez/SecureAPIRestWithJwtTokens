namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CampaniasTarjetasTipo
{
    public int CttId { get; set; }

    public int CamId { get; set; }

    public int TatId { get; set; }

    public decimal CabImporte { get; set; }

    public decimal CabPuntos { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public int CabCaducidad { get; set; }

    public string? CabMensaje { get; set; }

    public virtual ArticulosBono ArtCodigoNavigation { get; set; } = null!;

    public virtual Campania Cam { get; set; } = null!;

    public virtual TarjetasTipo Tat { get; set; } = null!;

    public virtual ICollection<CampaniasArticulo> Caas { get; set; } = new List<CampaniasArticulo>();
}
