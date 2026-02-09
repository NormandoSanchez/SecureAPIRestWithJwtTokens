using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FacturasTrebolLinea
{
    public int FtrId { get; set; }

    public int FtlNumLinea { get; set; }

    public string FtlTipoLinea { get; set; } = null!;

    public string? ArtCodigo { get; set; }

    public short? ArtFamilia { get; set; }

    public string? FacNumDoc { get; set; }

    public int? FacIdLinea { get; set; }

    public int? CftId { get; set; }

    public bool FtlResumir { get; set; }

    public string FtlDescripcion { get; set; } = null!;

    public decimal FtlPrecio { get; set; }

    public int FtlUnidades { get; set; }

    public decimal FtlBaseCalculo { get; set; }

    public decimal FtlPorCalculo { get; set; }

    public decimal FtlBaseImponible { get; set; }

    public decimal FtlPorImpuesto { get; set; }

    public decimal FtlCuota { get; set; }

    public decimal FtlTotalLinea { get; set; }

    public bool FtlValorMinimo { get; set; }

    public virtual FacturasTrebol Ftr { get; set; } = null!;

    public virtual ICollection<TssfacturasClientesLinea> Fsls { get; set; } = new List<TssfacturasClientesLinea>();

    public virtual ICollection<PedidosNflineasUnn> Plus { get; set; } = new List<PedidosNflineasUnn>();
}
