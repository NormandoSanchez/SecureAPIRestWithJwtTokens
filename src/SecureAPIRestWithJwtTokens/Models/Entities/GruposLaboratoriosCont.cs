
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class GruposLaboratoriosCont
{
    public int GlaId { get; set; }

    public int ConId { get; set; }

    public bool ConDefecto { get; set; }

    public bool ConPropio { get; set; }

    public int DptId { get; set; }

    public virtual Contacto Con { get; set; } = null!;

    public virtual Departamento Dpt { get; set; } = null!;

    public virtual GruposLaboratorio Gla { get; set; } = null!;
}
