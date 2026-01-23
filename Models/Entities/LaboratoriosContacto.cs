using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class LaboratoriosContacto
{
    public string LabCodigo { get; set; } = null!;

    public int ConId { get; set; }

    public bool ConDefecto { get; set; }

    public int DptId { get; set; }

    public virtual Contacto Con { get; set; } = null!;

    public virtual Departamento Dpt { get; set; } = null!;

    public virtual Laboratorio LabCodigoNavigation { get; set; } = null!;
}
