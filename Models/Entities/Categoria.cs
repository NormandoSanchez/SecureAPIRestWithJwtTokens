using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Categoria
{
    public short CatId { get; set; }

    public string CatNombre { get; set; } = null!;
}
