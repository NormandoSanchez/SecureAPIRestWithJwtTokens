namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CalendarioFestivosDia
{
    public int CafId { get; set; }

    public DateTime CafFestivo { get; set; }

    public virtual CalendarioFestivo Caf { get; set; } = null!;
}
