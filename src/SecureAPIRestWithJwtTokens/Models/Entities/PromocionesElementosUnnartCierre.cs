using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesElementosUnnartCierre
{
    public int PcaId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public int PcaUdsObj { get; set; }

    public decimal PcaImporteObj { get; set; }

    public virtual PromocionesElementosUnncierre Pca { get; set; } = null!;
}
