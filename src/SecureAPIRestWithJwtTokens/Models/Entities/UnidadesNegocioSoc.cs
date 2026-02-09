using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnidadesNegocioSoc
{
    public int UnnId { get; set; }

    public int SocId { get; set; }

    public bool SocFacTrebol { get; set; }

    public bool SocTitular { get; set; }

    public short? FpaId { get; set; }

    public virtual ICollection<FacturasTrebolConcepto> FacturasTrebolConceptos { get; set; } = new List<FacturasTrebolConcepto>();

    public virtual FormasPago? Fpa { get; set; }

    public virtual Sociedade Soc { get; set; } = null!;

    public virtual UnidadNegocio Unn { get; set; } = null!;
}
