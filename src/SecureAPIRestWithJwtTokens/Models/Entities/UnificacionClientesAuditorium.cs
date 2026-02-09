
namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class UnificacionClientesAuditorium
{
    public int UnifId { get; set; }

    public int CliIdmantener { get; set; }

    public int? CliIdunificarNombre { get; set; }

    public int? CliIdunificarApellidos { get; set; }

    public int? CliIdunificarIdFiscal { get; set; }

    public int? CliIdunificarEmail { get; set; }

    public int? CliIdunificarMovil { get; set; }

    public int? CliIdunificarTelf { get; set; }

    public int? CliIdunificarFnac { get; set; }

    public int? CliIdunificarDir { get; set; }

    public int UsrId { get; set; }

    public DateTime Fecha { get; set; }

    public virtual ICollection<UnificacionClientesAuditoriaCliente> UnificacionClientesAuditoriaClientes { get; set; } = new List<UnificacionClientesAuditoriaCliente>();
}
