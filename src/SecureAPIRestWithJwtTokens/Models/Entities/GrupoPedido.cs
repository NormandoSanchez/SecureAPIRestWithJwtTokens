
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class GrupoPedido
{
    public short GpeId { get; set; }

    public string GpeDescrip { get; set; } = null!;

    public virtual ICollection<UnidadNegocio> UnidadesNegocios { get; set; } = new List<UnidadNegocio>();
}
