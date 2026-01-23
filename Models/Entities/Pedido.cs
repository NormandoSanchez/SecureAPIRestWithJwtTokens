using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Pedido
{
    public int PedId { get; set; }

    public string PvfCodigo { get; set; } = null!;
}
