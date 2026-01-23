using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresContacto
{
    public string PvfCodigo { get; set; } = null!;

    public int ConId { get; set; }

    public bool ConDefecto { get; set; }

    public bool ConPropio { get; set; }

    public int DptId { get; set; }

    public virtual Contacto Con { get; set; } = null!;

    public virtual Departamento Dpt { get; set; } = null!;

    public virtual Proveedore PvfCodigoNavigation { get; set; } = null!;
}
