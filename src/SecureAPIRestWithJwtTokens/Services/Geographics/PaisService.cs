using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Services.Geographics
{
    /// <summary>
    /// Proporciona servicios relacionados con la entidad País.
    /// </summary>
    /// <param name="mapper">Mapper para la entidad País.</param>
    /// <param name="genericRepository">Repositorio genérico para la entidad País.</param>
    public class PaisService(IMapper mapper, IGenericRepository<Pais> genericRepository) : IGenericService<PaisDto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<Pais> _genericRepository = genericRepository;

        public Task AddAsync(PaisDto entidad)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene todos los países.
        /// </summary>
        /// <param name="filtros">Sin uso</param>
        /// <returns>Lista de PaisResponse</returns>
        public async Task<List<PaisDto>?> GetAllAsync(Dictionary<string, object>? filtros = null)
        {
            // No pasamos Filtros porque no se aplican. (Deberia venir siempre a null)
            var paises = await _genericRepository.GetAllAsync(null);
            var paisesResponse = _mapper.Map<IEnumerable<PaisDto>>(paises);

            return [.. paisesResponse];
        }

        /// <summary>
        /// Obtiene un país por su ID.
        /// </summary>
        /// <param name="id">Identificador del país.</param>
        /// <returns>PaisResponse</returns>
        public async Task<PaisDto?> GetByIdAsync(int id)
        {

            var pais = await _genericRepository.GetByIdAsync(id);
            var paisResponse = _mapper.Map<PaisDto>(pais);
            return paisResponse;
        }

        public Task UpdateAsync(PaisDto entidad)
        {
            throw new NotImplementedException();
        }
    }
}
