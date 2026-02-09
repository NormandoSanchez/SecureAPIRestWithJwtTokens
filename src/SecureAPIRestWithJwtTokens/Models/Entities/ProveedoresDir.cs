using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresDir
{
    public string PvfCodigo { get; set; } = null!;

    public int DirId { get; set; }

    public int DptId { get; set; }

    public bool DirDefecto { get; set; }

    public bool DirProblematica { get; set; }

    public bool DirPropia { get; set; }

    public string? DirTelf1 { get; set; }

    public string? DirTelf2 { get; set; }

    public string? DirFax1 { get; set; }

    public string? DirFax2 { get; set; }

    public virtual Direccion Dir { get; set; } = null!;

    public virtual Departamento Dpt { get; set; } = null!;

    public virtual Proveedore PvfCodigoNavigation { get; set; } = null!;
}
