using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TiposIvaporcentaje
{
    public short TivId { get; set; }

    public DateTime TivFdesde { get; set; }

    public decimal TivPorcentaje { get; set; }

    public decimal TivRecargoEq { get; set; }

    public virtual TiposIva Tiv { get; set; } = null!;
}
