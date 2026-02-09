using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Contacto
{
    public int ConId { get; set; }

    public string ConNombre { get; set; } = null!;

    public string? ConTelf { get; set; }

    public string? ConMovil { get; set; }

    public string? ConFax { get; set; }

    public string? ConMail { get; set; }

    public string? ConObs { get; set; }

    public virtual ICollection<GruposLaboratoriosCont> GruposLaboratoriosConts { get; set; } = new List<GruposLaboratoriosCont>();

    public virtual ICollection<GruposProveedoresCont> GruposProveedoresConts { get; set; } = new List<GruposProveedoresCont>();

    public virtual ICollection<LaboratoriosContacto> LaboratoriosContactos { get; set; } = new List<LaboratoriosContacto>();

    public virtual ICollection<ProveedoresContacto> ProveedoresContactos { get; set; } = new List<ProveedoresContacto>();

    public virtual ICollection<ProveedoresNfcontacto> ProveedoresNfcontactos { get; set; } = new List<ProveedoresNfcontacto>();

    public virtual ICollection<TssclientesCont> TssclientesConts { get; set; } = new List<TssclientesCont>();
}
