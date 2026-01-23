using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Laboratorio
{
    public string LabCodigo { get; set; } = null!;

    public string LabOrigen { get; set; } = null!;

    public string LabNombre { get; set; } = null!;

    public string? LabIdFiscal { get; set; }

    public short? FpaId { get; set; }

    public bool LabRevisarCc { get; set; }

    public short LabRevCada { get; set; }

    public string LabRevPeriodo { get; set; } = null!;

    public int? LabRevUsr { get; set; }

    public DateTime? LabRevUltFecha { get; set; }

    public string? LabWeb { get; set; }

    public DateTime LabFalta { get; set; }

    public int LabUalta { get; set; }

    public DateTime? LabFmodificacion { get; set; }

    public int? LabUmodificacion { get; set; }

    public virtual ICollection<LaboratoriosCondCompra> LaboratoriosCondCompras { get; set; } = new List<LaboratoriosCondCompra>();

    public virtual ICollection<LaboratoriosContacto> LaboratoriosContactos { get; set; } = new List<LaboratoriosContacto>();

    public virtual ICollection<LaboratoriosDir> LaboratoriosDirs { get; set; } = new List<LaboratoriosDir>();

    public virtual ICollection<LaboratoriosGrupo> LaboratoriosGrupos { get; set; } = new List<LaboratoriosGrupo>();

    public virtual ICollection<LaboratoriosObj> LaboratoriosObjs { get; set; } = new List<LaboratoriosObj>();

    public virtual ICollection<Proveedore> Proveedores { get; set; } = new List<Proveedore>();

    public virtual ICollection<ProveedoresTrebolLaboratorio> ProveedoresTrebolLaboratorios { get; set; } = new List<ProveedoresTrebolLaboratorio>();
}
