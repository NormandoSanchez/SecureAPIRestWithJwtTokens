namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Provincia
{
    public int PrvId { get; set; }

    public string PrvNombre { get; set; } = null!;

    public int CauId { get; set; }

    public int PaiId { get; set; }

    public virtual ComunidadAut ComunidadAutonoma { get; set; } = null!;

    public virtual ICollection<Poblacion> Poblaciones { get; set; } = [];

    public virtual ICollection<Direccion> Direcciones { get; set; } = [];
}
