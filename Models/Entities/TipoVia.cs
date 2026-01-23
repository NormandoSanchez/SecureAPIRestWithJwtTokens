namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TipoVia
{
    public int TviId { get; set; }

    public string TviNombre { get; set; } = null!;

    public bool TviDefecto { get; set; }

    public virtual ICollection<Direccion> Direcciones { get; set; } = [];
}
