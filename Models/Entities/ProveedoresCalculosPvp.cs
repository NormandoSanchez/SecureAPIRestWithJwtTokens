using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresCalculosPvp
{
    public int CalLinId { get; set; }

    public string PvfCodigo { get; set; } = null!;

    public short TivId { get; set; }

    public short FamId { get; set; }

    public string? GrpFacturacion { get; set; }

    public decimal CalFactor { get; set; }

    public virtual Proveedore PvfCodigoNavigation { get; set; } = null!;

    public virtual TiposIva Tiv { get; set; } = null!;
}
