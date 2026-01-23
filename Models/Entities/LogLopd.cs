using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class LogLopd
{
    public int LogId { get; set; }

    public int? UsrId { get; set; }

    public int? UnnId { get; set; }

    public DateTime? LogFecha { get; set; }

    public int CliId { get; set; }

    public string CudTicket { get; set; } = null!;

    public string UnnIdticket { get; set; } = null!;
}
