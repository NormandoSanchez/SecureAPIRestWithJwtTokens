using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ContadoresPnf
{
    public int UnnId { get; set; }

    public short CpcEjercicio { get; set; }

    public int DptId { get; set; }

    public int CpcContador { get; set; }

    public virtual Departamento Dpt { get; set; } = null!;
}
