using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnidadesNegocioCie
{
    public int UnnId { get; set; }

    public DateTime UciFiniCierre { get; set; }

    public DateTime? UciFfinCierre { get; set; }

    public string UciTipo { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
