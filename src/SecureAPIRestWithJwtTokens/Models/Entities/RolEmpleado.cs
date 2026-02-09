namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class RolEmpleado
{
    public short RolId { get; set; }

    public string RolNombre { get; set; } = null!;

    public bool RolTitular { get; set; }

    public bool RolGerente { get; set; }

    public bool RolCoordinador { get; set; }

    public virtual ICollection<EmpleadoUnidadNegRole> EmpleadosUnidadesNegRoles { get; set; } = [];
}
