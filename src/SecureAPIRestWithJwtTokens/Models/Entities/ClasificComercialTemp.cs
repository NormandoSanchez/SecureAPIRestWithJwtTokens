using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ClasificComercialTemp
{
    public short CctId { get; set; }

    public string CctDescripcion { get; set; } = null!;
}
