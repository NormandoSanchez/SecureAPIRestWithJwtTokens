
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class GruposProveedoresCalculosPvp
{
    public int CalLinId { get; set; }

    public int GpvId { get; set; }

    public short TivId { get; set; }

    public short FamId { get; set; }

    public string? GrpFacturacion { get; set; }

    public decimal CalFactor { get; set; }

    public virtual GruposProveedore Gpv { get; set; } = null!;

    public virtual TiposIva Tiv { get; set; } = null!;
}
