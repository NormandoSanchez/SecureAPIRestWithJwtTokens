using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class RealesDecretosUnn
{
    public int RdcId { get; set; }

    public int UnnId { get; set; }

    public short RduEjercicio { get; set; }

    public short RduMes { get; set; }

    public decimal RduImporte { get; set; }

    public virtual RealesDecreto Rdc { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
