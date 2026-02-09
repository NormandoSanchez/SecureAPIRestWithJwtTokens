using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class IftopExtraccionResultado
{
    public int UnnId { get; set; }

    public int OpeId { get; set; }

    public DateTime OpeInicio { get; set; }

    public DateTime? OpeControlEjec { get; set; }

    public bool OpeUltimoResult { get; set; }

    public bool? OpeAuxiliar { get; set; }

    public virtual IftoperacionesDefinicion Ope { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
