using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class DescripcionArticuloErp
{
    public string IdCodigoArticu { get; set; } = null!;

    public string DescArticuAntiguo { get; set; } = null!;

    public string DescArticuNuevo { get; set; } = null!;

    public double? Pvp { get; set; }

    public string? DescPlataforma { get; set; }

    public string? DescTipoIva { get; set; }

    public string? DescLaboratorio { get; set; }

    public DateTime? FechaInserccion { get; set; }
}
