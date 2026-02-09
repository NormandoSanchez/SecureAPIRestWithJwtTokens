
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TiposAcuerdoPartnerCompPub
{
    public short TapId { get; set; }

    public int CmpId { get; set; }

    public int PubId { get; set; }

    public int PubNumIns { get; set; }

    //public virtual Publicacione Pub { get; set; } = null!;

    public virtual TiposAcuerdoPartnerComp TiposAcuerdoPartnerComp { get; set; } = null!;
}
