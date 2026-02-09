using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesElementosCierre
{
    public int PecId { get; set; }

    public int PrcId { get; set; }

    public string PecTipoElemento { get; set; } = null!;

    public string EleId { get; set; } = null!;

    public string PecDescripcion { get; set; } = null!;

    public bool PecBonifica { get; set; }

    public bool PecPermiteDtoV { get; set; }

    public string PecTipoVenta { get; set; } = null!;

    public decimal PecDtoAplic { get; set; }

    public virtual PromocionesCierre Prc { get; set; } = null!;

    public virtual ICollection<PromocionesElementosObservCierre> PromocionesElementosObservCierres { get; set; } = new List<PromocionesElementosObservCierre>();
}
