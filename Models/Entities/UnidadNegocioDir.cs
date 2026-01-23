namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnidadNegocioDireccion
{
    public int UnnId { get; set; }

    public int DirId { get; set; }

    public bool DirDefecto { get; set; }

    public string? DirTelf1 { get; set; }

    public string? DirTelf2 { get; set; }

    public string? DirFax1 { get; set; }

    public string? DirFax2 { get; set; }

    public virtual Direccion Dir { get; set; } = null!;

    public virtual UnidadNegocio UnidadNegocio { get; set; } = null!;
}
