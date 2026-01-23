using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresCondCompra
{
    public int CcpId { get; set; }

    public string? PvfCodigo { get; set; }

    public DateTime CcpDesde { get; set; }

    public DateTime? CcpHasta { get; set; }

    public short? FamId { get; set; }

    public decimal CcpDto { get; set; }

    public virtual Proveedore? PvfCodigoNavigation { get; set; }
}
