using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Partner
{
    public int ParId { get; set; }

    public short TapId { get; set; }

    public int? GlaId { get; set; }

    public string? LabCodigo { get; set; }

    public bool ParHistorico { get; set; }

    public bool ParSuspendido { get; set; }

    public bool ParArticulos { get; set; }

    public DateTime ParInicio { get; set; }

    public DateTime? ParFin { get; set; }

    public string ParPlazoFact { get; set; } = null!;

    public DateTime ParPrimeraFact { get; set; }

    public DateTime? ParUltFact { get; set; }

    public short FpaId { get; set; }

    public int ParUalta { get; set; }

    public DateTime ParFalta { get; set; }

    public int? ParUmodificacion { get; set; }

    public DateTime? ParFmodificacion { get; set; }

    public int? ParUcambio { get; set; }

    public DateTime? ParFcambio { get; set; }

    public virtual ICollection<PartnersArticulo> PartnersArticulos { get; set; } = new List<PartnersArticulo>();

    public virtual ICollection<PartnersCompromiso> PartnersCompromisos { get; set; } = new List<PartnersCompromiso>();

    public virtual ICollection<PartnersConcepto> PartnersConceptos { get; set; } = new List<PartnersConcepto>();

    public virtual ICollection<PartnersDocumento> PartnersDocumentos { get; set; } = new List<PartnersDocumento>();

    public virtual ICollection<PartnersGestore> PartnersGestores { get; set; } = new List<PartnersGestore>();

    public virtual TiposAcuerdoPartner Tap { get; set; } = null!;
}
