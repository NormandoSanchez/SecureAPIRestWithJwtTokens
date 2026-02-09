using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SecureAPIRestWithJwtTokens.Tools;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;

namespace SecureAPIRestWithJwtTokens.Repository.Avisos;

/// <summary>
/// Repositorio para gestionar operaciones relacionadas con avisos internos.    
/// </summary>
/// <param name="context">Contexto de la base de datos.</param>
/// <param name="apiConfiguration">Configuración de la API.</param>
/// <param name="logger">Instancia de logger para registrar información y errores.</param>
public class AvisoRepository(TrebolDbContext context, 
                             ApiConfiguration apiConfiguration,
                             ILogger<AvisoRepository> logger) : IGenericRepository<AvisoInterno>
{
     private readonly TrebolDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
     private readonly ILogger<AvisoRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
     private readonly ApiConfiguration _apiConfiguration = apiConfiguration ?? throw new ArgumentNullException(nameof(apiConfiguration));

    /// <summary>
    /// Retorna todos los avisos internos de la tabla AvisosInternos
    /// </summary>
    /// <param name="filtros">Filtros opcionales para la consulta.</param>
    /// <returns>Una colección de avisos internos.</returns>
    public async Task<IEnumerable<AvisoInterno>?> GetAllAsync(IDictionary<string, object>? filtros = null)
    {
        int idUsuario = Common.ParseIntFilter(filtros, FilterConstants.USERID, FilterConstants.ALL);
        if (idUsuario == FilterConstants.ALL)
        {
            // Sin usuario no se pueden recuperar avisos
            return [];
        }

        bool vistos = Common.ParseBoolFilter(filtros, FilterConstants.VISTOS, false);
        bool antiguos = Common.ParseBoolFilter(filtros, FilterConstants.ANTIGUOS, false);
        int mesesTopeVistos = _apiConfiguration.Notificaciones.MesesTopeVistos;
        int mesesTopeAntiguos = _apiConfiguration.Notificaciones.MesesTopeAntiguos;
        DateTime? fechaTope = null;

        if (vistos)
            fechaTope = DateTime.Now.AddMonths(-mesesTopeVistos);
        if (antiguos)
            fechaTope = DateTime.Now.AddMonths(-mesesTopeAntiguos);

        _logger.LogInformation("Recuperando avisos internos.");

        var avisos = await _context.AvisosInternos
                             .Include(a => a.Proceso)
                             .Where(a => a.UsuIddestino == idUsuario
                                        && (vistos || !a.AviVisto == vistos)
                                        && (fechaTope == null || a.AviFecha >= fechaTope))
                             .ToListAsync();
        
        return avisos;                             
    }

    public Task AddAsync(AvisoInterno entidad)
    {
        // Implementación mínima para evitar warnings
        throw new NotImplementedException();
    }

    public Task UpdateAsync(AvisoInterno entidad)
    {
        // Implementación mínima para evitar warnings
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        // Implementación mínima para evitar warnings
        throw new NotImplementedException();
    }

    public Task<AvisoInterno?> GetByIdAsync(int id)
    {
        // Implementación mínima para evitar warnings
        throw new NotImplementedException();
    }
}
