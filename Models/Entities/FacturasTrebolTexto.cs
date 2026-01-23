using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FacturasTrebolTexto
{
    public short TftId { get; set; }

    public int SocId { get; set; }

    public string TftDescrip { get; set; } = null!;

    public string TftTexto { get; set; } = null!;

    public bool TftActivo { get; set; }

    public virtual Sociedade Soc { get; set; } = null!;
}
