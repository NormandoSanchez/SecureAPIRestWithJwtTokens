using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TipoServiciosTrebol
{
    public short TstId { get; set; }

    public string TstNombre { get; set; } = null!;

    public string CntSerie { get; set; } = null!;

    public string CntSerieProForma { get; set; } = null!;

    public string CntSerieAbono { get; set; } = null!;

    public virtual ICollection<ContadoresFacTrebol> ContadoresFacTrebols { get; set; } = new List<ContadoresFacTrebol>();

    public virtual ICollection<FacturasTrebolConcepto> FacturasTrebolConceptos { get; set; } = new List<FacturasTrebolConcepto>();

    public virtual ICollection<FacturasTrebol> FacturasTrebols { get; set; } = new List<FacturasTrebol>();
}
