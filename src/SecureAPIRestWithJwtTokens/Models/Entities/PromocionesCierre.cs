using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesCierre
{
    public int PrcId { get; set; }

    public int PrmId { get; set; }

    public int PrcEjercicio { get; set; }

    public short PrcMes { get; set; }

    public int PfcId { get; set; }

    public virtual PromocionesFranjasCierre Pfc { get; set; } = null!;

    public virtual Promocione Prm { get; set; } = null!;

    public virtual ICollection<PromocionesElementosCierre> PromocionesElementosCierres { get; set; } = new List<PromocionesElementosCierre>();

    public virtual ICollection<UnidadNegocio> Unns { get; set; } = new List<UnidadNegocio>();
}
