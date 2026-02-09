namespace SecureAPIRestWithJwtTokens.Models.DTO;

/// <summary>
/// DTO que expone solo las propiedades directas de la entidad Proceso.
/// </summary>
public class AuthProcessDto
{
    public string ProId { get; set; } = string.Empty;
    public string ProNombre { get; set; } = string.Empty;
    public bool ProEsModulo { get; set; }
    public string? ProDescripcion { get; set; }
    public bool ProFarmacia { get; set; }
    public bool ProDialog { get; set; }
    public int ProNivel { get; set; }
    public string? ProArea { get; set; }
    public string? ProAccion { get; set; }
    public string? ProController { get; set; }
    public string? ProImagen { get; set; }
    public bool? ProVisibleWeb { get; set; }
    public string? ProIconClass { get; set; }
    // No incluye propiedades de navegación ni colecciones
}