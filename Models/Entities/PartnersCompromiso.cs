using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersCompromiso
{
    public int ParId { get; set; }

    public int CmpId { get; set; }

    public bool CmpTap { get; set; }

    public bool PccAvisos { get; set; }

    public string PccPeriodoAvisos { get; set; } = null!;

    public DateTime? PccUltAviso { get; set; }

    public virtual PartnersDefCompromiso Cmp { get; set; } = null!;

    public virtual Partner Par { get; set; } = null!;

    public virtual ICollection<PartnersCompromisosAviso> PartnersCompromisosAvisos { get; set; } = new List<PartnersCompromisosAviso>();

    public virtual ICollection<PartnersCompromisosInf> PartnersCompromisosInfs { get; set; } = new List<PartnersCompromisosInf>();

    public virtual ICollection<PartnersCompromisosPub> PartnersCompromisosPubs { get; set; } = new List<PartnersCompromisosPub>();
}
