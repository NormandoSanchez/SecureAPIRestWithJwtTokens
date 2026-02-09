using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersConcepto
{
    public int ParId { get; set; }

    public int CftId { get; set; }

    public bool CftTap { get; set; }

    public bool PpcNoFacturar { get; set; }

    public decimal PpcImpBrutoAnual { get; set; }

    public virtual FacturasTrebolConcepto Cft { get; set; } = null!;

    public virtual Partner Par { get; set; } = null!;
}
