using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TarjetasTiposUsoVirtual
{
    public int TatId { get; set; }

    public string TatRangoInicio { get; set; } = null!;

    public string TatRangoFin { get; set; } = null!;

    public string? TatUltimaTarjeta { get; set; }

    public virtual TarjetasTipo Tat { get; set; } = null!;
}
