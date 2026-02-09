using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesObjarticulo
{
    public int PmoId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public int PoaUnidades { get; set; }

    public decimal PoaImporte { get; set; }

    public virtual PromocionesObj Pmo { get; set; } = null!;
}
