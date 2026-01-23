using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class DescripcionIvaerp
{
    public string IdCodigoArticu { get; set; } = null!;

    public string IdIvaantiguo { get; set; } = null!;

    public string DescIvaantiguo { get; set; } = null!;

    public string IdIvanuevo { get; set; } = null!;

    public string DescIvanuevo { get; set; } = null!;

    public DateTime? FechaInserccion { get; set; }
}
