using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesElementosObserv
{
    public int PmeId { get; set; }

    public int PoeLinea { get; set; }

    public string PoeObservacion { get; set; } = null!;

    public virtual PromocionesElemento Pme { get; set; } = null!;
}
