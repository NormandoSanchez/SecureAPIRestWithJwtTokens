using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Configuracion
{
    public int ConId { get; set; }

    public int ConMaxLotesTarjetas { get; set; }

    public int ConMaxLotesDocum { get; set; }

    public string? ConMensajeOrganizacion { get; set; }

    public bool ConActualizarBi { get; set; }

    public string? ConPathEmisionPedidosPnf { get; set; }

    public string? ConPathEmisionFacturasTrebol { get; set; }

    public string? ConPathEmisionInformeResumen { get; set; }

    public string? ConPathEmisionFacturasTss { get; set; }

    public string? ConPathExcelCargaObjPromo { get; set; }

    public decimal ConMma { get; set; }

    public decimal ConMmp { get; set; }
}
