namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class NivelConsulta
{
    public int NicId { get; set; }

    public string NicDescrip { get; set; } = null!;

    public int? NicPadre { get; set; }

    public DateTime NicFalta { get; set; }

    public int NicUalta { get; set; }

    public DateTime? NicFmodificacion { get; set; }

    public int? NicUmodificacion { get; set; }

    public virtual ICollection<ConsultaSql> ConsultasSql { get; set; } = [];

    public virtual ICollection<NivelConsulta> Hijos { get; set; } = [];

    public virtual NivelConsulta? Padre { get; set; }
}
