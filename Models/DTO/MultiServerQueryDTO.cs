using SecureAPIRestWithJwtTokens.Models.InternalDTO;

namespace SecureAPIRestWithJwtTokens.Models.DTO
{
    public class MultiServerQueryDto
    {
        public string Query { get; set; } = string.Empty;
        public List<FarmaciaDBConnectionInternal> Connections { get; set; } = [];
        public Dictionary<string, object>? Parameters { get; set; }
    }
}