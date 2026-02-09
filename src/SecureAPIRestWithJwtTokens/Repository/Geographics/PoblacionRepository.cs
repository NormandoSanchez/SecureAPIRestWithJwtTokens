using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.EntityFrameworkCore;
using System.Data;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;

namespace SecureAPIRestWithJwtTokens.Repository.Geographics
{
    public class PoblacionRepository(TrebolDbContext context, ILogger<PoblacionRepository> logger) : IGenericRepository<Poblacion>
    {
        private readonly TrebolDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<PoblacionRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Devuelve todas las poblaciones de la base de datos de forma asíncrona.
        /// </summary>
        /// <param name="filtros">Diccionario de filtros opcionales para aplicar a la consulta.</param>
        /// <returns>Lista de poblaciones</returns>
        public async Task<IEnumerable<Poblacion>?> GetAllAsync(IDictionary<string, object>? filtros = null)
        {
            int IdPais = Common.ParseIntFilter(filtros, FilterConstants.PAIS, DefaultConstants.PAIS);
            int IdProvincia = Common.ParseIntFilter(filtros, FilterConstants.PROVINCIA, FilterConstants.ALL);

            if (IdProvincia == FilterConstants.ALL)
                if (IdPais == FilterConstants.ALL)
                {
                    _logger.LogInformation("Recuperando todas las poblaciones sin filtros.");

                    return await _context.Poblaciones.ToListAsync();
                }
                else
                {
                    _logger.LogInformation("Recuperando todas las poblaciones filtradas por país: {IdPais}.", 
                                            IdPais);

                    return await _context.Poblaciones
                                        .Where(c => c.PaiId == IdPais)
                                        .ToListAsync();
                }
            else
            {
                _logger.LogInformation("Recuperando todas las poblaciones filtradas por provincia: {IdProvincia}.",
                                        IdProvincia);

                return await _context.Poblaciones
                                .Where(p => p.PrvId == IdProvincia)
                                .ToListAsync();
            }
        }

        /// <summary>
        /// Recupera de forma asíncrona una entidad Poblacion por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad Poblacion a recuperar. Debe ser mayor que cero.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea contiene la entidad Poblacion si
        /// se encuentra; de lo contrario, null.</returns>
        /// <exception cref="ArgumentException">Se lanza si el id es cero.</exception>
        public async Task<Poblacion?> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("El ID de la poblacion no puede ser cero.", nameof(id));
            }
            _logger.LogInformation("Recuperando la poblacion con ID {PobId}.", id);

            return await _context.Poblaciones.AsNoTracking()
                                .FirstOrDefaultAsync(c => c.PobId == id);
        }

        /// <summary>
        /// Agrega de forma asíncrona una nueva poblacion a la base de datos.
        /// </summary>
        /// <remarks>Si una poblacion con el mismo <c>PobId</c> ya existe en la base de datos, se lanzará una
        /// <see cref="InvalidOperationException"/>.</remarks>
        /// <param name="entidad">La entidad <see cref="Poblacion"/> a agregar. No puede ser <see langword="null"/>.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si ya existe una poblacion con el mismo <c>PobId</c>, o si ocurre un error al guardar
        /// la entidad en la base de datos.</exception>
        public async Task AddAsync(Poblacion entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            var poblacionDb = await _context.Poblaciones.FirstOrDefaultAsync(c => c.PobId == entidad.PobId);
            if (poblacionDb != null)
            {
                throw new InvalidOperationException($"La poblacion con ID {entidad.PobId} ya existe.");
            }
            try
            {
                await _context.Poblaciones.AddAsync(entidad);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Poblacion {PobId} ({PobNombre}) agregada correctamente.", 
                                       entidad.PobId,
                                       entidad.PobNombre);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al agregar la poblacion {PobId} ({PobNombre}).", 
                                 entidad.PobId,
                                 entidad.PobNombre);
                throw new InvalidOperationException(
                    $"Error al guardar la poblacion {entidad.PobId} ({entidad.PobNombre}): {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza la información de una poblacion existente en la tabla Poblaciones
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UpdateAsync(Poblacion entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            var poblacionDb = await _context.Poblaciones.FirstOrDefaultAsync(c => c.PobId == entidad.PobId) ?? throw new InvalidOperationException($"La poblacion con ID {entidad.PobId} no existe.");
            try
            {
                _context.Entry(poblacionDb).CurrentValues.SetValues(entidad);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Poblacion {PobId} ({PobNombre}) actualizada correctamente.", 
                                        entidad.PobId,
                                        entidad.PobNombre);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al actualizar la poblacion {PobId} ({PobNombre}).", 
                                 entidad.PobId,
                                 entidad.PobNombre);
                throw new InvalidOperationException(
                    $"Error al actualizar la poblacion {entidad.PobId} ({entidad.PobNombre}): {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(5);
            throw new NotImplementedException();
        }
    }
}
