using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersDocumento
{
    public int ParId { get; set; }

    public int DocId { get; set; }

    public string DocLink { get; set; } = null!;

    public string? DocNombre { get; set; }

    public virtual Partner Par { get; set; } = null!;
}
