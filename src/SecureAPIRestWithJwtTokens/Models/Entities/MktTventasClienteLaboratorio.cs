using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class MktTventasClienteLaboratorio
{
    public string? Farmacia { get; set; }

    public string? Cn { get; set; }

    public string? Descripcion { get; set; }

    public int? Idcliente { get; set; }

    public string? Nombrecompleto { get; set; }

    public string? Telefono { get; set; }

    public string? Movil { get; set; }

    public string? Email { get; set; }
}
