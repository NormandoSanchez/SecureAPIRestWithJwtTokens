namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnidadNegocio
{
    public int UnnId { get; set; }

    public string UnnTrebol { get; set; } = null!;

    public string? UnnIdSoe { get; set; }

    public string UnnNombre { get; set; } = null!;

    public bool UnnActiva { get; set; }

    public bool UnnEsCentral { get; set; }

    public bool UnnEsAlmacen { get; set; }

    public bool UnnEsAlmacenTrebol { get; set; }

    public bool UnnFarmatic { get; set; }

    public decimal? UnnCoefRrhhventa { get; set; }

    public short? GpeId { get; set; }

    public bool UnnModeloDual { get; set; }

    public bool UnnCanonTrebol { get; set; }

    public bool? UnnTiendaWeb { get; set; }

    public string? UnnWeb { get; set; }

    public DateTime UnnFincTrebol { get; set; }

    public DateTime? UnnFbajaTrebol { get; set; }

    /// <summary>
    /// Fecha de Alta
    /// </summary>
    public DateTime UnnFalta { get; set; }

    /// <summary>
    /// Id. Usuario Alta
    /// </summary>
    public int UnnUalta { get; set; }

    /// <summary>
    /// Fecha Modificación
    /// </summary>
    public DateTime? UnnFmodificacion { get; set; }

    /// <summary>
    /// Identificador del último Usuario que modificó
    /// </summary>
    public int? UnnUmodificacion { get; set; }

    public virtual ICollection<ArticulosExclBonif> ArticulosExclBonifs { get; set; } = [];

    public virtual CanonTrebolDef? CanonTrebolDef { get; set; }

    public virtual ContadoresLotesEnvio? ContadoresLotesEnvio { get; set; }

    public virtual ICollection<EmpleadoUnidadNegocio> EmpleadoUnidadesNegocio { get; set; } = [];

    public virtual ICollection<EnviosFormulario> EnviosFormularios { get; set; } = [];

    public virtual ICollection<FacturasTrebolConceptosUnn> FacturasTrebolConceptosUnns { get; set; } = [];

    public virtual GrupoPedido? Gpe { get; set; }

    public virtual ICollection<IftopExtraccionResultado> IftopExtraccionResultados { get; set; } = [];

    public virtual ICollection<PedidosNflineasUnn> PedidosNflineasUnns { get; set; } = [];

    public virtual ICollection<RealesDecretosUnn> RealesDecretosUnns { get; set; } = [];

    public virtual ICollection<Tsscliente> Tssclientes { get; set; } = [];

    public virtual ICollection<TssprocesoAux> TssprocesoAuxes { get; set; } = [];

    public virtual ICollection<TsstclnoGestion> TsstclnoGestions { get; set; } = [];

    public virtual ICollection<TsstiposCliente> TsstiposClientes { get; set; } = [];

    public virtual ICollection<UnidadesNegocioCf> UnidadesNegocioCfs { get; set; } = [];

    public virtual ICollection<UnidadesNegocioCie> UnidadesNegocioCies { get; set; } = [];

    public virtual UnidadNegocioDb? UnidadNegocioDb { get; set; }

    public virtual ICollection<UnidadNegocioDireccion> UnidadNegocioDirecciones { get; set; } = [];

    public virtual ICollection<UnidadesNegocioObj> UnidadesNegocioObjs { get; set; } = [];

    public virtual ICollection<UnidadesNegocioSoc> UnidadesNegocioSocs { get; set; } = [];

    public virtual ICollection<UnidadesNegocioVf> UnidadesNegocioVfs { get; set; } = [];

    public virtual ICollection<Campania> Cams { get; set; } = [];

    public virtual ICollection<IftgrupoProceso> Grps { get; set; } = [];

    public virtual ICollection<PromocionesCierre> Prcs { get; set; } = [];

    public virtual ICollection<Promocione> Prms { get; set; } = [];

    public virtual ICollection<UsuariosUpn> Upns { get; set; } = [];
}
