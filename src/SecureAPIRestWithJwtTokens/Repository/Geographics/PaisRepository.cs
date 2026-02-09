using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;

namespace SecureAPIRestWithJwtTokens.Repository.Geographics
{
    /// <summary>
    /// Repositorio para gestionar operaciones relacionadas con países.
    /// </summary>
    /// <param name="context">Contexto de la base de datos.</param>
    /// <param name="logger">Instancia de logger para registrar información y errores.</param>
    public class PaisRepository(TrebolDbContext context, ILogger<PaisRepository> logger) : IGenericRepository<Pais>
    {
        private readonly TrebolDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<PaisRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Agrega un nuevo país a la tabla paises 
        /// </summary>
        /// <param name="pais">El país a agregar.</param>
        /// <returns></returns>
        public async Task AddAsync(Pais pais)
        {
            ArgumentNullException.ThrowIfNull(pais);
            var paisDb = await _context.Paises.FirstOrDefaultAsync(p => p.PaiId == pais.PaiId);
            if (paisDb != null)
            {
                throw new InvalidOperationException($"El país con ID {pais.PaiId} ya existe.");
            }

            try
            {
                await _context.Paises.AddAsync(pais);
                await _context.SaveChangesAsync();
                _logger.LogInformation("País {PaiId} ({PaiNombre}) agregado correctamente.", pais.PaiId, pais.PaiNombre);

            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al agregar el país {PaiId} ({PaiNombre}).", pais.PaiId, pais.PaiNombre);
                throw new InvalidOperationException(
                    $"Error al guardar el país {pais.PaiId} ({pais.PaiNombre}): {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Retorna todos los países de la tabla paises
        /// </summary>
        /// <param name="filtros">Filtros opcionales para la consulta. (Sin uso aqui)</param>
        /// <returns></returns>
        public async Task<IEnumerable<Pais>?> GetAllAsync(IDictionary<string, object>? filtros = null)
        {
            _logger.LogInformation("Recuperando todos los países.");
            return await _context.Paises.ToListAsync();
        }

        /// <summary>
        /// Recupera un país por su ID.
        /// </summary>
        /// <param name="id">ID del país.</param>
        /// <returns>El país correspondiente al ID proporcionadoo null si no se encuentra.</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Pais?> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("El ID del país no puede ser cero.", nameof(id));
            }
            _logger.LogInformation("Recuperando país con ID {PaiId}.", id);
            return await _context.Paises.AsNoTracking()
                                .FirstOrDefaultAsync(p => p.PaiId == id);
        }

        /// <summary>
        /// Actualiza la información de un país existente en la tabla paises
        /// </summary>
        /// <param name="pais">País a actualizar.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UpdateAsync(Pais pais)
        {
            ArgumentNullException.ThrowIfNull(pais);
            var paisDb = await _context.Paises
                                .FirstOrDefaultAsync(p => p.PaiId == pais.PaiId) ?? throw new InvalidOperationException($"El país con ID {pais.PaiId} no existe.");
            try
            {
                _context.Entry(paisDb).CurrentValues.SetValues(pais);
                await _context.SaveChangesAsync();
                _logger.LogInformation("País {PaiId} ({PaiNombre}) actualizado correctamente.", 
                                        pais.PaiId,
                                        pais.PaiNombre);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al actualizar el país {PaiId} ({PaiNombre}).", 
                                 pais.PaiId, 
                                 pais.PaiNombre);
                throw new InvalidOperationException(
                    $"Error al actualizar el país {pais.PaiId} ({pais.PaiNombre}): {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(5);
            throw new NotImplementedException();
        }
    }
}
