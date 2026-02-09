using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesObj
{
    public int PmoId { get; set; }

    public int PmeId { get; set; }

    public int UnnId { get; set; }

    public int PobEjercicio { get; set; }

    public short PobMes { get; set; }

    public int PobUnidades { get; set; }

    public decimal PobPvp { get; set; }

    public decimal PobImporte { get; set; }

    public virtual PromocionesElemento Pme { get; set; } = null!;

    public virtual ICollection<PromocionesObjarticulo> PromocionesObjarticulos { get; set; } = new List<PromocionesObjarticulo>();
}
