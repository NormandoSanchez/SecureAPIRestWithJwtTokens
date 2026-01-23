namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Poblacion
{
    public int PobId { get; set; }

    public string PobNombre { get; set; } = null!;

    public int PrvId { get; set; }

    public int PaiId { get; set; }

    public virtual ICollection<Direccion> Direcciones { get; set; } = [];

    public virtual Provincia Provincia { get; set; } = null!;
}
