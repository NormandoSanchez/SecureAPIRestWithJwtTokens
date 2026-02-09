using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesElemento
{
    public int PmeId { get; set; }

    public int PrmId { get; set; }

    public string PmeTipoElemento { get; set; } = null!;

    public string EleId { get; set; } = null!;

    public string PmeDescripcion { get; set; } = null!;

    public bool PmeBonifica { get; set; }

    public bool PmePermiteDtoV { get; set; }

    public string PmeTipoVenta { get; set; } = null!;

    public decimal PmeDtoAplic { get; set; }

    public virtual Promocione Prm { get; set; } = null!;

    public virtual ICollection<PromocionesElementosObserv> PromocionesElementosObservs { get; set; } = new List<PromocionesElementosObserv>();

    public virtual ICollection<PromocionesObj> PromocionesObjs { get; set; } = new List<PromocionesObj>();
}
