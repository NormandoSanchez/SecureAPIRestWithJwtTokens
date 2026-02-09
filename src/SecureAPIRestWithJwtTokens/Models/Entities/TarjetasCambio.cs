using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TarjetasCambio
{
    public int TacId { get; set; }

    public string TacDescripcion { get; set; } = null!;

    public bool TacActivo { get; set; }

    public int TacUalta { get; set; }

    public DateTime TacFalta { get; set; }

    public int? TacUmodificacion { get; set; }

    public DateTime? TacFmodificacion { get; set; }

    public virtual ICollection<TarjetasCambiosCliente> TarjetasCambiosClientes { get; set; } = new List<TarjetasCambiosCliente>();
}
