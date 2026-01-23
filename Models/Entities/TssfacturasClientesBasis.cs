using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssfacturasClientesBasis
{
    public int FtsId { get; set; }

    public decimal FtbPorImpuesto { get; set; }

    public decimal FtbBaseImp { get; set; }

    public decimal FtbCuota { get; set; }

    public decimal FtbTotal { get; set; }

    public virtual TssfacturasCliente Fts { get; set; } = null!;
}
