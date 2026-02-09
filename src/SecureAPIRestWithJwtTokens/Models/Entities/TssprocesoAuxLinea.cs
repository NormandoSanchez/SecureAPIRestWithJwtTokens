using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssprocesoAuxLinea
{
    public int TsxId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public string TslTipo { get; set; } = null!;

    public string TslDescripcion { get; set; } = null!;

    public short ArtFamilia { get; set; }

    public string TslModoCalculo { get; set; } = null!;

    public int TslUds { get; set; }

    public decimal TslPorcentajeLiq { get; set; }

    public decimal TslBaseCalculo { get; set; }

    public decimal TslImporteLiq { get; set; }

    public string? TaeId { get; set; }

    public virtual TssprocesoAux Tsx { get; set; } = null!;
}
