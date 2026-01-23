using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesElementosObservCierre
{
    public int PecId { get; set; }

    public int PocId { get; set; }

    public string PocObservacion { get; set; } = null!;

    public virtual PromocionesElementosCierre Pec { get; set; } = null!;
}
