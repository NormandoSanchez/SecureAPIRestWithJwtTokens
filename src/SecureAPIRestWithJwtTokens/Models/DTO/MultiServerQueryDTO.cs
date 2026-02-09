using SecureAPIRestWithJwtTokens.Models.InternalDTO;

namespace SecureAPIRestWithJwtTokens.Models.DTO
{
    /// <summary>
    ///  Modelo para consultas a múltiples servidores 
    /// </summary>
    public class MultiServerQueryDto
    {
        public string Query { get; set; } = string.Empty;
        public List<FarmaciaDBConnectionInternal> Connections { get; set; } = [];
        public Dictionary<string, object>? Parameters { get; set; }
    }
}