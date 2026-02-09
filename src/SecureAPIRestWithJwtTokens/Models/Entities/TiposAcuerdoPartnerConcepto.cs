using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TiposAcuerdoPartnerConcepto
{
    public short TapId { get; set; }

    public int CftId { get; set; }

    public decimal TpcImpBrutoAnual { get; set; }

    public virtual FacturasTrebolConcepto Cft { get; set; } = null!;

    public virtual TiposAcuerdoPartner Tap { get; set; } = null!;
}
