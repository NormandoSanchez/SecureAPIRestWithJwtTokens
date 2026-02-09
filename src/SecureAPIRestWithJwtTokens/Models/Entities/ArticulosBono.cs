namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ArticulosBono
{
    public string ArtCodigo { get; set; } = null!;

    public string ArtDescripcion { get; set; } = null!;

    public decimal ArtPrecio { get; set; }

    public virtual ICollection<CampaniasCliente> CampaniasClientes { get; set; } = new List<CampaniasCliente>();

    public virtual ICollection<CampaniasTarjetasTipo> CampaniasTarjetasTipos { get; set; } = new List<CampaniasTarjetasTipo>();
}
