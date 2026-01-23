using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CodigosBorrado
{
    public string CobTipo { get; set; } = null!;

    public string CobCodigo { get; set; } = null!;
}
