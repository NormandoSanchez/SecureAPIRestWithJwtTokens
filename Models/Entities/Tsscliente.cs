using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Tsscliente
{
    public int ClrId { get; set; }

    public int UnnId { get; set; }

    public string CliId { get; set; } = null!;

    public int? ClrIdpadre { get; set; }

    public string TclId { get; set; } = null!;

    public bool ClrFactAresidente { get; set; }

    public bool ClrGenDocFac { get; set; }

    public string? ClrOrdenFac { get; set; }

    public string ClrIdfiscal { get; set; } = null!;

    public string? ClrNass { get; set; }

    public string? ClrNombre { get; set; }

    public string? ClrApellido1 { get; set; }

    public string? ClrApellido2 { get; set; }

    public string ClrSexo { get; set; } = null!;

    public DateTime? ClrFnacimiento { get; set; }

    public decimal ClrRiesgoMax { get; set; }

    public short? FpaId { get; set; }

    public bool ClrActivo { get; set; }

    public DateTime ClrFasignacion { get; set; }

    public DateTime? ClrFinactivo { get; set; }

    public string? ClrMotivoInactivo { get; set; }

    public bool ClrAcuerdo { get; set; }

    public DateTime ClrFalta { get; set; }

    public int ClrUalta { get; set; }

    public DateTime? ClrFmodificacion { get; set; }

    public int? ClrUmodificacion { get; set; }

    public DateTime? ClrFmodImportacion { get; set; }

    public virtual Tsscliente? ClrIdpadreNavigation { get; set; }

    public virtual FormasPago? Fpa { get; set; }

    public virtual ICollection<Tsscliente> InverseClrIdpadreNavigation { get; set; } = new List<Tsscliente>();

    public virtual TssclientesAux? TssclientesAux { get; set; }

    public virtual ICollection<TssclientesAuxA> TssclientesAuxAs { get; set; } = new List<TssclientesAuxA>();

    public virtual ICollection<TssclientesCcc> TssclientesCccs { get; set; } = new List<TssclientesCcc>();

    public virtual ICollection<TssclientesCont> TssclientesConts { get; set; } = new List<TssclientesCont>();

    public virtual ICollection<TssclientesDir> TssclientesDirs { get; set; } = new List<TssclientesDir>();

    public virtual ICollection<TssclientesVf> TssclientesVfs { get; set; } = new List<TssclientesVf>();

    public virtual ICollection<TssfacturasCliente> TssfacturasClientes { get; set; } = new List<TssfacturasCliente>();

    public virtual ICollection<TssprocesoAux> TssprocesoAuxes { get; set; } = new List<TssprocesoAux>();

    public virtual TsstiposCliente TsstiposCliente { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
