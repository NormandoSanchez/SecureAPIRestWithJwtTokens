namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ArticulosMod
{
    public string Codigo { get; set; } = null!;

    public decimal Pvp { get; set; }

    public decimal Pvl { get; set; }

    public decimal Dtot { get; set; }

    public decimal Dtop { get; set; }

    public decimal Iva { get; set; }
}
