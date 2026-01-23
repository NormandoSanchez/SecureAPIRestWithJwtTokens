namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class CalendarioFestivo
{
    public int CafId { get; set; }

    public int CafAno { get; set; }

    public string CafDescripcion { get; set; } = null!;

    public virtual ICollection<CalendarioFestivosDia> CalendarioFestivosDia { get; set; } = new List<CalendarioFestivosDia>();

    public virtual ICollection<UnidadesNegocioCf> UnidadesNegocioCfs { get; set; } = new List<UnidadesNegocioCf>();
}
