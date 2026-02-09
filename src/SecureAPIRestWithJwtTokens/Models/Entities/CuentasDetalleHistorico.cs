using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CuentasDetalleHistorico
{
    public int CueId { get; set; }

    public int UnnId { get; set; }

    public int CuhMes { get; set; }

    public int CuhAnio { get; set; }

    public int CuhNumOperaciones { get; set; }

    public decimal CuhImporte { get; set; }

    public decimal? CuhImporteBonificable { get; set; }

    public decimal CuhPuntos { get; set; }

    public int CuhBonos { get; set; }

    public decimal CuhBonosImporte { get; set; }

    public int? CuhBonosCanjeados { get; set; }

    public decimal CuhBonosCanjeImporte { get; set; }

    public virtual Cuenta Cue { get; set; } = null!;
}
