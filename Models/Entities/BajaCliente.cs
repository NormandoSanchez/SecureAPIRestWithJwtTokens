namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class BajaCliente
{
    public int CliId { get; set; }

    public string CliNombre { get; set; } = null!;

    public string CliApellido1 { get; set; } = null!;

    public string? CliApellido2 { get; set; }

    public int DirId { get; set; }

    public string CliSexo { get; set; } = null!;

    public DateTime? CliFnacimiento { get; set; }

    public bool CliRecibirNotificaciones { get; set; }

    public int OriId { get; set; }

    public string? CliIdfiscal { get; set; }

    public string? CliTelf { get; set; }

    public string? CliMovil { get; set; }

    public string? CliEmail { get; set; }

    public DateTime? CliFultVenta { get; set; }

    public int? UnnIdultVenta { get; set; }

    public DateTime? CliFultMovimiento { get; set; }

    public int? UnnIdultMovimiento { get; set; }

    public DateTime CliFalta { get; set; }

    public int CliUalta { get; set; }

    public DateTime? CliFmodificacion { get; set; }

    public int? CliUmodificacion { get; set; }

    public DateTime? CliFbaja { get; set; }

    public int? CliUbaja { get; set; }

    public string? Origen { get; set; }

    public DateTime FechaAuditoria { get; set; }
}
