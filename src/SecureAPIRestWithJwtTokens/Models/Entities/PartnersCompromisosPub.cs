namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PartnersCompromisosPub
{
    public int ParId { get; set; }

    public int CmpId { get; set; }

    public int PubId { get; set; }

    public int PubNumIns { get; set; }

    public virtual PartnersCompromiso PartnersCompromiso { get; set; } = null!;

    //public virtual Publicacione Pub { get; set; } = null!;
}
