using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesFranjasUnncierre
{
    public int PfcId { get; set; }

    public int UnnId { get; set; }

    public int? IdFranjaLocal { get; set; }

    public virtual PromocionesFranjasCierre Pfc { get; set; } = null!;
}
