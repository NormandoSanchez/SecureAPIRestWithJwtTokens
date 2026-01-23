using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CuentasDetalleArticulo
{
    public int CudId { get; set; }

    public int CdaLinea { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public decimal CdaImporteVenta { get; set; }

    public int CdaCantidad { get; set; }

    public decimal CdaImporteBonif { get; set; }

    public decimal CdaPuntos { get; set; }

    public string? CdaTipoAportacion { get; set; }
}
