using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CuentasDetalle
{
    public int CudId { get; set; }

    public int CueId { get; set; }

    public int CliId { get; set; }

    public string TarId { get; set; } = null!;

    public string? CudTicket { get; set; }

    public DateTime CudFecha { get; set; }

    public int UnnId { get; set; }

    public short VefId { get; set; }

    public decimal CudImporteBruto { get; set; }

    public decimal CudImporteBonificable { get; set; }

    public decimal CudPuntos { get; set; }

    public int CudBono { get; set; }

    public string? ArtBono { get; set; }

    public bool? CudForzado { get; set; }

    public bool CudAnulado { get; set; }

    public string CudOperacion { get; set; } = null!;

    public int? MotId { get; set; }

    public DateTime CudFalta { get; set; }

    public int CudUalta { get; set; }

    public DateTime? CudFmodificacion { get; set; }

    public int? CudUmodificacion { get; set; }

    public bool? CudHistorico { get; set; }

    public virtual Cuenta Cue { get; set; } = null!;

    public virtual MotivosCuentasDetalle? Mot { get; set; }
}
