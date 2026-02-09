using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PedidosNfunn
{
    public int PedId { get; set; }

    public int UnnId { get; set; }

    public string PeuNumero { get; set; } = null!;

    public int DirIdentrega { get; set; }

    public int UnnIdfactura { get; set; }

    public int SocIdfactura { get; set; }

    public int DirIdfactura { get; set; }

    public string PeuConformado { get; set; } = null!;

    public bool PeuRecibido { get; set; }

    public int? PeuUsuRecibe { get; set; }

    public string? PeuObserv { get; set; }

    public virtual PedidosNf Ped { get; set; } = null!;

    public virtual ICollection<PedidosNfconformar> PedidosNfconformars { get; set; } = new List<PedidosNfconformar>();
}
