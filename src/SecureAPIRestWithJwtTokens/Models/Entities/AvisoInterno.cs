namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class AvisoInterno
{
    public long AviId { get; set; }

    public DateTime AviFecha { get; set; }

    public string AviImportancia { get; set; } = null!;

    public string ProId { get; set; } = null!;

    public int? UsuIdorigen { get; set; }

    public int UsuIddestino { get; set; }

    public string? AviAsunto { get; set; }

    public string? AviMensaje { get; set; }

    public bool AviVisto { get; set; }

    public string? AviTextoLink { get; set; }

    public string? AviLink { get; set; }

    public string? AviTarget { get; set; }

    public virtual ICollection<AvisoDocumento> AvisosDocumentos { get; set; } = new List<AvisoDocumento>();
    public virtual Proceso Proceso { get; set; } = null!;
}
