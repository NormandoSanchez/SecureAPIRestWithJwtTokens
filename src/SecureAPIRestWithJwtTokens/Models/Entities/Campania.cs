namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Campania
{
    public int CamId { get; set; }

    public string CamDescripcion { get; set; } = null!;

    /// <summary>
    /// &apos;T&apos;: Tarjetas &apos;C&apos;: Clientes
    /// </summary>
    public string CamClase { get; set; } = null!;

    public bool CamDefecto { get; set; }

    public DateTime? CamFechaInicio { get; set; }

    public DateTime? CamFechaFin { get; set; }

    public DateTime CamFalta { get; set; }

    public int CamUalta { get; set; }

    public DateTime? CamFmodificacion { get; set; }

    public int? CamUmodificacion { get; set; }

    public virtual ICollection<CampaniasCliente> CampaniasClientes { get; set; } = new List<CampaniasCliente>();

    public virtual ICollection<CampaniasTarjetasTipo> CampaniasTarjetasTipos { get; set; } = new List<CampaniasTarjetasTipo>();

    public virtual ICollection<UnidadNegocio> Unns { get; set; } = new List<UnidadNegocio>();
}
