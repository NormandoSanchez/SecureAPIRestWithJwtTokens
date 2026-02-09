using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class IftextraccionControl
{
    public int UnnId { get; set; }

    public int OpeId { get; set; }

    public DateTime CexFcontrol { get; set; }

    public bool CexOk { get; set; }

    public virtual IftoperacionesDefinicion Ope { get; set; } = null!;
}
