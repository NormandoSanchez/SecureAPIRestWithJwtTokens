using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FacturasTrebol
{
    public int FtrId { get; set; }

    public int UnnId { get; set; }

    public int SocId { get; set; }

    public short TstId { get; set; }

    public int? UnnIdcliente { get; set; }

    public int? SocIdcliente { get; set; }

    public int? ParIdcliente { get; set; }

    public short FtrEjercicio { get; set; }

    public short FtrMes { get; set; }

    public DateTime FtrFecha { get; set; }

    public DateTime FtrFechaVenc { get; set; }

    public string FtrNumDoc { get; set; } = null!;

    public bool FtrProforma { get; set; }

    public bool FtrCopias { get; set; }

    public bool FtrVerResumida { get; set; }

    public short FpaId { get; set; }

    public string? BanCodigo { get; set; }

    public string? SucCodigo { get; set; }

    public string? CccCodigo { get; set; }

    public string? CccIban { get; set; }

    public decimal FtrBaseImponible { get; set; }

    public decimal FtrCuotas { get; set; }

    public decimal FtrTotal { get; set; }

    public short? TftId { get; set; }

    public bool FtrAbonada { get; set; }

    public int? FtrIdabono { get; set; }

    public string? FtrRefExterna { get; set; }

    public virtual ICollection<FacturasTrebolLinea> FacturasTrebolLineas { get; set; } = new List<FacturasTrebolLinea>();

    public virtual ICollection<FacturasTrebolLineasBase> FacturasTrebolLineasBases { get; set; } = new List<FacturasTrebolLineasBase>();

    public virtual ICollection<FacturasTrebolResumenLin> FacturasTrebolResumenLins { get; set; } = new List<FacturasTrebolResumenLin>();

    public virtual FormasPago Fpa { get; set; } = null!;

    public virtual FacturasTrebol? FtrIdabonoNavigation { get; set; }

    public virtual ICollection<FacturasTrebol> InverseFtrIdabonoNavigation { get; set; } = new List<FacturasTrebol>();

    public virtual TipoServiciosTrebol Tst { get; set; } = null!;

    public virtual ICollection<Fttraspaso> Recs { get; set; } = new List<Fttraspaso>();

    public virtual ICollection<FtpickingOv> Vcps { get; set; } = new List<FtpickingOv>();
}
