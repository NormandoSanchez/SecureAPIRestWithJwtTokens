namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Usuario
{
    /// <summary>
    /// Identificador de Usuario
    /// </summary>
    public int UsrId { get; set; }

    public string UsrLogin { get; set; } = null!;

    public string UsrPassword { get; set; } = null!;

    /// <summary>
    /// Nombre del usuario
    /// </summary>
    public string UsrNombre { get; set; } = null!;

    public bool UsrHabilitado { get; set; }

    public bool UsrAdmin { get; set; }

    /// <summary>
    /// Identificador del perfil de Acceso
    /// </summary>
    public int PeaId { get; set; }

    public short? TstId { get; set; }

    public int? UsrAvisoSegLogin { get; set; }

    public bool UsrCambiarLogin { get; set; }

    public string? UsrMail { get; set; }

    public bool UsrFirmaPedidos { get; set; }

    public bool UsrGestorPartners { get; set; }

    /// <summary>
    /// Fecha de Alta
    /// </summary>
    public DateTime UsrFalta { get; set; }

    /// <summary>
    /// Id. Usuario alta
    /// </summary>
    public int UsrUalta { get; set; }

    /// <summary>
    /// Fecha Modificación
    /// </summary>
    public DateTime? UsrFmodificacion { get; set; }

    /// <summary>
    /// Identificador del último Usuario que modificó
    /// </summary>
    public int? UsrUmodificacion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = [];

    public virtual PerfilAcceso Perfil { get; set; } = null!;

    public virtual  ICollection<UsuarioJwtRefresh> RefreshTokens { get; set; } = [];

    public virtual ICollection<ConsultaSql> Consultas { get; set; } = [];
}
