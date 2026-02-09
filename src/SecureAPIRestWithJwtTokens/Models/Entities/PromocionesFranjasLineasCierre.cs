using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesFranjasLineasCierre
{
    public int PfcId { get; set; }

    public int PlcIdlinea { get; set; }

    public short PlcDiaDesde { get; set; }

    public short PlcDiaHasta { get; set; }

    public short PlcMesDesde { get; set; }

    public short PlcMesHasta { get; set; }

    public virtual PromocionesFranjasCierre Pfc { get; set; } = null!;
}
