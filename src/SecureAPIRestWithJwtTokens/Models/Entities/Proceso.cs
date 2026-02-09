namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Proceso
{
    /// <summary>
    /// Identificador
    /// </summary>
    public string ProId { get; set; } = null!;

    /// <summary>
    /// Nombre
    /// </summary>
    public string ProNombre { get; set; } = null!;

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

    public virtual ICollection<PerfilAcceso> Perfiles { get; set; } = [];
    public virtual ICollection<AvisoInterno> AvisosInternos { get; set; } = [];
}
