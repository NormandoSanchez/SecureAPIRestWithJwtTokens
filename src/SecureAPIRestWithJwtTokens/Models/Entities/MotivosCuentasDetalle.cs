using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class MotivosCuentasDetalle
{
    public int MotId { get; set; }

    public string MotDescripcion { get; set; } = null!;

    public string MotOperacion { get; set; } = null!;

    public virtual ICollection<CuentasDetalle> CuentasDetalles { get; set; } = new List<CuentasDetalle>();
}
