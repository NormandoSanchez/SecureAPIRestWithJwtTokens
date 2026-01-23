using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class LineasNegocio
{
    public short LneId { get; set; }

    public string LneNombre { get; set; } = null!;

    public bool LneResidencias { get; set; }

    public bool LneOtros { get; set; }
}
