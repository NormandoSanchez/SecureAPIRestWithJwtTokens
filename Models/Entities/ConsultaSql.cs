namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ConsultaSql
{
    public int ConId { get; set; }

    public string ConDescrip { get; set; } = null!;

    public string ConSentencia { get; set; } = null!;

    public string? ConObservaciones { get; set; }

    public int? ConTimeOut { get; set; }

    public DateTime? ConFechaini { get; set; }

    public DateTime? ConFechafin { get; set; }

    public DateTime? ConHoraini { get; set; }

    public DateTime? ConHorafin { get; set; }

    public int NicId { get; set; }

    public bool ConVigente { get; set; }

    /// <summary>
    /// Fecha de Alta
    /// </summary>
    public DateTime ConFalta { get; set; }

    /// <summary>
    /// Id. Usuario Alta
    /// </summary>
    public int ConUalta { get; set; }

    /// <summary>
    /// Fecha Modificación
    /// </summary>
    public DateTime? ConFmodificacion { get; set; }

    /// <summary>
    /// Identificador del último Usuario que modificó
    /// </summary>
    public int? ConUmodificacion { get; set; }

    public virtual NivelConsulta Nivel { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = [];
}
