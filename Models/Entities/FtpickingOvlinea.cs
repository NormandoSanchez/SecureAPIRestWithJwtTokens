using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FtpickingOvlinea
{
    public int VclId { get; set; }

    public int VcpId { get; set; }

    public int VelIdlinea { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public string ArtDescripcion { get; set; } = null!;

    public int VelUnidades { get; set; }

    public decimal VelPvp { get; set; }

    public decimal VelImportePvp { get; set; }

    public decimal VelPorcImpuestos { get; set; }

    public bool VelConforme { get; set; }

    public bool VelExcluirFt { get; set; }

    public virtual FtpickingOv Vcp { get; set; } = null!;
}
