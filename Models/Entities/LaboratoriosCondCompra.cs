using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class LaboratoriosCondCompra
{
    public int CclId { get; set; }

    public string LabCodigo { get; set; } = null!;

    public int? GlaId { get; set; }

    public DateTime CclDesde { get; set; }

    public DateTime? CclHasta { get; set; }

    public short? FamId { get; set; }

    public decimal CclDto { get; set; }

    public virtual GruposLaboratorio? Gla { get; set; }

    public virtual Laboratorio LabCodigoNavigation { get; set; } = null!;
}
