using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FacturasTrebolResumenLin
{
    public int FtrId { get; set; }

    public decimal FtrPorImpuesto { get; set; }

    public decimal FtrBase { get; set; }

    public decimal FtrCuota { get; set; }

    public decimal FtrTotal { get; set; }

    public string? FtrTextoResumen { get; set; }

    public virtual FacturasTrebol Ftr { get; set; } = null!;
}
