using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class LaboratoriosObj
{
    public string LabCodigo { get; set; } = null!;

    public short ObvEjercicio { get; set; }

    public short ObvMes { get; set; }

    public string ObvGenericos { get; set; } = null!;

    public bool ObvCerrado { get; set; }

    public decimal ObvImporteRecep { get; set; }

    public int ObvUdsRecep { get; set; }

    public decimal ObvImporteRepo { get; set; }

    public int ObvUdsRepo { get; set; }

    public virtual Laboratorio LabCodigoNavigation { get; set; } = null!;
}
