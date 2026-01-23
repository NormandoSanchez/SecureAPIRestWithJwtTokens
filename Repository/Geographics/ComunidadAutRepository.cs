using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.EntityFrameworkCore;

namespace SecureAPIRestWithJwtTokens.Repository.Geographics
{
    public class ComunidadAutRepository(TrebolDbContext context, ILogger<ComunidadAutRepository> logger) : IGenericRepository<ComunidadAut>
    {
        private readonly TrebolDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<ComunidadAutRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Agrega de forma asíncrona una nueva comunidad autónoma a la base de datos.
        /// </summary>
        /// <remarks>Si una comunidad autónoma con el mismo <c>CauId</c> ya existe en la base de datos, se lanzará una
        /// <see cref="InvalidOperationException"/>.</remarks>
        /// <param name="entidad">La entidad <see cref="ComunidadAut"/> a agregar. No puede ser <see langword="null"/>.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si ya existe una comunidad autónoma con el mismo <c>CauId</c>, o si ocurre un error al guardar
        /// la entidad en la base de datos.</exception>
        public async Task AddAsync(ComunidadAut entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            var comunidadDb = await _context.ComunidadesAut.FirstOrDefaultAsync(c => c.CauId == entidad.CauId);
            if (comunidadDb != null)
            {
                throw new InvalidOperationException($"La comunidad autónoma con ID {entidad.CauId} ya existe.");
            }
            try
            {
                await _context.ComunidadesAut.AddAsync(entidad);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Comunidad autónoma {CauId} ({CauNombre}) agregada correctamente.", 
                                        entidad.CauId,
                                        entidad.CauNombre);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al agregar la comunidad autónoma {CauId} ({CauNombre}).", 
                                 entidad.CauId,
                                 entidad.CauNombre);
                throw new InvalidOperationException(
                    $"Error al guardar la comunidad autónoma {entidad.CauId} ({entidad.CauNombre}): {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Devuelve todas las comunidades autónomas de la base de datos de forma asíncrona.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ComunidadAut>?> GetAllAsync(IDictionary<string, object>? filtros = null)
        {
            // Parametro Pais
            int IdPais = Common.ParseIntFilter(filtros, FilterConstants.PAIS, FilterConstants.ALL);

            if (IdPais == FilterConstants.ALL)
            {
                _logger.LogInformation("Recuperando todas las comunidades autónomas");
                return await _context.ComunidadesAut.ToListAsync();
            }
            else
            {
                _logger.LogInformation("Recuperando todas las comunidades autónomas del país con ID {IdPais}",
                                        IdPais);
                                        
                return await _context.ComunidadesAut
                                .AsNoTracking()
                                .Where(c => c.PaiId == IdPais)  
                                .ToListAsync();
            }
        }

        /// <summary>
        /// Recupera de forma asíncrona una entidad ComunidadAut por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad ComunidadAut a recuperar. Debe ser mayor que cero.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea contiene la entidad ComunidadAut si
        /// se encuentra; de lo contrario, null.</returns>
        /// <exception cref="ArgumentException">Se lanza si el id es cero.</exception>
        public async Task<ComunidadAut?> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("El ID de la comunidad autónoma no puede ser cero.", nameof(id));
            }
            _logger.LogInformation("Recuperando la comunidad autónoma con ID {CauId}", id);

            return await _context.ComunidadesAut.AsNoTracking()
                                .FirstOrDefaultAsync(c => c.CauId == id);
        }

        /// <summary>
        /// Actualiza la información de una comuidadAut existente en la tabla ComunidadesAut
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UpdateAsync(ComunidadAut entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            var comunidadDb = await _context.ComunidadesAut.FirstOrDefaultAsync(c => c.CauId == entidad.CauId) ?? throw new InvalidOperationException($"La comunidad autónoma con ID {entidad.CauId} no existe.");
            try
            {
                _context.Entry(comunidadDb).CurrentValues.SetValues(entidad);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Comunidad autónoma {CauId} ({CauNombre}) actualizada correctamente.", 
                                        entidad.CauId, entidad.CauNombre);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al actualizar la comunidad autónoma {CauId} ({CauNombre}).", 
                                 entidad.CauId, entidad.CauNombre);
                throw new InvalidOperationException(
                    $"Error al actualizar la comunidad autónoma {entidad.CauId} ({entidad.CauNombre}): {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(5);
            throw new NotImplementedException();
        }
    }
}
