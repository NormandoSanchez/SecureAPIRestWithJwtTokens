namespace SecureAPIRestWithJwtTokens.Models.DTO;

public class AvisoInternoDto
{
    public int IdAviso {get; set;}    
    public string? Emisor { get; set; }
    public string? Importancia { get; set; }
    public DateTime Recibido { get; set; }
    public string? IdProceso { get; set; }
    public string? Proceso { get; set; }
    public string? Asunto { get; set; }
    public string? Visto { get; set; }
}
