using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class EmpleadosDocumento
{
    public int EdoId { get; set; }

    public int EmpId { get; set; }

    public string EdoLink { get; set; } = null!;

    public string EdoDescrip { get; set; } = null!;

    public virtual Empleado Emp { get; set; } = null!;
}
