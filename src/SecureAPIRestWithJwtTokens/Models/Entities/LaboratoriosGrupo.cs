using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class LaboratoriosGrupo
{
    public int GlaId { get; set; }

    public string LabCodigo { get; set; } = null!;

    public bool LabUsarContsDirs { get; set; }

    public virtual GruposLaboratorio Gla { get; set; } = null!;

    public virtual Laboratorio LabCodigoNavigation { get; set; } = null!;
}
