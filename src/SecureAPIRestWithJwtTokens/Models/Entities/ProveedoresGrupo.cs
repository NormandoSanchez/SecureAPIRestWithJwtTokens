using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresGrupo
{
    public int GpvId { get; set; }

    public string PvfCodigo { get; set; } = null!;

    public bool PvfUsarContsDirs { get; set; }

    public virtual GruposProveedore Gpv { get; set; } = null!;

    public virtual Proveedore PvfCodigoNavigation { get; set; } = null!;
}
