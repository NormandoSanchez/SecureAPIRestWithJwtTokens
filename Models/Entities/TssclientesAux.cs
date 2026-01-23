using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssclientesAux
{
    public int ClrId { get; set; }

    public decimal ClxGen { get; set; }

    public decimal? ClxPropio { get; set; }

    public string ClxModoMe { get; set; } = null!;

    public decimal? ClxPorMe { get; set; }

    public decimal? ClxImpFme { get; set; }

    public short? ClxCadaMe { get; set; }

    public decimal? ClxImpCadaMe { get; set; }

    public virtual Tsscliente Clr { get; set; } = null!;
}
