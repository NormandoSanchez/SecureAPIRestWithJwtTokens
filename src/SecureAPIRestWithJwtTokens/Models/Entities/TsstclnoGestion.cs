using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TsstclnoGestion
{
    public int UnnId { get; set; }

    public string TclId { get; set; } = null!;

    public string TclClase { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
