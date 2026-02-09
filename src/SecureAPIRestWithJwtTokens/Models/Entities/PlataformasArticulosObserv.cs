using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PlataformasArticulosObserv
{
    public long ParId { get; set; }

    public string ParObservaciones { get; set; } = null!;

    public virtual PlataformasArticulo Par { get; set; } = null!;
}
