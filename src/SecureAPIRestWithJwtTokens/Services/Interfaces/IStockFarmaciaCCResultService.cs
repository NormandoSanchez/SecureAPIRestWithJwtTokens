using SecureAPIRestWithJwtTokens.Models.DTO;

namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

public interface IStockFarmaciaCCResultService
{
    Task<List<StockFarmaciaDto>> GetAllAsync(IDictionary<string, object> filtros);
}