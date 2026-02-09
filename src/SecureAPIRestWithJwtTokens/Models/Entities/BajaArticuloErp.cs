namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class BajaArticuloErp
{
    public string IdCodigoArticu { get; set; } = null!;

    public string DescArticu { get; set; } = null!;

    public double? Pvp { get; set; }

    public string? DescPlataforma { get; set; }

    public string? DescTipoIva { get; set; }

    public string? DescLaboratorio { get; set; }

    public DateTime? FechaInserccion { get; set; }
}
