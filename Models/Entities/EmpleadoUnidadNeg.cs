namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class EmpleadoUnidadNegocio
{
    public int EmpId { get; set; }

    public int UnnId { get; set; }

    public bool UnnUltima { get; set; }

    public short? VefId { get; set; }

    public short? VefIdgenerico { get; set; }

    public string? EmpTelef { get; set; }

    public string? EmpMail { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual ICollection<EmpleadoUnidadNegRole> EmpleadoUnidadNegRoles { get; set; } = [];

    public virtual UnidadNegocio UnidadNegocio { get; set; } = null!;
}
