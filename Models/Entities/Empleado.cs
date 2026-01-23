namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Empleado
{
    public int EmpId { get; set; }

    public string EmpNombre { get; set; } = null!;

    public string EmpApellido1 { get; set; } = null!;

    public string? EmpApellido2 { get; set; }

    public string EmpIdfiscal { get; set; } = null!;

    public short EmpEstado { get; set; }

    public int? EmpUsrId { get; set; }

    public string? EmpFoto { get; set; }

    public int? DirId { get; set; }

    public string? EmpTelf { get; set; }

    public string? EmpMail { get; set; }

    /// <summary>
    /// Fecha de Alta
    /// </summary>
    public DateTime EmpFalta { get; set; }

    /// <summary>
    /// Id. Usuario Alta
    /// </summary>
    public int? EmpUalta { get; set; }

    /// <summary>
    /// Fecha Modificación
    /// </summary>
    public DateTime? EmpFmodificacion { get; set; }

    /// <summary>
    /// Identificador del último Usuario que modificó
    /// </summary>
    public int? EmpUmodificacion { get; set; }

    public short? CatId { get; set; }

    public virtual Direccion? Dir { get; set; }

    public virtual Usuario? EmpUsr { get; set; }

    public virtual ICollection<EmpleadosDocumento> EmpleadosDocumentos { get; set; } = [];

    public virtual ICollection<EmpleadoUnidadNegocio> EmpleadosUnidadesNegs { get; set; } = [];
}
