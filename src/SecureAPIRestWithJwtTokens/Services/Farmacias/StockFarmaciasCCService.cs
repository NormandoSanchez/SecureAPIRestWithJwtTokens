using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Services.Farmacias
{


    /// <summary>
    /// Proporciona servicios relacionados con el stock de farmacias Click &amp; Collect.
    /// </summary>
    /// <param name="mapper">Mapper para la entidad dirreccion</param>
    /// <param name="stockFarmaciaCCResultRepo">Repo para el stock de farmacias Click &amp; Collect</param>
    public class StockFarmaciasCCService(IMapper mapper, IGenericRepository<FarmaciaStock> stockFarmaciaCCResultRepo) : IStockFarmaciaCCResultService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<FarmaciaStock> _stockFarmaciaCCRepo = stockFarmaciaCCResultRepo;

        /// <summary>
        /// Obtiene el stock de farmacias Click &amp; Collect para un producto específico.
        /// </summary>
        /// <param name="filtros">Filtros para la búsqueda.</param>
        /// <returns>Lista de StockFarmaciasResponse</returns>
        public async Task<List<StockFarmaciaDto>> GetAllAsync(IDictionary<string, object> filtros)
        {
            var stockFarmaciasCC = await _stockFarmaciaCCRepo.GetAllAsync(filtros);

            return _mapper.Map<List<StockFarmaciaDto>>(stockFarmaciasCC);
        }
    }
}
