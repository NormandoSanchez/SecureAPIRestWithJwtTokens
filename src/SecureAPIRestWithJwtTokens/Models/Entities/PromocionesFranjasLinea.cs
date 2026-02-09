using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesFranjasLinea
{
    public int PfrId { get; set; }

    public int PlfIdlinea { get; set; }

    public short PlfDiaDesde { get; set; }

    public short PlfDiaHasta { get; set; }

    public short PlfMesDesde { get; set; }

    public short PlfMesHasta { get; set; }

    public bool PlfMesesCompletos { get; set; }

    public virtual PromocionesFranja Pfr { get; set; } = null!;
}
