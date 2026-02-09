using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class IftlogActividad
{
    public long LogId { get; set; }

    public int UnnId { get; set; }

    public string LogUndescrip { get; set; } = null!;

    public string LogUsuario { get; set; } = null!;

    public DateTime LogFechaHoraIni { get; set; }

    public DateTime? LogFechaHoraFin { get; set; }

    public string LogTipoOperacion { get; set; } = null!;

    public int OpeId { get; set; }

    public string LogDescOperacion { get; set; } = null!;

    public bool? LogResultado { get; set; }

    public string? LogError { get; set; }
}
