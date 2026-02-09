
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Departamento
{
    public int DptId { get; set; }

    public string DptNombre { get; set; } = null!;

    public bool DptTrebol { get; set; }

    public string? DptAbrv { get; set; }

    public virtual ICollection<ContadoresPnf> ContadoresPnfs { get; set; } = new List<ContadoresPnf>();

    public virtual ICollection<GruposLaboratoriosCont> GruposLaboratoriosConts { get; set; } = new List<GruposLaboratoriosCont>();

    public virtual ICollection<GruposLaboratoriosDir> GruposLaboratoriosDirs { get; set; } = new List<GruposLaboratoriosDir>();

    public virtual ICollection<GruposProveedoresCont> GruposProveedoresConts { get; set; } = new List<GruposProveedoresCont>();

    public virtual ICollection<GruposProveedoresDir> GruposProveedoresDirs { get; set; } = new List<GruposProveedoresDir>();

    public virtual ICollection<LaboratoriosContacto> LaboratoriosContactos { get; set; } = new List<LaboratoriosContacto>();

    public virtual ICollection<LaboratoriosDir> LaboratoriosDirs { get; set; } = new List<LaboratoriosDir>();

    public virtual ICollection<PedidosNf> PedidosNfs { get; set; } = new List<PedidosNf>();

    public virtual ICollection<ProveedoresContacto> ProveedoresContactos { get; set; } = new List<ProveedoresContacto>();

    public virtual ICollection<ProveedoresDir> ProveedoresDirs { get; set; } = new List<ProveedoresDir>();

    public virtual ICollection<ProveedoresNfcontacto> ProveedoresNfcontactos { get; set; } = new List<ProveedoresNfcontacto>();

    public virtual ICollection<ProveedoresNfdir> ProveedoresNfdirs { get; set; } = new List<ProveedoresNfdir>();

    public virtual ICollection<TssclientesCont> TssclientesConts { get; set; } = new List<TssclientesCont>();
}
