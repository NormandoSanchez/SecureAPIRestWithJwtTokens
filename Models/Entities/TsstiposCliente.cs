using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TsstiposCliente
{
    public int UnnId { get; set; }

    public string TclId { get; set; } = null!;

    public string TclDescrip { get; set; } = null!;

    public string TclClase { get; set; } = null!;

    public string? TclIdpadre { get; set; }

    public string? TclLiquida { get; set; }

    public virtual ICollection<TsstiposCliente> InverseTsstiposClienteNavigation { get; set; } = new List<TsstiposCliente>();

    public virtual ICollection<Tsscliente> Tssclientes { get; set; } = new List<Tsscliente>();

    public virtual TsstiposCliente? TsstiposClienteNavigation { get; set; }

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
