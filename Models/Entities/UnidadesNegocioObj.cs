using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnidadesNegocioObj
{
    public int UnnId { get; set; }

    public int ObvAno { get; set; }

    public int ObvMes { get; set; }

    public short LneId { get; set; }

    public bool ObvCerrado { get; set; }

    public decimal ObvSoe { get; set; }

    public decimal ObvLibre { get; set; }

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
