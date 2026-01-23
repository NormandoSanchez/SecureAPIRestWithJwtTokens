using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FttraspasosLinea
{
    public int RecId { get; set; }

    public int RelIdlinea { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public string ArtDescripcion { get; set; } = null!;

    public short FamId { get; set; }

    public string? PvfProvHab { get; set; }

    public short? RelCalculoPuc { get; set; }

    public short TivId { get; set; }

    public decimal RelPvp { get; set; }

    public decimal RelPvl { get; set; }

    public decimal RelDto { get; set; }

    public int RelUdsTraspaso { get; set; }

    public decimal RelPuc { get; set; }

    public decimal RelImpTraspaso { get; set; }

    public int SocId { get; set; }

    public bool RelExcluidaFt { get; set; }

    public virtual Fttraspaso Rec { get; set; } = null!;
}
