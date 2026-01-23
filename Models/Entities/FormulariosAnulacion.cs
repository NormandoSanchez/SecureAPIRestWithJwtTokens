using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FormulariosAnulacion
{
    public int FoaId { get; set; }

    public int ForId { get; set; }

    public string FoaRangoInicio { get; set; } = null!;

    public string FoaRangoFin { get; set; } = null!;

    public DateTime FoaFecha { get; set; }

    public string FoaMotivo { get; set; } = null!;

    public int UsrId { get; set; }

    public virtual Formulario For { get; set; } = null!;
}
