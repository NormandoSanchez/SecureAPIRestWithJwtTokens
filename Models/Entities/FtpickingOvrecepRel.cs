using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FtpickingOvrecepRel
{
    public int VcpId { get; set; }

    public int RecId { get; set; }

    public bool VcpManual { get; set; }

    public virtual FtpickingOv Vcp { get; set; } = null!;
}
