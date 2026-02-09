using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TStockDiarioActualizado
{
    public DateTime FechaActualizacion { get; set; }

    public string Idfarmacia { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Idarticu { get; set; } = null!;

    public int Stockactual { get; set; }
}
