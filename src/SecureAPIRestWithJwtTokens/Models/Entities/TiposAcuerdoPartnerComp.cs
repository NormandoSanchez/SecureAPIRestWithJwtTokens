using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TiposAcuerdoPartnerComp
{
    public short TapId { get; set; }

    public int CmpId { get; set; }

    public bool TccAvisos { get; set; }

    public string TccPeriodoAvisos { get; set; } = null!;

    public virtual PartnersDefCompromiso Cmp { get; set; } = null!;

    public virtual TiposAcuerdoPartner Tap { get; set; } = null!;

    public virtual ICollection<TiposAcuerdoPartnerCompInf> TiposAcuerdoPartnerCompInfs { get; set; } = new List<TiposAcuerdoPartnerCompInf>();

    public virtual ICollection<TiposAcuerdoPartnerCompPub> TiposAcuerdoPartnerCompPubs { get; set; } = new List<TiposAcuerdoPartnerCompPub>();
}
