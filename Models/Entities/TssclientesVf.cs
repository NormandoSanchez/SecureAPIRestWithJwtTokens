using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssclientesVf
{
    public int ClrId { get; set; }

    public short VefId { get; set; }

    public virtual Tsscliente Clr { get; set; } = null!;
}
