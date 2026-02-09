using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class EnviosFormulariosLinea
{
    public int EnvId { get; set; }

    public int EnvLinea { get; set; }

    public string ForCodBar { get; set; } = null!;

    public virtual EnviosFormulario Env { get; set; } = null!;
}
