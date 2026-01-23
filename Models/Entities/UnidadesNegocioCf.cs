using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnidadesNegocioCf
{
    public int UnnId { get; set; }

    public int CafAno { get; set; }

    public int CafId { get; set; }

    public virtual CalendarioFestivo Caf { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
