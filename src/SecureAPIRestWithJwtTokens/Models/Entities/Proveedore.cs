using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Proveedore
{
    public string PvfCodigo { get; set; } = null!;

    public string PvfNombre { get; set; } = null!;

    public string? PvfIdFiscal { get; set; }

    public short? FpaId { get; set; }

    public string? LabCodigo { get; set; }

    public int? CarId { get; set; }

    public bool PvfRevisarCc { get; set; }

    public short PvfRevCada { get; set; }

    public string PvfRevPeriodo { get; set; } = null!;

    public int? PvfRevUsr { get; set; }

    public DateTime? PvfRevUltFecha { get; set; }

    public bool PvfEnFactTrebol { get; set; }

    public bool PvfEsTraspaso { get; set; }

    public bool PvfEsAlmacenTrebol { get; set; }

    public string? PvfWeb { get; set; }

    public int PvfUalta { get; set; }

    public DateTime PvfFalta { get; set; }

    public int? PvfUmodificacion { get; set; }

    public DateTime? PvfFmodificacion { get; set; }

    public virtual Laboratorio? LabCodigoNavigation { get; set; }

    public virtual ICollection<Plataforma> Plataformas { get; set; } = new List<Plataforma>();

    public virtual ICollection<ProveedoresCalculosPvp> ProveedoresCalculosPvps { get; set; } = new List<ProveedoresCalculosPvp>();

    public virtual ICollection<ProveedoresCondCompra> ProveedoresCondCompras { get; set; } = new List<ProveedoresCondCompra>();

    public virtual ICollection<ProveedoresContacto> ProveedoresContactos { get; set; } = new List<ProveedoresContacto>();

    public virtual ICollection<ProveedoresDir> ProveedoresDirs { get; set; } = new List<ProveedoresDir>();

    public virtual ICollection<ProveedoresGrupo> ProveedoresGrupos { get; set; } = new List<ProveedoresGrupo>();
}
