namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ComunidadAut
{
    public int CauId { get; set; }

    public string CauNombre { get; set; } = null!;

    public int PaiId { get; set; }

    public bool CauExencionIva { get; set; }

    public int? CauConsejo { get; set; }

    public virtual Pais Pais { get; set; } = null!;

    public virtual ICollection<Provincia> Provincias { get; set; } = [];
}
