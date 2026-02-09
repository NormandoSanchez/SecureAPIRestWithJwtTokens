using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Emedefinicion
{
    public string EmeArtInicio { get; set; } = null!;

    public string EmeArtFin { get; set; } = null!;

    public decimal EmePrecio { get; set; }
}
