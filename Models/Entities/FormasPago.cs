
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class FormasPago
{
    public short FpaId { get; set; }

    public string FpaNombre { get; set; } = null!;

    public bool FpaCliente { get; set; }

    public bool FpaProveedor { get; set; }

    public bool FpaDomBanco { get; set; }

    public virtual ICollection<FacturasTrebol> FacturasTrebols { get; set; } = new List<FacturasTrebol>();

    public virtual ICollection<FormasPagoDia> FormasPagoDia { get; set; } = new List<FormasPagoDia>();

    public virtual ICollection<ProveedoresNoFarmaceutico> ProveedoresNoFarmaceuticos { get; set; } = new List<ProveedoresNoFarmaceutico>();

    public virtual ICollection<Tsscliente> Tssclientes { get; set; } = new List<Tsscliente>();

    public virtual ICollection<UnidadesNegocioSoc> UnidadesNegocioSocs { get; set; } = new List<UnidadesNegocioSoc>();
}
