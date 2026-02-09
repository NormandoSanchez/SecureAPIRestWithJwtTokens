using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssclientesDir
{
    public int ClrId { get; set; }

    public int DirId { get; set; }

    public bool DirDefecto { get; set; }

    public bool DirFactura { get; set; }

    public bool DirEnvioFactura { get; set; }

    public bool DirProblematica { get; set; }

    public string? DirTelf1 { get; set; }

    public string? DirTelf2 { get; set; }

    public string? DirFax1 { get; set; }

    public string? DirFax2 { get; set; }

    public virtual Tsscliente Clr { get; set; } = null!;

    public virtual Direccion Dir { get; set; } = null!;
}
