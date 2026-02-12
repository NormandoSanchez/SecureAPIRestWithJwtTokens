using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.Tools;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using Microsoft.EntityFrameworkCore;
using System.Data;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Repository.Geographics
{
    public class ProvinciaRepository(TrebolDbContext context,
                                     ISqlDataServiceFactory sqlDataServiceFactory,
                                     ICryptoGraphicService cryptoGraphicService,
                                     ILogger<ProvinciaRepository> logger) : IGenericRepository<Provincia>
    {
        private readonly TrebolDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ISqlDataServiceFactory _sqlFactory = sqlDataServiceFactory ?? throw new ArgumentNullException(nameof(sqlDataServiceFactory));
        private readonly ICryptoGraphicService _cryptoGraphicService = cryptoGraphicService ?? throw new ArgumentNullException(nameof(cryptoGraphicService));
        private readonly ILogger<ProvinciaRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));  

        /// <summary>
        /// Devuelve todas las provincias de la base de datos de forma asíncrona.
        /// </summary>
        /// <param name="filtros">Diccionario de filtros opcionales para aplicar a la consulta.</param>
        /// <returns>Lista de Provincias</returns>
        public async Task<IEnumerable<Provincia>?> GetAllAsync(IDictionary<string, object>? filtros = null)
        {
            int IdPais = Common.ParseIntFilter(filtros, FilterConstants.PAIS, DefaultConstants.PAIS);
            int IdComunidadAut = Common.ParseIntFilter(filtros, FilterConstants.COMUNIDADAUT, FilterConstants.ALL);
            bool SoloFarmaciasCC = Common.ParseBoolFilter(filtros, FilterConstants.CLICK_COLLECT, false);

            if (SoloFarmaciasCC)
            {
                _logger.LogInformation("Recuperando todas las provincias con farmacias Click&Collect.");
                return await GetProvinciasConFarmaciasCCAsync();
            }
            else
            {
                if (IdComunidadAut == FilterConstants.ALL)
                {
                    if (IdPais == FilterConstants.ALL)
                    {
                        _logger.LogInformation("Recuperando todas las provincias sin filtrar por país o comunidad autónoma.");
                        return await _context.Provincias.ToListAsync();
                    }
                    else
                    {
                        _logger.LogInformation("Recuperando todas las provincias filtrando por país {IdPais}.",
                                                IdPais);

                        return await _context.Provincias
                                        .Where(c => c.PaiId == IdPais)
                                        .ToListAsync();
                    }
                }
                else
                {
                    _logger.LogInformation("Recuperando todas las provincias filtrando por comunidad autónoma {IdComunidadAut}.", 
                                            IdComunidadAut);

                    return await _context.Provincias
                                    .Where(c => c.CauId == IdComunidadAut)
                                    .ToListAsync();
                }
            }
        }

        /// <summary>
        /// Obtiene las provincias que tienen al menos una farmacia con servicio ClickCollect.
        /// </summary>
        /// <returns>Una colección de entidades <see cref="Provincia"/>.</returns>
        private async Task<List<Provincia>> GetProvinciasConFarmaciasCCAsync()
        {
            await using var sqlService = _sqlFactory.CreateService();
            var helper = new ConnectionStringHelper(_cryptoGraphicService);
            FarmaciaDBConnectionInternal? dbConnection = await helper.GetComunDBConnection();
            if (dbConnection != null)
            {
                 await sqlService.GetConnection(dbConnection);
                 // Construir query
                var query = QueryConstants.GET_CENTRALCOMUN_FARMACIAS_CLICK_COLLECT;
                var result = await sqlService.ExecuteQueryAsync(query, CommandType.Text);
                var farmaciasCC = result.MapToList<FarmaciaCCDto>() ?? [];
                 // Si no hay farmacias con C&C, devolvemos una lista vacía inmediatamente.
                if (farmaciasCC.Count == 0)
                {
                    return [];
                }
                
                // Extraemos  los IDs a un HashSet para una búsqueda ultra rápida (O(1)).
                var farmaciasCCIds = farmaciasCC.Select(f => f.IdFarmacia).ToHashSet();

                var unidadesNegocioData = await _context.UnidadNegocioDirecciones
                                                    .Include(ud => ud.Dir)
                                                    .ThenInclude(d => d.Provincia)
                                                    .Include(ud => ud.UnidadNegocio)
                                                    .Where(ud => ud.DirDefecto &&
                                                          ud.UnidadNegocio.UnnActiva &&
                                                          !ud.UnidadNegocio.UnnEsAlmacen &&
                                                          !ud.UnidadNegocio.UnnEsCentral)
                                                     .ToListAsync();
                
                var listaRet = unidadesNegocioData.Where(ud => farmaciasCCIds.Contains(ud.UnidadNegocio.UnnTrebol.Substring(1, 4)))
                                              .Select(ud => ud.Dir.Provincia)
                                              .Distinct()
                                              .OrderBy(p => p.PrvNombre)
                                              .ToList();

                _logger.LogInformation("Se han recuperado {Count} provincias con farmacias Click&Collect.",
                                    listaRet.Count);
                return listaRet;
            }
            else
            {
                _logger.LogError("No se pudo obtener la conexión a la base de datos común para recuperar las farmacias Click&Collect.");
                return [];
            }            
        }

        /// <summary>
        /// Recupera de forma asíncrona una entidad Provincia por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad Provincia a recuperar. Debe ser mayor que cero.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea contiene la entidad Provincia si
        /// se encuentra; de lo contrario, null.</returns>
        /// <exception cref="ArgumentException">Se lanza si el id es cero.</exception>
        public async Task<Provincia?> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("El ID de la provincia no puede ser cero.", nameof(id));
            }
            _logger.LogInformation("Recuperando la provincia con ID {Id}.", id);

            return await _context.Provincias.AsNoTracking()
                                .FirstOrDefaultAsync(c => c.PrvId == id);
        }

        /// <summary>
        /// Agrega de forma asíncrona una nueva provincia a la base de datos.
        /// </summary>
        /// <remarks>Si una provincia con el mismo <c>CauId</c> ya existe en la base de datos, se lanzará una
        /// <see cref="InvalidOperationException"/>.</remarks>
        /// <param name="entidad">La entidad <see cref="Provincia"/> a agregar. No puede ser <see langword="null"/>.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si ya existe una provincia con el mismo <c>PrvId</c>, o si ocurre un error al guardar
        /// la entidad en la base de datos.</exception>
        public async Task AddAsync(Provincia entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            var provinciaDb = await _context.Provincias.FirstOrDefaultAsync(c => c.PrvId == entidad.PrvId);
            if (provinciaDb != null)
            {
                throw new InvalidOperationException($"La provincia con ID {entidad.PrvId} ya existe.");
            }
            try
            {
                await _context.Provincias.AddAsync(entidad);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Provincia {PrvId} ({PrvNombre}) agregada correctamente.", 
                                        entidad.PrvId, entidad.PrvNombre);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al agregar la provincia {PrvId} ({PrvNombre}).", 
                                 entidad.PrvId,
                                 entidad.PrvNombre);
                throw new InvalidOperationException(
                    $"Error al guardar la provincia {entidad.PrvId} ({entidad.PrvNombre}): {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza la información de una provincia existente en la tabla Provincias
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UpdateAsync(Provincia entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            var provinciaDb = await _context.Provincias.FirstOrDefaultAsync(c => c.PrvId == entidad.PrvId) ?? throw new InvalidOperationException($"La provincia con ID {entidad.PrvId} no existe.");
            try
            {
                _context.Entry(provinciaDb).CurrentValues.SetValues(entidad);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Provincia {PrvId} ({PrvNombre}) actualizada correctamente.", 
                                       entidad.PrvId,
                                       entidad.PrvNombre);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al actualizar la provincia {PrvId} ({PrvNombre}).", 
                                 entidad.PrvId, entidad.PrvNombre);
                throw new InvalidOperationException(
                    $"Error al actualizar la provincia {entidad.PrvId} ({entidad.PrvNombre}): {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(5);
            throw new NotImplementedException();
        }
    }
}
