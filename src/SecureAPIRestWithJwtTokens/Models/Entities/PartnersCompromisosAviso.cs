using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersCompromisosAviso
{
    public long PcaId { get; set; }

    public int ParId { get; set; }

    public int CmpId { get; set; }

    public DateTime PcaAviso { get; set; }

    public DateTime? PcaRealizado { get; set; }

    public int? PcaUrealizado { get; set; }

    public virtual PartnersCompromiso PartnersCompromiso { get; set; } = null!;
}
