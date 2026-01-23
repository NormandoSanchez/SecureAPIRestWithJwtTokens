using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CanonTrebolDef
{
    public int UnnId { get; set; }

    public bool CtdExclRdc { get; set; }

    public string CtdProcSql { get; set; } = null!;

    public string CtdDescripcion { get; set; } = null!;

    public decimal CtdPorCalculo { get; set; }

    public decimal CtdImpMinimo { get; set; }

    public DateTime? CtdUltFacturacion { get; set; }

    public DateTime? CtdUltAbono { get; set; }

    public string? CtdComentario { get; set; }

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
