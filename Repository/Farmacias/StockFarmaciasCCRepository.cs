using AutoMapper;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Services;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.EntityFrameworkCore;
using System.Data;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Repository.Farmacias
{
    public class StockFarmaciasCCRepository(TrebolDbContext context,
                                            ILogger<StockFarmaciasCCRepository> logger,
                                            ISqlDataServiceFactory sqlDataServiceFactory,
                                            ApiConfiguration configuration,
                                            IParallelSqlExecutor<DataTable> parallelSqlExecutor,
                                            IMapper mapper) : IGenericRepository<FarmaciaStock>
    {
        private readonly TrebolDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<StockFarmaciasCCRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));   
        private readonly ISqlDataServiceFactory _sqlFactory = sqlDataServiceFactory ?? throw new ArgumentNullException(nameof(sqlDataServiceFactory));
        private readonly ApiConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        private readonly IParallelSqlExecutor<DataTable> _parallelSqlExecutor = parallelSqlExecutor ?? throw new ArgumentNullException(nameof(parallelSqlExecutor));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        /// <summary>
        /// Obtener el stock de articulos en farmacias con Click &amp; Collect
        /// </summary>
        /// <param name="filtros">Diccionario de filtros para la consulta</param>
        /// <returns></returns>
        public async Task<IEnumerable<FarmaciaStock>?> GetAllAsync(IDictionary<string, object>? filtros = null)
        {   
            // Parametro FarmaciaInicial 
            string? codFarmacia = Common.ParseStringFilter(filtros, FilterConstants.FARMAINI);

            // Parametro Articulos
            List<string> lstArticulos = filtros == null ? [] : ProcesarFiltroArticulos(filtros); // Lista de articulos solicitados
            Dictionary<string, int> lstStocks = CrearListaStocks(lstArticulos); // Lista de articulos y stocks

            // Procesar parametro stock
            if(filtros != null) ProcesarFiltroStocks(filtros, lstArticulos, ref lstStocks);
            
            // Obtener Farmacias con C&C 
            List<FarmaciaStock> farmaciasCC = await GetFarmaciasCC(codFarmacia);

            // Si no hay farmacias con C&C, devolvemos una lista vacía inmediatamente.
            if (farmaciasCC.Count == 0)
            {
                return [];
            }

            // Obtener Farmacias desde ERP
            var listaUNN = await GetFarmaciasERP(codFarmacia);

            // Asignar direcciones y datos SQL a las farmacias C&C
            AsignarDatosERPAFarmaciasCC(_logger, _mapper,listaUNN, ref farmaciasCC);

            // Definir conexion a las farmacias y query Stocks reales
            MultiServerQueryDto msqr = ConstruirMultiServerQuery(farmaciasCC, lstArticulos);
            
            // Ejecutar consulta en paralelo en las farmacias con C&C
            var summary = await _parallelSqlExecutor.ExecuteOnMultipleServersAsync(
                        msqr.Connections,
                        msqr.Query);

            // Procesar resultados correctos 
            ProcesarResultadosCorrectos(summary, lstStocks, ref farmaciasCC);
            
            return farmaciasCC;
        }

        public Task AddAsync(FarmaciaStock entidad)
        {
            // Implementación mínima para evitar warnings
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FarmaciaStock entidad)
        {
            // Implementación mínima para evitar warnings
            throw new NotImplementedException();
        }
       
        public Task DeleteAsync(int id)
        {
            // Implementación mínima para evitar warnings
            throw new NotImplementedException();
        }

        public Task<FarmaciaStock?> GetByIdAsync(int id)
        {
            // Implementación mínima para evitar warnings
            throw new NotImplementedException();
        }
        
        #region Métodos Privados
        /// <summary>
        /// Procesa el filtro de Articulos
        /// </summary>
        /// <param name="filtros">filtros</param>
        /// <returns></returns>
        private static List<string> ProcesarFiltroArticulos(IDictionary<string, object>? filtros)
        {
            List<string> lstArticulos = []; // Lista de articulos solicitados

            // Procesar parametro articulos 
            if (filtros != null && !Common.IsFilterEmptyOrNull(filtros, FilterConstants.ARTICULOS) &&
                filtros.TryGetValue(FilterConstants.ARTICULOS, out object? valueart) && valueart != null &&
                !string.IsNullOrWhiteSpace(valueart.ToString()))
            {
                string[] parts = (valueart?.ToString() ?? string.Empty).Split('|');
                for (int i = 0; i < parts.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(parts[i]))
                    {
                        lstArticulos.Add(parts[i]);
                    }
                }
            }
            
            return lstArticulos;
        }

        /// <summary>
        /// Crea una lista de stocks inicializada a 0
        /// </summary>
        /// <param name="lstArticulos">lista de articulos</param>
        /// <returns></returns>
        private static Dictionary<string, int> CrearListaStocks(List<string> lstArticulos)
        {
            Dictionary<string, int> lstStocks = []; // Lista de articulos y stocks
            for (int i = 0; i < lstArticulos.Count; i++)
            {
                lstStocks.Add(lstArticulos[i], 0); // Inicializar stock a 0
            }
            return lstStocks;
        }

        /// <summary>
        /// Procesa el filtro de Stocks
        /// </summary>
        /// <param name="filtros">filtros</param>
        /// <param name="lstArticulos">lista de articulos</param>
        /// <param name="lstStocks">lista de stocks completada y devuelta</param>
        private static void ProcesarFiltroStocks(IDictionary<string, object> filtros, List<string> lstArticulos, ref Dictionary<string, int> lstStocks)
        {
            // Procesar parametro stock
            if (!Common.IsFilterEmptyOrNull(filtros, FilterConstants.UDS) && 
                filtros.TryGetValue(FilterConstants.UDS, out object? valueuds) && valueuds != null &&
                !string.IsNullOrWhiteSpace(valueuds.ToString()))
            {
                string[] parts = (valueuds?.ToString() ?? string.Empty).Split('|');
                for (int i = 0; i < parts.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(parts[i]) && int.TryParse(parts[i], out int rStock))
                    {
                        lstStocks[lstArticulos[i]] = rStock;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene la lista de farmacias que tienen habilitado el servicio de Click &amp; Collect
        /// </summary>
        /// <param name="codFarmacia">Código de la farmacia inicial</param>
        /// <returns></returns>
        private async Task<List<FarmaciaStock>> GetFarmaciasCC(string? codFarmacia)
        {
            await using var sqlService = _sqlFactory.CreateService();

            var dbConnection = _configuration.GetCentralComunSQLConnection();

            await sqlService.GetConnection(dbConnection);

            var query = QueryConstants.GET_CENTRALCOMUN_FARMACIAS_CLICK_COLLECT;
            if (!string.IsNullOrWhiteSpace(codFarmacia))
            {
                query += $" AND IdFarmacia = '{codFarmacia}'";
            }
            var result = await sqlService.ExecuteQueryAsync(query, CommandType.Text);

            return result.MapToList<FarmaciaStock>() ?? [];
        }

        /// <summary>
        /// Obtiene la lista de farmacias desde el ERP
        /// </summary>
        /// <param name="codFarmacia">código de la farmacia inicial</param>
        /// <returns></returns>
        private async Task<List<UnidadNegocioDireccion>> GetFarmaciasERP(string? codFarmacia)
        {
            List<UnidadNegocioDireccion> listaUNN;

            // Obtener Farmacias desde ERP
            if (string.IsNullOrWhiteSpace(codFarmacia))
            {
                listaUNN = await _context.UnidadNegocioDirecciones
                                   .Include(d => d.Dir)
                                   .ThenInclude(d => d.Poblacion)
                                   .Include(d => d.Dir)
                                   .ThenInclude(d => d.Provincia)
                                   .Include(d => d.Dir)
                                   .ThenInclude(d => d.TipoVia)
                                   .Include(d => d.UnidadNegocio)
                                   .ThenInclude(u => u.UnidadNegocioDb)
                                   .Where(d => d.DirDefecto &&
                                               d.UnidadNegocio.UnnActiva).ToListAsync();
            }
            else
            {
                string codFarmaciaERP = $"0{codFarmacia}";
                listaUNN = await _context.UnidadNegocioDirecciones
                                         .Include(d => d.Dir)
                                         .ThenInclude(d => d.Poblacion)
                                         .Include(d => d.Dir)
                                         .ThenInclude(d => d.Provincia)
                                         .Include(d => d.Dir)
                                         .ThenInclude(d => d.TipoVia)
                                         .Include(d => d.UnidadNegocio)
                                         .ThenInclude(u => u.UnidadNegocioDb)
                                         .Where(d => d.DirDefecto &&
                                                     d.UnidadNegocio.UnnActiva &&
                                                     d.UnidadNegocio.UnnTrebol == codFarmaciaERP).ToListAsync();
            }

            return listaUNN;
        }

        /// <summary>
        /// Asignar datos ERP a las farmacias C&amp;C
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="mapper">mapper</param>
        /// <param name="listaUNN">lista de direcciones de farmacias</param>
        /// <param name="farmaciasCC">lista de farmacias C&amp;C</param>
        private static void AsignarDatosERPAFarmaciasCC(ILogger<StockFarmaciasCCRepository> logger,
                                                        IMapper mapper,
                                                        List<UnidadNegocioDireccion> listaUNN,
                                                        ref List<FarmaciaStock> farmaciasCC)
        {
            foreach (FarmaciaStock item in farmaciasCC)
            {
                string IdFarmacia = item.IdFarmacia ?? string.Empty;
                var oUNNDir = listaUNN.FirstOrDefault(u => u.UnidadNegocio.UnnTrebol.Substring(1, 4) == IdFarmacia);
                if (oUNNDir == null)
                {
                    logger.LogWarning("La farmacia {IdFarmacia} NO existe en el ERP.", IdFarmacia);
                    item.Descripcion = "FARMACIA NO CONFIGURADA EN ERP";
                }
                else
                {
                    item.IdUnidadNegocioERP = oUNNDir.UnnId;
                    item.Descripcion = oUNNDir.UnidadNegocio.UnnNombre;
                    item.IdFarmacia = oUNNDir.UnidadNegocio.UnnTrebol;
                    item.Server = oUNNDir.UnidadNegocio.UnidadNegocioDb?.UnnDbserver ?? string.Empty;
                    item.DataBase = oUNNDir.UnidadNegocio.UnidadNegocioDb?.UnnDbname ?? string.Empty;
                    item.UsuarioDB = oUNNDir.UnidadNegocio.UnidadNegocioDb?.UnnDbuser ?? string.Empty;
                    item.PasswordDB = oUNNDir.UnidadNegocio.UnidadNegocioDb?.UnnDbpass ?? string.Empty; // Sin desencriptar
                    item.Direccion = mapper.Map<string>(oUNNDir.Dir);
                }
                item.Stock = "NO"; // Inicializado para que en caso de timeout por conexion SQL tenga el valor por defecto 
            }
        }

        /// <summary>
        /// Construir el MultiServerQueryDTO para la consulta de stocks
        /// </summary>
        /// <param name="farmaciasCC">lista de farmacias C&amp;C</param>
        /// <param name="lstArticulos">lista de articulos</param>
        /// <returns></returns>
        private static MultiServerQueryDto ConstruirMultiServerQuery(List<FarmaciaStock> farmaciasCC, List<string> lstArticulos)
        {
            // Construir lista de articulos para query (sIn)
            string sIn = string.Join(',', lstArticulos.Select(a => $"'{a}'").ToArray());

            MultiServerQueryDto msqr = new()
            {
                Connections = [.. farmaciasCC.Select(f => new FarmaciaDBConnectionInternal
                {
                    IdUnidadNegocioERP = f.IdUnidadNegocioERP,
                    Server = f.Server,
                    DataBase = f.DataBase,
                    User = f.UsuarioDB,
                    EncriptedPassword = f.PasswordDB,
                }).Where(c => !string.IsNullOrWhiteSpace(c.Server))],
                Parameters = null,
                Query = $"{QueryConstants.GET_ARTICULOS_FARMACIAS.Replace("{0}", sIn)}"
            };

            return msqr;
        }

        /// <summary>
        /// Procesar resultados correctos
        /// </summary>
        /// <param name="summary">Resumen de la ejecución del servidor</param>
        /// <param name="lstStocks">Lista de stocks solicitados</param>
        /// <param name="farmaciasCC">Lista de farmacias C&amp;C</param>
        private static void ProcesarResultadosCorrectos(MultiServerExecutionSummary<DataTable> summary,
                                                        Dictionary<string, int> lstStocks,
                                                        ref List<FarmaciaStock> farmaciasCC)
        {
            foreach (var result in summary.Results.Where(r => r.Success))
            {
                var idUnidadNegocioERP = result.IdUnidadNegocioERP;
                var tieneStock = false;
                var dtOk = result.Data;

                tieneStock = false;
                var stocks = GetListaArticulosStock(lstStocks); // Lista de articulos solicitados con stock solicitado
                for (int i = 0; i < dtOk?.Rows.Count; i++)
                {
                    DataRow dr = dtOk.Rows[i];
                    StockArticulo? oArt = stocks.FirstOrDefault(s => s.IdArticulo == dr[0].ToString());
                    if (oArt != null)
                    {
                        oArt.StockReal = (int)dr[1];
                    }
                }
                if (!stocks.Any(r => !r.TieneStock))
                {
                    // Todos con stock real suficiente 
                    tieneStock = true;
                }

                // Actualizar farmaciaCC
                var farmaciaToUpdate = farmaciasCC.FirstOrDefault(f => f.IdUnidadNegocioERP == idUnidadNegocioERP);
                if (farmaciaToUpdate != null)
                {
                    farmaciaToUpdate.Stock = tieneStock ? "SI" : "NO";
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de StockArticulo a partir de un Diccionario  
        /// </summary>
        /// <param name="Solicitados">Dictionary parejas articulo y stock solicitado</param>
        /// <returns>Lista de StockArticulo</returns>
        private static List<StockArticulo> GetListaArticulosStock(Dictionary<string, int> Solicitados)
        {
            List<StockArticulo> lstResult = [];

            if (Solicitados != null)
            {
                foreach (KeyValuePair<string, int> item in Solicitados)
                {
                    lstResult.Add(new StockArticulo(item.Key, item.Value, 0));
                }
            }

            return lstResult;
        }
        #endregion
    }
}
