using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TiposAcuerdoPartner
{
    public short TapId { get; set; }

    public string TapClase { get; set; } = null!;

    public string TapDescripcion { get; set; } = null!;

    public string TapPlazoFact { get; set; } = null!;

    public short? FpaId { get; set; }

    public bool TapArticulos { get; set; }

    public int TapUalta { get; set; }

    public DateTime TapFalta { get; set; }

    public int? TapUmodificacion { get; set; }

    public DateTime? TapFmodificacion { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();

    public virtual ICollection<TiposAcuerdoPartnerComp> TiposAcuerdoPartnerComps { get; set; } = new List<TiposAcuerdoPartnerComp>();

    public virtual ICollection<TiposAcuerdoPartnerConcepto> TiposAcuerdoPartnerConceptos { get; set; } = new List<TiposAcuerdoPartnerConcepto>();
}
