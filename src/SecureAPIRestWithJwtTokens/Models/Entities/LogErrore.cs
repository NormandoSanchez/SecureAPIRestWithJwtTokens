using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class LogErrore
{
    public int LoeId { get; set; }

    public string LoeError { get; set; } = null!;

    public int UnnId { get; set; }

    public string LoeUalta { get; set; } = null!;

    public string LoeFalta { get; set; } = null!;

    public string LoeModulo { get; set; } = null!;

    public string LoeOpcion { get; set; } = null!;

    public string LoeClase { get; set; } = null!;
}
