
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class GruposLaboratoriosDir
{
    public int GlaId { get; set; }

    public int DirId { get; set; }

    public int DptId { get; set; }

    public bool DirDefecto { get; set; }

    public bool DirFactura { get; set; }

    public bool DirProblemastica { get; set; }

    public bool DirPropia { get; set; }

    public string? DirTelf1 { get; set; }

    public string? DirTelf2 { get; set; }

    public string? DirFax1 { get; set; }

    public string? DirFax2 { get; set; }

    public virtual Direccion Dir { get; set; } = null!;

    public virtual Departamento Dpt { get; set; } = null!;

    public virtual GruposLaboratorio Gla { get; set; } = null!;
}
