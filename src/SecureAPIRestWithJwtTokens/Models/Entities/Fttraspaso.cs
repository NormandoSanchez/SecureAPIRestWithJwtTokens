
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Fttraspaso
{
    public int RecId { get; set; }

    public int UnnId { get; set; }

    public string PvfCodigo { get; set; } = null!;

    public string RtrNumDoc { get; set; } = null!;

    public DateTime RecFecha { get; set; }

    public int RecIdFarmatic { get; set; }

    public bool RtrConforme { get; set; }

    public bool RtrFacturada { get; set; }

    public virtual ICollection<FttraspasosLinea> FttraspasosLineas { get; set; } = new List<FttraspasosLinea>();

    public virtual ICollection<FacturasTrebol> Ftrs { get; set; } = new List<FacturasTrebol>();
}
