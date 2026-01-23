namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CampaniasArticulo
{
    public int CaaId { get; set; }

    public string? ArtCodigo { get; set; }

    public short? CaaFamilia { get; set; }

    public decimal CaaPorcentaje { get; set; }

    public string? ArtDescripcion { get; set; }

    public string? CaaDescFamilia { get; set; }

    public virtual ICollection<CampaniasCliente> Cacs { get; set; } = new List<CampaniasCliente>();

    public virtual ICollection<CampaniasTarjetasTipo> Ctts { get; set; } = new List<CampaniasTarjetasTipo>();
}
