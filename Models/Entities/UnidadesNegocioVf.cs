using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnidadesNegocioVf
{
    public int UnnId { get; set; }

    public short VefId { get; set; }

    public string VefNombre { get; set; } = null!;

    public int? VefColor { get; set; }

    public bool VefGenerico { get; set; }

    public bool VefBaja { get; set; }

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
