using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ContadoresLotesEnvio
{
    public int UnnId { get; set; }

    public int ConLotesTarjetas { get; set; }

    public int ConLotesDocum { get; set; }

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
