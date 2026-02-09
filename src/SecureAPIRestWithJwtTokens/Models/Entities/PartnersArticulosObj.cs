using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersArticulosObj
{
    public int ParId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public short ObvEjercicio { get; set; }

    public short ObvMes { get; set; }

    public int ObvUnidades { get; set; }

    public decimal ObvImnporte { get; set; }

    public virtual PartnersArticulo PartnersArticulo { get; set; } = null!;
}
