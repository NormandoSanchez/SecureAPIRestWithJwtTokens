namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CampaniasCliente
{
    public int CacId { get; set; }

    public int CamId { get; set; }

    public int CliId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public decimal CabImporte { get; set; }

    public decimal CabPuntos { get; set; }

    public int CabCaducidad { get; set; }

    public string? CabMensaje { get; set; }

    public virtual ArticulosBono ArtCodigoNavigation { get; set; } = null!;

    public virtual Campania Cam { get; set; } = null!;

    public virtual Cliente Cli { get; set; } = null!;

    public virtual ICollection<CampaniasArticulo> Caas { get; set; } = new List<CampaniasArticulo>();
}
