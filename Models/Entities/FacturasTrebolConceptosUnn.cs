using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FacturasTrebolConceptosUnn
{
    public int CftId { get; set; }

    public int UnnId { get; set; }

    public decimal CftImpBruto { get; set; }

    public bool CftNoAplicar { get; set; }

    public virtual FacturasTrebolConcepto Cft { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
