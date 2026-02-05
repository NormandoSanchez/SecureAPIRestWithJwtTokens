using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Services.Geographics
{
    /// <summary>
    /// Proporciona servicios relacionados con la entidad Provincia.
    /// </summary>
    /// <param name="mapper">Mapper para la entidad Provincia.</param>
    /// <param name="genericRepository">Repositorio genérico para la entidad Provincia. </param>
    public class ProvinciaService(IMapper mapper, IGenericRepository<Provincia> genericRepository) : IGenericService<ProvinciaDto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<Provincia> _genericRepository = genericRepository;

        public Task AddAsync(ProvinciaDto entidad)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProvinciaDto entidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recupera todas las provincias.
        /// </summary>
        /// <param name="filtros">Diccionario de filtros para la consulta.</param>
        /// <returns>Lista de ProvinciasResponse</returns>
        public async Task<List<ProvinciaDto>?> GetAllAsync(Dictionary<string, object>? filtros = null)
        {
            var provincias = await _genericRepository.GetAllAsync(filtros);
            var provinciasResponse = _mapper.Map<List<ProvinciaDto>>(provincias);

            return provinciasResponse;
        }

        /// <summary>
        /// Recupera una provincia por su ID.
        /// </summary>
        /// <param name="id">Identificador de la provincia.</param>
        /// <returns>ProvinciaResponse</returns>
        public async Task<ProvinciaDto?> GetByIdAsync(int id)
        {
            var provincia = await _genericRepository.GetByIdAsync(id);
            var provinciaResponse = _mapper.Map<ProvinciaDto>(provincia);

            return provinciaResponse;
        }
    }
}
