using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PedidosNfconformar
{
    public int PedId { get; set; }

    public int UnnId { get; set; }

    public int PcoId { get; set; }

    public DateTime PcoFecha { get; set; }

    public string PcoDocFactura { get; set; } = null!;

    public decimal PcoImpConformado { get; set; }

    public bool PcoConformeTotal { get; set; }

    public bool PcoContabilizado { get; set; }

    public virtual PedidosNfunn PedidosNfunn { get; set; } = null!;
}
