using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssfacturasClientesLinea
{
    public int FslId { get; set; }

    public int FtsId { get; set; }

    public DateTime FslFecha { get; set; }

    public int ClrId { get; set; }

    public int FacIdVenta { get; set; }

    public string? FslNumDoc { get; set; }

    public int FacIdLineaVenta { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public string FslDescrip { get; set; } = null!;

    public short ArtFamilia { get; set; }

    public decimal FslPrecio { get; set; }

    public bool FslMostrar { get; set; }

    public int FslUnidades { get; set; }

    public string FslTipoAporta { get; set; } = null!;

    public decimal FslImpAporta { get; set; }

    public decimal FslImpBruto { get; set; }

    public decimal FslImpDtos { get; set; }

    public decimal FslImpNeto { get; set; }

    public decimal FslPorImpuesto { get; set; }

    public bool FslOcultar { get; set; }

    public string? FslRecetaPendiente { get; set; }

    public virtual TssfacturasCliente Fts { get; set; } = null!;

    public virtual ICollection<FacturasTrebolLinea> FacturasTrebolLineas { get; set; } = new List<FacturasTrebolLinea>();
}
