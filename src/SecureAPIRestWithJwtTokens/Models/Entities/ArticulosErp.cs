namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ArticulosErp
{
    public string ArtCodigo { get; set; } = null!;

    public DateTime ArtFaltaErp { get; set; }

    public int ArtUaltaErp { get; set; }

    public DateTime? ArtFmodificacion { get; set; }

    public int? ArtUmodificacion { get; set; }

    public string? ArtObservaciones { get; set; }

    public decimal? ArtMpva { get; set; }

    public virtual ICollection<ArticulosErpsinonimo> ArticulosErpsinonimos { get; set; } = new List<ArticulosErpsinonimo>();
}
