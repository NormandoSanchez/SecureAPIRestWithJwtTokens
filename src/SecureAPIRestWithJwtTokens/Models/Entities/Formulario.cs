namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Formulario
{
    public int ForId { get; set; }

    public string ForTipoMovimiento { get; set; } = null!;

    public string ForTipoElemento { get; set; } = null!;

    public string ForRangoInicio { get; set; } = null!;

    public string ForRangoFin { get; set; } = null!;

    public int? ForOrigen { get; set; }

    public int? ForDestino { get; set; }

    public string? ForRefExterna { get; set; }

    public int? ForLote { get; set; }

    public int? ForFormularioOrigen { get; set; }

    public bool? ForRepartida { get; set; }

    public bool? ForAgotadas { get; set; }

    public int? DocId { get; set; }

    public int? TatId { get; set; }

    public DateTime? ForFecha { get; set; }

    public DateTime ForFalta { get; set; }

    public int ForUalta { get; set; }

    public DateTime? ForFmodificacion { get; set; }

    public int? ForUmodificacion { get; set; }

    public virtual DocumentosLopd? Doc { get; set; }

    public virtual ICollection<FormulariosAnulacion> FormulariosAnulacions { get; set; } = new List<FormulariosAnulacion>();

    public virtual TarjetasTipo? Tat { get; set; }
}
