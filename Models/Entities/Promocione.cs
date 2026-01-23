using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Promocione
{
    public int PrmId { get; set; }

    public string PrmDescripcion { get; set; } = null!;

    public bool PrmActiva { get; set; }

    public string PrmTipo { get; set; } = null!;

    public int PfrId { get; set; }

    public DateTime PrmFalta { get; set; }

    public int PrmUalta { get; set; }

    public DateTime? PmrFmodificacion { get; set; }

    public int? PrmUmodificacion { get; set; }

    public DateTime? PrmFcierre { get; set; }

    public int? PrmUcierre { get; set; }

    public virtual PromocionesFranja Pfr { get; set; } = null!;

    public virtual ICollection<PromocionesCierre> PromocionesCierres { get; set; } = new List<PromocionesCierre>();

    public virtual ICollection<PromocionesElemento> PromocionesElementos { get; set; } = new List<PromocionesElemento>();

    public virtual ICollection<UnidadNegocio> Unns { get; set; } = new List<UnidadNegocio>();
}
