using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PlataformasArticulo
{
    public long ParId { get; set; }

    public int PlaId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public bool ParDesactivada { get; set; }

    public bool ParHabitual { get; set; }

    public DateTime ParFinicio { get; set; }

    public DateTime? ParFfin { get; set; }

    public decimal ParPvp { get; set; }

    public decimal ParPvlt { get; set; }

    public decimal ParDtot { get; set; }

    public decimal ParPvlp { get; set; }

    public decimal ParDtop { get; set; }

    public decimal? ParClporcent { get; set; }

    public decimal? ParClimporte { get; set; }

    public decimal ParMargenTrebol { get; set; }

    public decimal ParMargenFarma { get; set; }

    public bool ParDtopajustado { get; set; }

    public DateTime ParFalta { get; set; }

    public int ParUalta { get; set; }

    public DateTime? ParFmodificacion { get; set; }

    public int? ParUmodificacion { get; set; }

    public decimal ParPvap { get; set; }

    public decimal? ParMpva { get; set; }

    public virtual Plataforma Pla { get; set; } = null!;

    public virtual PlataformasArticulosObserv? PlataformasArticulosObserv { get; set; }
}
