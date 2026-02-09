namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ArticulosModBidum
{
    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Familia { get; set; }

    public decimal? Libre { get; set; }

    public decimal Iva { get; set; }

    public decimal Pvp { get; set; }

    public decimal Pvf { get; set; }

    public decimal Pv { get; set; }
}
