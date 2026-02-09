
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnificacionClientesAuditoriaCliente
{
    public int UnifId { get; set; }

    public int CliIdunificado { get; set; }

    public virtual UnificacionClientesAuditorium Unif { get; set; } = null!;
}
