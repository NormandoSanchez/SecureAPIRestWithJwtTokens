using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssprocesoAux
{
    public int TsxId { get; set; }

    public int UnnId { get; set; }

    public int TsxEjercicio { get; set; }

    public short TsxMes { get; set; }

    public DateTime TsxDesde { get; set; }

    public DateTime TsxHasta { get; set; }

    public int ClrId { get; set; }

    public short TivId { get; set; }

    public decimal TsxPorImpuesto { get; set; }

    public decimal TsxImpFijoMe { get; set; }

    public int TsxUdsCalMe { get; set; }

    public decimal TsxImpAddMe { get; set; }

    public int TsxUdsTotalMe { get; set; }

    public decimal TsxImpBaseMe { get; set; }

    public decimal TsxImpMeliq { get; set; }

    public decimal TsxBaseLiq { get; set; }

    public decimal TsxCuotaLiq { get; set; }

    public decimal TsxTotalLiq { get; set; }

    public virtual Tsscliente Clr { get; set; } = null!;

    public virtual TiposIva Tiv { get; set; } = null!;

    public virtual ICollection<TssprocesoAuxLinea> TssprocesoAuxLineas { get; set; } = new List<TssprocesoAuxLinea>();

    public virtual UnidadNegocio Unn { get; set; } = null!;

    public virtual ICollection<TssfacturasCliente> Fts { get; set; } = new List<TssfacturasCliente>();
}
