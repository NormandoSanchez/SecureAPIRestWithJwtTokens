using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssclientesCcc
{
    public int ClrId { get; set; }

    public int CccId { get; set; }

    public bool CccDefecto { get; set; }

    public string BanCodigo { get; set; } = null!;

    public string SucCodigo { get; set; } = null!;

    public string CccCodigo { get; set; } = null!;

    public string? CccIban { get; set; }

    public virtual Banco BanCodigoNavigation { get; set; } = null!;

    public virtual Tsscliente Clr { get; set; } = null!;
}
