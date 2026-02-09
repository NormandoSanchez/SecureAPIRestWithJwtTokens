using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Cuenta
{
    public int CueId { get; set; }

    public decimal CueImpBonificacion { get; set; }

    public decimal CuePuntos { get; set; }

    public int CueBonos { get; set; }

    public decimal CueBonosImporte { get; set; }

    public string? CueUmodificacion { get; set; }

    public DateTime? CueFmodificacion { get; set; }

    public virtual ICollection<CuentasBono> CuentasBonos { get; set; } = new List<CuentasBono>();

    public virtual ICollection<CuentasDetalleHistorico> CuentasDetalleHistoricos { get; set; } = new List<CuentasDetalleHistorico>();

    public virtual ICollection<CuentasDetalle> CuentasDetalles { get; set; } = new List<CuentasDetalle>();

    public virtual ICollection<Cliente> Clis { get; set; } = new List<Cliente>();
}
