using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository;

namespace SecureAPIRestWithJwtTokens.Services.Avisos;

/// <summary>
/// Proporciona servicios relacionados con la entidad AvisoInterno.
/// </summary>
/// <param name="mapper"></param>
/// <param name="genericRepository"></param>
public class AvisoService(IMapper mapper, IGenericRepository<AvisoInterno> genericRepository) : IGenericService<AvisoInternoDto>    
{
    private readonly IMapper _mapper = mapper;
    private readonly IGenericRepository<AvisoInterno> _genericRepository = genericRepository;

    public Task AddAsync(AvisoInternoDto entidad)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Obtiene avisos internos.
    /// </summary>
    /// <param name="filtros">Filtros opcionales para la consulta.</param>
    /// <returns>Lista de avisos internos.</returns>
    public async Task<List<AvisoInternoDto>?> GetAllAsync(Dictionary<string, object>? filtros = null)
    {
        var avisos = await _genericRepository.GetAllAsync(filtros);
        var avisosResponse = _mapper.Map<IEnumerable<AvisoInternoDto>>(avisos);

        return [.. avisosResponse];
    }

    /// <summary>
    /// Obtiene un aviso interno por su ID.
    /// </summary>
    /// <param name="id">Identificador del aviso interno.</param>
    /// <returns>AvisoInternoDto</returns>
    public async Task<AvisoInternoDto?> GetByIdAsync(int id)
    {

        var aviso = await _genericRepository.GetByIdAsync(id);
        var avisoResponse = _mapper.Map<AvisoInternoDto>(aviso);
        return avisoResponse;
    }

    public Task UpdateAsync(AvisoInternoDto entidad)
    {
        throw new NotImplementedException();
    }
}
