using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class GruposProveedore
{
    public int GpvId { get; set; }

    public string GpvNombre { get; set; } = null!;

    public bool GpvCalculoPvp { get; set; }

    public string? GpvWeb { get; set; }

    public DateTime GpvFalta { get; set; }

    public int GpvUalta { get; set; }

    public DateTime? GpvFmodificacion { get; set; }

    public int? GpvUmodificacion { get; set; }

    public virtual ICollection<GruposProveedoresCalculosPvp> GruposProveedoresCalculosPvps { get; set; } = new List<GruposProveedoresCalculosPvp>();

    public virtual ICollection<GruposProveedoresCont> GruposProveedoresConts { get; set; } = new List<GruposProveedoresCont>();

    public virtual ICollection<GruposProveedoresDir> GruposProveedoresDirs { get; set; } = new List<GruposProveedoresDir>();

    public virtual ICollection<ProveedoresGrupo> ProveedoresGrupos { get; set; } = new List<ProveedoresGrupo>();
}
