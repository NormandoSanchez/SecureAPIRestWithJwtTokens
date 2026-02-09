using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersGestore
{
    public int ParId { get; set; }

    public int UsrId { get; set; }

    public virtual Partner Par { get; set; } = null!;
}
