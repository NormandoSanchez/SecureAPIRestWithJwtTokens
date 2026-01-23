using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersCompromisosInf
{
    public int ParId { get; set; }

    public int CmpId { get; set; }

    public short InfId { get; set; }

    public virtual PartnersCompromiso PartnersCompromiso { get; set; } = null!;
}
