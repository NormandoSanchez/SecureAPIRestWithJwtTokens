using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class IftoperacionesDefinicion
{
    public int OpeId { get; set; }

    public string OpeTipo { get; set; } = null!;

    public string OpeDescrip { get; set; } = null!;

    public string OpeSentencia { get; set; } = null!;

    public bool OpeInhabilitada { get; set; }

    public string OpeFrecuencia { get; set; } = null!;

    public string? OpeDia { get; set; }

    public int? OpeNumDia { get; set; }

    public string? OpeHoraEjec { get; set; }

    public int OpeOrden { get; set; }

    public virtual ICollection<IftextraccionControl> IftextraccionControls { get; set; } = new List<IftextraccionControl>();

    public virtual ICollection<IftopExtraccionResultado> IftopExtraccionResultados { get; set; } = new List<IftopExtraccionResultado>();
}
