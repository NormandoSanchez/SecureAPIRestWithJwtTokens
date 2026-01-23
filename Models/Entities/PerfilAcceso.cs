namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PerfilAcceso
{
    /// <summary>
    /// Identificador de Perfil de Acceso
    /// </summary>
    public int PeaId { get; set; }

    /// <summary>
    /// Nombre perfil acceso
    /// </summary>
    public string PeaNombre { get; set; } = null!;

    /// <summary>
    /// Fecha de Alta
    /// </summary>
    public DateTime PeaFalta { get; set; }

    /// <summary>
    /// Id. Usuario Alta
    /// </summary>
    public int PeaUalta { get; set; }

    /// <summary>
    /// Fecha Modificación
    /// </summary>
    public DateTime? PeaFmodificacion { get; set; }

    /// <summary>
    /// Identificador del último Usuario que modificó
    /// </summary>
    public int? PeaUmodificacion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = [];

    public virtual ICollection<Proceso> Procesos { get; set; } = [];
}
