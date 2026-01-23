using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PedidosNflineasUnn
{
    public int PluId { get; set; }

    public int PedId { get; set; }

    public int PedLinea { get; set; }

    public int UnnId { get; set; }

    public bool PeuFacTrebol { get; set; }

    public int PeuUnidades { get; set; }

    public decimal PeuImpBruto { get; set; }

    public decimal PeuImpDto { get; set; }

    public decimal PeuImpNeto { get; set; }

    public decimal PeuImpCuota { get; set; }

    public decimal PeuImpTotal { get; set; }

    public virtual PedidosNflinea PedidosNflinea { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;

    public virtual ICollection<FacturasTrebolLinea> FacturasTrebolLineas { get; set; } = new List<FacturasTrebolLinea>();
}
