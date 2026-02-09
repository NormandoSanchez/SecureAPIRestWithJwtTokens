using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ClientesErpWeb
{
    public int IdErp { get; set; }

    public string IdWeb { get; set; } = null!;

    public DateTime? Fecha { get; set; }
}
