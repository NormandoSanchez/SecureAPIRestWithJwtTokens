using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TempCliente
{
    public int Id { get; set; }

    public string? CliId { get; set; }

    public string? TarId { get; set; }

    public string? TarCb { get; set; }

    public string? TarTipo { get; set; }

    public string? TarIdAsociada { get; set; }

    public string? TarCbasociada { get; set; }

    public decimal? Puntos { get; set; }

    public int? Bonos { get; set; }

    public string? CliIdFarmacia { get; set; }

    public string? CliFarmacia { get; set; }

    public DateTime? CliFecAlta { get; set; }

    public string? CliNombre { get; set; }

    public string? CliApellido1 { get; set; }

    public string? CliApellido2 { get; set; }

    public string? CliDni { get; set; }

    public string? CliSexo { get; set; }

    public DateTime? CliFecNacimiento { get; set; }

    public string? CliDireccion { get; set; }

    public string? CliPoblacion { get; set; }

    public string? CliProvincia { get; set; }

    public string? CliCp { get; set; }

    public string? CliTelefono { get; set; }

    public string? CliTelfMovil { get; set; }

    public string? CliEmail { get; set; }

    public string? CliEstadoCivil { get; set; }

    public string? CliProfesion { get; set; }

    public string? CliNhijos { get; set; }

    public int? CliEdadHijo { get; set; }

    public int? CliAteFar { get; set; }

    public string? CliCompra { get; set; }

    public int? CliFrecuencia { get; set; }

    public string? CliInfoSobre { get; set; }

    public string? CliTxtInfoSobre5 { get; set; }

    public int? CliRecibirInfo { get; set; }

    public DateTime? CliFecCrea { get; set; }

    public string? CliUsuCrea { get; set; }

    public DateTime? CliFecMod { get; set; }

    public string? CliUsuMod { get; set; }

    public bool? CliActivo { get; set; }

    public bool? CliEliminado { get; set; }

    public string? CliOrigen { get; set; }
}
