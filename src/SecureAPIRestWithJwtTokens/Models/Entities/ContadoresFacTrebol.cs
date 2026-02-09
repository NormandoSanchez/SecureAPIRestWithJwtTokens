using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ContadoresFacTrebol
{
    public int SocId { get; set; }

    public short TstId { get; set; }

    public short CntEjercicio { get; set; }

    public string CntSerie { get; set; } = null!;

    public string CntSerieProForma { get; set; } = null!;

    public string CntSerieAbono { get; set; } = null!;

    public int CntNumDoc { get; set; }

    public int CntNumAbono { get; set; }

    public virtual Sociedade Soc { get; set; } = null!;

    public virtual TipoServiciosTrebol Tst { get; set; } = null!;
}
