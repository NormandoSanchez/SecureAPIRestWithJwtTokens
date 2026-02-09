
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class HistoricoTarifa
{
    public long HtrId { get; set; }

    public string ArtCodigo { get; set; } = null!;

    public DateTime HtrFcambio { get; set; }

    public decimal HtrImpAnterior { get; set; }

    public decimal HtrImpAplicar { get; set; }
}
