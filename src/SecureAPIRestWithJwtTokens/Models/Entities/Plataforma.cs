using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Plataforma
{
    public int PlaId { get; set; }

    public string PlaNombre { get; set; } = null!;

    public string? PlaSufijo { get; set; }

    public string? PvfCodigo { get; set; }

    public bool PlaPrevConsumo { get; set; }

    public bool PlaReposicion { get; set; }

    public bool PlaAplicaCargoLog { get; set; }

    public short? PlaCargoLogTiv { get; set; }

    public decimal? PlaCargoLogImporte { get; set; }

    public decimal? PlaCargoLogPorcent { get; set; }

    public bool PlaLiquidacion { get; set; }

    public bool PlaFactTrebol { get; set; }

    public short? PlaModeloFt { get; set; }

    public bool PlaAsegurarMaf { get; set; }

    public bool PlaEditCondFarma { get; set; }

    public int? PlaIdCartera { get; set; }

    public string? PlaIdantigua { get; set; }

    public bool PlaActiva { get; set; }

    public bool PlaSinPlat { get; set; }

    public bool? PlaPdtesPlat { get; set; }

    public DateTime PlaFalta { get; set; }

    public int PlaUalta { get; set; }

    public DateTime? PlaFmodificacion { get; set; }

    public int? PlaUmodificacion { get; set; }

    public short PlaModeloPva { get; set; }

    public virtual ICollection<PlataformasArticulo> PlataformasArticulos { get; set; } = new List<PlataformasArticulo>();

    public virtual Proveedore? PvfCodigoNavigation { get; set; }
}
