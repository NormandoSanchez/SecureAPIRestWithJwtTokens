
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Generico
{
    public int IdGrpGen { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public bool ArtPreferido { get; set; }

    public string? ArtObservacion { get; set; }

    public bool ArtEnviado { get; set; }

    public virtual ICollection<GenericosSeleccion> GenericosSeleccions { get; set; } = new List<GenericosSeleccion>();
}
