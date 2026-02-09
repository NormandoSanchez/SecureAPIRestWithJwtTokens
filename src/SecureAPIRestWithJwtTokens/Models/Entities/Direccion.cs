namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Direccion
{
    public int DirId { get; set; }

    public int TviId { get; set; }

    public string DirNombreCalle { get; set; } = null!;

    public string? DirNumero { get; set; }

    public string? DirPortal { get; set; }

    public string? DirEscalera { get; set; }

    public string? DirPiso { get; set; }

    public string? DirPuerta { get; set; }

    public string? DirComplemento { get; set; }

    public string DirCodPostal { get; set; } = null!;

    public int PobId { get; set; }

    public int PrvId { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = [];

    public virtual ICollection<Empleado> Empleados { get; set; } = [];

    public virtual ICollection<GruposLaboratoriosDir> GruposLaboratoriosDirs { get; set; } = [];

    public virtual ICollection<GruposProveedoresDir> GruposProveedoresDirs { get; set; } = [];

    public virtual ICollection<LaboratoriosDir> LaboratoriosDirs { get; set; } = [];

    public virtual Poblacion Poblacion { get; set; } = null!;

    public virtual Provincia Provincia { get; set; } = null!;

    public virtual ICollection<ProveedoresDir> ProveedoresDirs { get; set; } = [];

    public virtual ICollection<ProveedoresNfdir> ProveedoresNfdirs { get; set; } = [];

    public virtual ICollection<Sociedade> Sociedades { get; set; } = [];

    public virtual ICollection<TssclientesDir> TssclientesDirs { get; set; } = [];

    public virtual ICollection<TssfacturasCliente> TssfacturasClienteDirIdenvioNavigations { get; set; } = [];

    public virtual ICollection<TssfacturasCliente> TssfacturasClienteDirIdfacNavigations { get; set; } = [];

    public virtual TipoVia TipoVia { get; set; } = null!;

    public virtual ICollection<UnidadNegocioDireccion> UnidadNegocioDirecciones { get; set; } = [];
}
