using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class EnviosFormulario
{
    public int EnvId { get; set; }

    public int UnnId { get; set; }

    public int? EnvLote { get; set; }

    public string EnvTipo { get; set; } = null!;

    public int EnvUalta { get; set; }

    public DateTime EnvFalta { get; set; }

    public virtual ICollection<EnviosFormulariosLinea> EnviosFormulariosLineas { get; set; } = new List<EnviosFormulariosLinea>();

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
