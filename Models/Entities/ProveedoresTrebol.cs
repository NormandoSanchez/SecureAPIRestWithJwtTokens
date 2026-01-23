using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresTrebol
{
    public int PvtId { get; set; }

    public string PvtRazonSocial { get; set; } = null!;

    public string PvtIdFiscal { get; set; } = null!;

    public string PvtCuenta { get; set; } = null!;

    public DateTime PvtFalta { get; set; }

    public int PvtUalta { get; set; }

    public DateTime? PvtFmodificacion { get; set; }

    public int? PvtUmodificacion { get; set; }

    public virtual ICollection<ProveedoresTrebolLaboratorio> ProveedoresTrebolLaboratorios { get; set; } = new List<ProveedoresTrebolLaboratorio>();
}
