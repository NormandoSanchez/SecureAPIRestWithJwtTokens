using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class RealesDecreto
{
    public int RdcId { get; set; }

    public string RdcDescrip { get; set; } = null!;

    public bool RdcInhabilitado { get; set; }

    public virtual ICollection<RealesDecretosUnn> RealesDecretosUnns { get; set; } = new List<RealesDecretosUnn>();
}
