namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class EmpleadoUnidadNegRole
{
    public int EmpId { get; set; }

    public int UnnId { get; set; }

    public short RolId { get; set; }

    public DateTime EmpFasignado { get; set; }

    public DateTime? EmpFbaja { get; set; }

    public string? EmpMotivoBaja { get; set; }

    public virtual EmpleadoUnidadNegocio EmpleadoUnidadNeg { get; set; } = null!;

    public virtual RolEmpleado Rol { get; set; } = null!;
}
