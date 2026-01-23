namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Banco
{
    public string BanCodigo { get; set; } = null!;

    public string BanNombre { get; set; } = null!;

    public virtual ICollection<SociedadesCcc> SociedadesCccs { get; set; } = new List<SociedadesCcc>();

    public virtual ICollection<TssclientesCcc> TssclientesCccs { get; set; } = new List<TssclientesCcc>();
}
