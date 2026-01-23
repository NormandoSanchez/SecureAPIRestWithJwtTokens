using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FormasPagoDia
{
    public short FpaId { get; set; }

    public short FpaLinea { get; set; }

    public short FpaDias { get; set; }

    public float? FpaPorcentEfecto { get; set; }

    public virtual FormasPago Fpa { get; set; } = null!;
}
