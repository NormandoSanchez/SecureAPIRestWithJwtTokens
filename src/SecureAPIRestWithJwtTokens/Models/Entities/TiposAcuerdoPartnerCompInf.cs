using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TiposAcuerdoPartnerCompInf
{
    public short TapId { get; set; }

    public int CmpId { get; set; }

    public short InfId { get; set; }

    public virtual TiposAcuerdoPartnerComp TiposAcuerdoPartnerComp { get; set; } = null!;
}
