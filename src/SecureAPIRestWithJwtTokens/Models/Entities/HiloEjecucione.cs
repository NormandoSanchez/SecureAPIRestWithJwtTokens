
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class HiloEjecucione
{
    public int HilId { get; set; }

    public string Proceso { get; set; } = null!;

    public int UsuId { get; set; }
}
