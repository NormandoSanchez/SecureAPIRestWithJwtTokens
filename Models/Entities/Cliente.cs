using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Cliente
{
    public int CliId { get; set; }

    public string CliNombre { get; set; } = null!;

    public string CliApellido1 { get; set; } = null!;

    public string? CliApellido2 { get; set; }

    public int DirId { get; set; }

    public string CliSexo { get; set; } = null!;

    public DateTime? CliFnacimiento { get; set; }

    public bool CliRecibirNotificaciones { get; set; }

    public int OriId { get; set; }

    public string? CliIdfiscal { get; set; }

    public string? CliTelf { get; set; }

    public string? CliMovil { get; set; }

    public string? CliEmail { get; set; }

    public DateTime? CliFultVenta { get; set; }

    public int? UnnIdultVenta { get; set; }

    public DateTime? CliFultMovimiento { get; set; }

    public int? UnnIdultMovimiento { get; set; }

    public DateTime CliFalta { get; set; }

    public int CliUalta { get; set; }

    public DateTime? CliFmodificacion { get; set; }

    public int? CliUmodificacion { get; set; }

    public DateTime? CliFbaja { get; set; }

    public int? CliUbaja { get; set; }

    public virtual ICollection<CampaniasCliente> CampaniasClientes { get; set; } = new List<CampaniasCliente>();

    public virtual ClientesCalidadDato? ClientesCalidadDato { get; set; }

    public virtual ICollection<ClientesComentario> ClientesComentarios { get; set; } = new List<ClientesComentario>();

    public virtual ICollection<ClientesDocumentosLopd> ClientesDocumentosLopds { get; set; } = new List<ClientesDocumentosLopd>();

    public virtual ICollection<ClientesTarjeta> ClientesTarjeta { get; set; } = new List<ClientesTarjeta>();

    public virtual Direccion Dir { get; set; } = null!;

    public virtual Origene Ori { get; set; } = null!;

    public virtual ICollection<TarjetasCambiosCliente> TarjetasCambiosClientes { get; set; } = new List<TarjetasCambiosCliente>();

    public virtual ICollection<Cuenta> Cues { get; set; } = new List<Cuenta>();

    public virtual ICollection<DocumentosLopd> Docs { get; set; } = new List<DocumentosLopd>();
}
