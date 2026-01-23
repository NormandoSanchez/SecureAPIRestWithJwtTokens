
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UsuariosUpn
{
    public int UpnId { get; set; }

    public string Usuario { get; set; } = null!;

    public virtual ICollection<UnidadNegocio> Unns { get; set; } = new List<UnidadNegocio>();
}
