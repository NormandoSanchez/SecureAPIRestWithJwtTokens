using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresNfdir
{
    public int PnfId { get; set; }

    public int DirId { get; set; }

    public bool DirDefecto { get; set; }

    public int DptId { get; set; }

    public string? DirTelf1 { get; set; }

    public string? DirTelf2 { get; set; }

    public string? DirFax1 { get; set; }

    public string? DirFax2 { get; set; }

    public virtual Direccion Dir { get; set; } = null!;

    public virtual Departamento Dpt { get; set; } = null!;

    public virtual ProveedoresNoFarmaceutico Pnf { get; set; } = null!;
}
