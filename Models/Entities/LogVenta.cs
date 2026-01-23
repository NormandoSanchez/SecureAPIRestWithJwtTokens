using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class LogVenta
{
    public int LogId { get; set; }

    public string? LogError { get; set; }

    public int CliId { get; set; }

    public int CueId { get; set; }

    public int TatId { get; set; }

    public string TarId { get; set; } = null!;

    public string CudTicket { get; set; } = null!;

    public DateTime CudFecha { get; set; }

    public int UnnId { get; set; }

    public decimal CuePuntos { get; set; }

    public int CueBonos { get; set; }

    public decimal OpePuntos { get; set; }

    public int OpeBonos { get; set; }

    public int OpeBonosGastados { get; set; }

    public decimal FinPuntos { get; set; }

    public int FinBonos { get; set; }
}
