using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesElementosUnncierre
{
    public int PcaId { get; set; }

    public int PecId { get; set; }

    public int UnnId { get; set; }

    public int? IdOfertaLocal { get; set; }

    public int PecUdsObj { get; set; }

    public decimal PecImporteObj { get; set; }

    public virtual ICollection<PromocionesElementosUnnartCierre> PromocionesElementosUnnartCierres { get; set; } = new List<PromocionesElementosUnnartCierre>();
}
