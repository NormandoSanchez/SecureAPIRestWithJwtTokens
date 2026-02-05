using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Services.Geographics
{
    /// <summary>
    /// Proporciona servicios relacionados con la entidad Población.
    /// </summary>
    /// <param name="mapper">Mapper para la entidad Población.</param>
    /// <param name="genericRepository">Repositorio genérico para la entidad Población.</param>
    public class PoblacionService(IMapper mapper, IGenericRepository<Poblacion> genericRepository) : IGenericService<PoblacionDto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<Poblacion> _genericRepository = genericRepository;

        public Task AddAsync(PoblacionDto entidad)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PoblacionDto entidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recupera todas las poblaciones.
        /// </summary>
        /// <param name="filtros">Diccionario de filtros para la consulta.</param>
        /// <returns>Lista de PoblacionResponse</returns>
        public async Task<List<PoblacionDto>?> GetAllAsync(Dictionary<string, object>? filtros = null)
        {
            var poblaciones = await _genericRepository.GetAllAsync(filtros);
            var poblacionesResponse = _mapper.Map<List<PoblacionDto>>(poblaciones);
            return poblacionesResponse;
        }

        /// <summary>
        /// Recupera una población por su ID.
        /// </summary>
        /// <param name="id">Identificador de la población.</param>
        /// <returns>PoblacionResponse</returns>
        public async Task<PoblacionDto?> GetByIdAsync(int id)
        {
            var poblacion = await _genericRepository.GetByIdAsync(id);
            var poblacionResponse = _mapper.Map<PoblacionDto>(poblacion);

            return poblacionResponse;
        }
    }
}
