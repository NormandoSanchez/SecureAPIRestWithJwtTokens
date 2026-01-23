using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class GruposLaboratorio
{
    public int GlaId { get; set; }

    public string GlaNombre { get; set; } = null!;

    public bool GlaSoloAgrupa { get; set; }

    public string? GlaIdFiscal { get; set; }

    public short? FpaId { get; set; }

    public bool GlaRevisarCc { get; set; }

    public short GlaRevCada { get; set; }

    public string GlaRevPeriodo { get; set; } = null!;

    public int? GlaRevUsr { get; set; }

    public DateTime? GlaRevUltFecha { get; set; }

    public string? GlaWeb { get; set; }

    public DateTime GlaFalta { get; set; }

    public int GlaUalta { get; set; }

    public DateTime? GlaFmodificacion { get; set; }

    public int? GlaUmodificacion { get; set; }

    public virtual ICollection<GruposLaboratoriosCont> GruposLaboratoriosConts { get; set; } = new List<GruposLaboratoriosCont>();

    public virtual ICollection<GruposLaboratoriosDir> GruposLaboratoriosDirs { get; set; } = new List<GruposLaboratoriosDir>();

    public virtual ICollection<LaboratoriosCondCompra> LaboratoriosCondCompras { get; set; } = new List<LaboratoriosCondCompra>();

    public virtual ICollection<LaboratoriosGrupo> LaboratoriosGrupos { get; set; } = new List<LaboratoriosGrupo>();
}
