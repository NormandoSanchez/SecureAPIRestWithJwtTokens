
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class IftgrupoProceso
{
    public int GrpId { get; set; }

    public string GrpDescrip { get; set; } = null!;

    public bool GrpEnUsoExtrac { get; set; }

    public bool GrpEnUsoActua { get; set; }

    public int GrpMaxLog { get; set; }

    public virtual ICollection<UnidadNegocio> Unns { get; set; } = new List<UnidadNegocio>();
}
