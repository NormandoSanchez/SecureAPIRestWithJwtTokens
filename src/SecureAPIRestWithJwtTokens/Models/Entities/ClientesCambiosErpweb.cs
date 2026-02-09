using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ClientesCambiosErpweb
{
    public int Id { get; set; }

    public int? CliId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Dni { get; set; }

    public string? IdTarjeta { get; set; }

    public string? FechaNacimiento { get; set; }

    public bool? RecibirNotificacion { get; set; }

    public DateTime? FechaBaja { get; set; }

    public int? UsuarioBaja { get; set; }

    public string? Tipo { get; set; }

    public bool? Modificacion { get; set; }

    public DateTime? Fecha { get; set; }
}
