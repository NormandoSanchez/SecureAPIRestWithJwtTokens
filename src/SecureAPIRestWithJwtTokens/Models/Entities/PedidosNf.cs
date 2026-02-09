using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PedidosNf
{
    public int PedId { get; set; }

    public string PedDocumento { get; set; } = null!;

    public int PnfId { get; set; }

    public int DptId { get; set; }

    public string PedEstado { get; set; } = null!;

    public DateTime? PedFemision { get; set; }

    public DateTime? PedFanulacion { get; set; }

    public short FpaId { get; set; }

    public DateTime? PedFvencim { get; set; }

    public decimal PedImpBruto { get; set; }

    public decimal PedDtoProv { get; set; }

    public decimal PedDtoCab { get; set; }

    public decimal PedImpNeto { get; set; }

    public decimal PedImpCuotas { get; set; }

    public decimal PedImpTotal { get; set; }

    public string PedModoFactura { get; set; } = null!;

    public bool PedReFacturar { get; set; }

    public bool PedEntregaUnica { get; set; }

    public bool PedAvisos { get; set; }

    public int? PedUfirma { get; set; }

    public DateTime PedFalta { get; set; }

    public int PedUalta { get; set; }

    public DateTime? PedFmodificacion { get; set; }

    public int? PedUmodificacion { get; set; }

    public DateTime? PedFfirma { get; set; }

    public string? PedDescripcion { get; set; }

    public virtual Departamento Dpt { get; set; } = null!;

    public virtual ICollection<PedidosNflinea> PedidosNflineas { get; set; } = new List<PedidosNflinea>();

    public virtual ICollection<PedidosNfunn> PedidosNfunns { get; set; } = new List<PedidosNfunn>();

    public virtual ProveedoresNoFarmaceutico Pnf { get; set; } = null!;
}
