namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class BajaCuentasBono
{
    public int CueId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public int CubId { get; set; }

    public bool CubUsado { get; set; }

    public DateTime? CubFechaCaducidad { get; set; }

    public DateTime? CubFechaUso { get; set; }

    public bool? CubUsoForzado { get; set; }

    public int? UnnId { get; set; }

    public string? TarId { get; set; }

    public int? VefId { get; set; }

    public int? UsuId { get; set; }
}
