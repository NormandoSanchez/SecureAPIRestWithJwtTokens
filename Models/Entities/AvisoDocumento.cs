namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class AvisoDocumento
{
    public long AviId { get; set; }

    public long AvdId { get; set; }

    public string DocLink { get; set; } = null!;

    public virtual AvisoInterno Avi { get; set; } = null!;
}
