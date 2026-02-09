using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TarjetasTipo
{
    public int TatId { get; set; }

    public string TatDescripcion { get; set; } = null!;

    public int? TatLimiteMin { get; set; }

    public int? TatLimiteMax { get; set; }

    public int? TatCaducidad { get; set; }

    public bool TatAlternativa { get; set; }

    public int? TatIdasociada { get; set; }

    public bool TatLigadaEdad { get; set; }

    public bool TatUsoVirtual { get; set; }

    public virtual ICollection<CampaniasTarjetasTipo> CampaniasTarjetasTipos { get; set; } = new List<CampaniasTarjetasTipo>();

    public virtual ICollection<ClientesTarjeta> ClientesTarjeta { get; set; } = new List<ClientesTarjeta>();

    public virtual ICollection<Formulario> Formularios { get; set; } = new List<Formulario>();

    public virtual TarjetasTiposUsoVirtual? TarjetasTiposUsoVirtual { get; set; }

    public virtual ICollection<DocumentosLopd> Docs { get; set; } = new List<DocumentosLopd>();
}
