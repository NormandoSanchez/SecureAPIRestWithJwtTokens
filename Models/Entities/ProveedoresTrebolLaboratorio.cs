using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresTrebolLaboratorio
{
    public int PtlId { get; set; }

    public int PvtId { get; set; }

    public string LabCodigo { get; set; } = null!;

    public DateTime PtlInicio { get; set; }

    public DateTime? PtlFin { get; set; }

    public virtual Laboratorio LabCodigoNavigation { get; set; } = null!;

    public virtual ProveedoresTrebol Pvt { get; set; } = null!;
}
