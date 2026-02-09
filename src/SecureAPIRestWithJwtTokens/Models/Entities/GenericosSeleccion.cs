using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class GenericosSeleccion
{
    public int IdGrpGen { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public int UsrId { get; set; }

    public virtual Generico Generico { get; set; } = null!;
}
