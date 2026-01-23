using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FtpickingOv
{
    public int VcpId { get; set; }

    public int UnnId { get; set; }

    public int VenId { get; set; }

    public DateTime VenFechaHora { get; set; }

    public int UnnIdcliente { get; set; }

    public string VenNumDoc { get; set; } = null!;

    public decimal VenTotal { get; set; }

    public int VenTotalUds { get; set; }

    public decimal VenTotalPvp { get; set; }

    public bool VenConforme { get; set; }

    public bool VenFacTrebol { get; set; }

    public virtual ICollection<FtpickingOvlinea> FtpickingOvlineas { get; set; } = new List<FtpickingOvlinea>();

    public virtual ICollection<FtpickingOvrecepRel> FtpickingOvrecepRels { get; set; } = new List<FtpickingOvrecepRel>();

    public virtual ICollection<FacturasTrebol> Ftrs { get; set; } = new List<FacturasTrebol>();
}
