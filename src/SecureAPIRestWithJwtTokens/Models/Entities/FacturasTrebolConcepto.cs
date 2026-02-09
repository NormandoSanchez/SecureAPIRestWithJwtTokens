using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FacturasTrebolConcepto
{
    public int CftId { get; set; }

    public short TstId { get; set; }

    public int UnnIdcentral { get; set; }

    public int SocIdcentral { get; set; }

    public short TivId { get; set; }

    public string CftDescrip { get; set; } = null!;

    public decimal CftImpBruto { get; set; }

    public virtual ICollection<FacturasTrebolConceptosUnn> FacturasTrebolConceptosUnns { get; set; } = new List<FacturasTrebolConceptosUnn>();

    public virtual ICollection<PartnersConcepto> PartnersConceptos { get; set; } = new List<PartnersConcepto>();

    public virtual ICollection<TiposAcuerdoPartnerConcepto> TiposAcuerdoPartnerConceptos { get; set; } = new List<TiposAcuerdoPartnerConcepto>();

    public virtual TiposIva Tiv { get; set; } = null!;

    public virtual TipoServiciosTrebol Tst { get; set; } = null!;

    public virtual UnidadesNegocioSoc UnidadesNegocioSoc { get; set; } = null!;
}
