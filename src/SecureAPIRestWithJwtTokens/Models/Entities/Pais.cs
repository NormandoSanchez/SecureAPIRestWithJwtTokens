namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Pais
{
    public int PaiId { get; set; }

    public string PaiNombre { get; set; } = null!;

    public virtual ICollection<ComunidadAut> ComunidadesAut { get; set; } = [];
}
