using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersDefCompromiso
{
    public int CmpId { get; set; }

    public string CmpDescrip { get; set; } = null!;

    public bool CmpPublicidad { get; set; }

    public bool CmpInformes { get; set; }

    public virtual ICollection<PartnersCompromiso> PartnersCompromisos { get; set; } = new List<PartnersCompromiso>();

    public virtual ICollection<TiposAcuerdoPartnerComp> TiposAcuerdoPartnerComps { get; set; } = new List<TiposAcuerdoPartnerComp>();
}
