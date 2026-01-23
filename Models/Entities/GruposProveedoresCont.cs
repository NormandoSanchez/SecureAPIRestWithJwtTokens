
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class GruposProveedoresCont
{
    public int GpvId { get; set; }

    public int ConId { get; set; }

    public bool ConDefecto { get; set; }

    public bool ConPropio { get; set; }

    public int DptId { get; set; }

    public virtual Contacto Con { get; set; } = null!;

    public virtual Departamento Dpt { get; set; } = null!;

    public virtual GruposProveedore Gpv { get; set; } = null!;
}
