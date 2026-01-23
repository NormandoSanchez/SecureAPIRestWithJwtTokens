using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresNoFarmaceutico
{
    public int PnfId { get; set; }

    public string PnfRazonSocial { get; set; } = null!;

    public string PnfIdFiscal { get; set; } = null!;

    public bool PnfActivo { get; set; }

    public short? FpaId { get; set; }

    public string? PnfWeb { get; set; }

    public string? PnfCodCliTrebol { get; set; }

    public string? PnfObserv { get; set; }

    public DateTime PnfFalta { get; set; }

    public int PnfUalta { get; set; }

    public DateTime? PnfFmodificacion { get; set; }

    public int? PnfUmodificacion { get; set; }

    public virtual FormasPago? Fpa { get; set; }

    public virtual ICollection<PedidosNf> PedidosNfs { get; set; } = new List<PedidosNf>();

    public virtual ICollection<ProveedoresNfcondicione> ProveedoresNfcondiciones { get; set; } = new List<ProveedoresNfcondicione>();

    public virtual ICollection<ProveedoresNfcontacto> ProveedoresNfcontactos { get; set; } = new List<ProveedoresNfcontacto>();

    public virtual ICollection<ProveedoresNfdir> ProveedoresNfdirs { get; set; } = new List<ProveedoresNfdir>();
}
