using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssclientesAuxA
{
    public int ClaId { get; set; }

    public int ClrId { get; set; }

    public string? ArtCodigo { get; set; }

    public short? FamId { get; set; }

    public string ClaDescElemento { get; set; } = null!;

    public decimal ClaPorcentaje { get; set; }

    public string? TaeId { get; set; }

    public virtual Tsscliente Clr { get; set; } = null!;

    public virtual TssarticulosEpigrafe? Tae { get; set; }
}
