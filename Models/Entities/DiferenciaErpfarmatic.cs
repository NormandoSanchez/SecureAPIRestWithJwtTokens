using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class DiferenciaErpfarmatic
{
    public string? Farmacia { get; set; }

    public string? Idfarmacia { get; set; }

    public string? Nombrefarmatic { get; set; }

    public string? Nombreerp { get; set; }

    public string? Farmaticvendedor { get; set; }

    public string? Erpvendedor { get; set; }
}
