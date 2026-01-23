using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersArticulo
{
    public int ParId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public virtual Partner Par { get; set; } = null!;

    public virtual ICollection<PartnersArticulosObj> PartnersArticulosObjs { get; set; } = new List<PartnersArticulosObj>();
}
