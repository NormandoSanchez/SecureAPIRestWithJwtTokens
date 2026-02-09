using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TmpIntermediaProveedor
{
    public string CodLaboratorio { get; set; } = null!;

    public string CodProveedor { get; set; } = null!;

    public string NomProveedor { get; set; } = null!;
}
