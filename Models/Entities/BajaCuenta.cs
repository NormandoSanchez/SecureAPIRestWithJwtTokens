namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class BajaCuenta
{
    public int CueId { get; set; }

    public decimal CueImpBonificacion { get; set; }

    public decimal CuePuntos { get; set; }

    public int CueBonos { get; set; }

    public decimal CueBonosImporte { get; set; }

    public string? CueUmodificacion { get; set; }

    public DateTime? CueFmodificacion { get; set; }
}
