using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PedidosNflinea
{
    public int PedId { get; set; }

    public int PelLinea { get; set; }

    public string ArtDescripcion { get; set; } = null!;

    public short TivId { get; set; }

    public int PelUnidades { get; set; }

    public decimal PelPrecioU { get; set; }

    public decimal PelImpBruto { get; set; }

    public string PelAplicarDtoLin { get; set; } = null!;

    public decimal PelDtoLinea { get; set; }

    public decimal PelImpDto { get; set; }

    public decimal PelImpNeto { get; set; }

    public decimal PelPorImpuesto { get; set; }

    public decimal PelImpCuota { get; set; }

    public decimal PelImpToital { get; set; }

    public virtual PedidosNf Ped { get; set; } = null!;

    public virtual ICollection<PedidosNflineasUnn> PedidosNflineasUnns { get; set; } = new List<PedidosNflineasUnn>();
}
