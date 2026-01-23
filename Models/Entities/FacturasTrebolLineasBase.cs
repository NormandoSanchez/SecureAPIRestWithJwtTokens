using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FacturasTrebolLineasBase
{
    public int FtrId { get; set; }

    public int FlbLinea { get; set; }

    public decimal FlbImporte { get; set; }

    public string FlbDescripcion { get; set; } = null!;

    public virtual FacturasTrebol Ftr { get; set; } = null!;
}
