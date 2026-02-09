using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TiposIva
{
    public short TivId { get; set; }

    public string TivNombre { get; set; } = null!;

    public bool TivExento { get; set; }

    public bool TivServTrebol { get; set; }

    public string? TivIdGrpIvafarmatic { get; set; }

    public virtual ICollection<FacturasTrebolConcepto> FacturasTrebolConceptos { get; set; } = new List<FacturasTrebolConcepto>();

    public virtual ICollection<GruposProveedoresCalculosPvp> GruposProveedoresCalculosPvps { get; set; } = new List<GruposProveedoresCalculosPvp>();

    public virtual ICollection<ProveedoresCalculosPvp> ProveedoresCalculosPvps { get; set; } = new List<ProveedoresCalculosPvp>();

    public virtual ICollection<TiposIvaporcentaje> TiposIvaporcentajes { get; set; } = new List<TiposIvaporcentaje>();

    public virtual ICollection<TssprocesoAux> TssprocesoAuxes { get; set; } = new List<TssprocesoAux>();
}
