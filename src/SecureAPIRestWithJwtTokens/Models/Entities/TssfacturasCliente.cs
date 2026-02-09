namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TssfacturasCliente
{
    public int FtsId { get; set; }

    public int UnnId { get; set; }

    public int FacIdContador { get; set; }

    public string FacNumDoc { get; set; } = null!;

    public DateTime FtsFecha { get; set; }

    public DateTime FtsFvencim { get; set; }

    public int ClrId { get; set; }

    public string ClrIdFiscal { get; set; } = null!;

    public int SocId { get; set; }

    public int? DirIdfac { get; set; }

    public int? DirIdenvio { get; set; }

    public bool FtsUnificada { get; set; }

    public decimal FtsBases { get; set; }

    public decimal FtsCuotas { get; set; }

    public decimal FtsTotal { get; set; }

    public bool FtsEditada { get; set; }

    public bool FtsFacTrebol { get; set; }

    public string? FtsObservaciones { get; set; }

    public string? FtsTextoFarmatic { get; set; }

    public bool? FtsExistio { get; set; }

    public virtual Tsscliente Clr { get; set; } = null!;

    public virtual Direccion? DirIdenvioNavigation { get; set; }

    public virtual Direccion? DirIdfacNavigation { get; set; }

    public virtual ICollection<TssfacturasClientesBasis> TssfacturasClientesBases { get; set; } = [];

    public virtual ICollection<TssfacturasClientesLinea> TssfacturasClientesLineas { get; set; } = [];

    public virtual ICollection<TssprocesoAux> Tsxes { get; set; } = [];
}
