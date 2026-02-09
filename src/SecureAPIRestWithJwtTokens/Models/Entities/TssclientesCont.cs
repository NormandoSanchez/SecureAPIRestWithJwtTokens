using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssclientesCont
{
    public int ClrId { get; set; }

    public int ConId { get; set; }

    public bool ConDefecto { get; set; }

    public int DptId { get; set; }

    public virtual Tsscliente Clr { get; set; } = null!;

    public virtual Contacto Con { get; set; } = null!;

    public virtual Departamento Dpt { get; set; } = null!;
}
