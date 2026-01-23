using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository;

namespace SecureAPIRestWithJwtTokens.Services.Geographics
{
    /// <summary>
    /// Proporciona servicios relacionados con la entidad Comunidad Autónoma.
    /// </summary>
    /// <param name="mapper">Mapper para la entidad Comunidad Autónoma.</param>
    /// <param name="genericRepository">Repositorio genérico para la entidad Comunidad Autónoma.</param>
    public class ComunidadAutService(IMapper mapper, IGenericRepository<ComunidadAut> genericRepository) : IGenericService<ComunidadAutDto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<ComunidadAut> _genericRepository = genericRepository;

        public Task AddAsync(ComunidadAutDto entidad)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ComunidadAutDto entidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recupera todas las comunidades autónomas.
        /// </summary>
        /// <param name="filtros">Diccionario de filtros para la consulta.</param>
        /// <returns>Lista de ComunidadAutResponse</returns>
        public async Task<List<ComunidadAutDto>?> GetAllAsync(Dictionary<string, object>? filtros = null)
        {
            var comunidades = await _genericRepository.GetAllAsync(filtros);
            var comunidadesResponse = _mapper.Map<List<ComunidadAutDto>>(comunidades);
            return comunidadesResponse;
        }

        /// <summary>
        /// Obtiene una comunidad autónoma por su ID.
        /// </summary>
        /// <param name="id">Identificador de la comunidad autónoma.</param>
        /// <returns>ComunidadAutResponse</returns>
        public async Task<ComunidadAutDto?> GetByIdAsync(int id)
        {
            var comunidad = await _genericRepository.GetByIdAsync(id);
            var comunidadResponse = _mapper.Map<ComunidadAutDto>(comunidad);

            return comunidadResponse;
        }
    }
}
