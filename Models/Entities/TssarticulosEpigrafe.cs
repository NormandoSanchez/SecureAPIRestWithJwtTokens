using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssarticulosEpigrafe
{
    public string TaeId { get; set; } = null!;

    public string? TaeDescripcion { get; set; }

    public virtual ICollection<TssclientesAuxA> TssclientesAuxAs { get; set; } = new List<TssclientesAuxA>();
}
