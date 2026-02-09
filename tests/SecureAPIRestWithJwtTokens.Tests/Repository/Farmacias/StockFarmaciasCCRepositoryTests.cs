using System.Data;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Repository.Farmacias;
using SecureAPIRestWithJwtTokens.Services.Interfaces;
using SecureAPIRestWithJwtTokens.Tests.Helpers;

namespace SecureAPIRestWithJwtTokens.Tests.Repository.Farmacias;

/// <summary>
/// Pruebas unitarias para <see cref="StockFarmaciasCCRepository"/>.
/// </summary>
public class StockFarmaciasCCRepositoryTests
{
    private readonly Mock<ILogger<StockFarmaciasCCRepository>> _loggerMock;
    private readonly Mock<ISqlDataServiceFactory> _sqlFactoryMock;
    private readonly Mock<ISqlDataService> _sqlServiceMock;
    private readonly ApiConfiguration _configuration;
    private readonly Mock<IParallelSqlExecutor<DataTable>> _parallelExecutorMock;
    private readonly Mock<IMapper> _mapperMock;

    public StockFarmaciasCCRepositoryTests()
    {
        _loggerMock = new Mock<ILogger<StockFarmaciasCCRepository>>();
        _sqlFactoryMock = new Mock<ISqlDataServiceFactory>();
        _sqlServiceMock = new Mock<ISqlDataService>();
        _configuration = new ApiConfiguration
        {
            CentralComunSql = new CentralComunSql
            {
                Servidor = "TestServer",
                BD = "TestDB",
                User = "TestUser",
                Pwd = "TestPwd"
            }
        };
        _parallelExecutorMock = new Mock<IParallelSqlExecutor<DataTable>>();
        _mapperMock = new Mock<IMapper>();

        _sqlFactoryMock.Setup(f => f.CreateService()).Returns(_sqlServiceMock.Object);
    }

    private StockFarmaciasCCRepository CreateRepository(TrebolDbContext context)
    {
        return new StockFarmaciasCCRepository(
            context,
            _loggerMock.Object,
            _sqlFactoryMock.Object,
            _configuration,
            _parallelExecutorMock.Object,
            _mapperMock.Object);
    }

    [Fact]
    public void Constructor_WithNullContext_ThrowsArgumentNullException()
    {
        var act = () => new StockFarmaciasCCRepository(
            null!,
            _loggerMock.Object,
            _sqlFactoryMock.Object,
            _configuration,
            _parallelExecutorMock.Object,
            _mapperMock.Object);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("context");
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new StockFarmaciasCCRepository(
            context,
            null!,
            _sqlFactoryMock.Object,
            _configuration,
            _parallelExecutorMock.Object,
            _mapperMock.Object);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
    }

    [Fact]
    public void Constructor_WithNullSqlFactory_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new StockFarmaciasCCRepository(
            context,
            _loggerMock.Object,
            null!,
            _configuration,
            _parallelExecutorMock.Object,
            _mapperMock.Object);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("sqlDataServiceFactory");
    }

    [Fact]
    public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new StockFarmaciasCCRepository(
            context,
            _loggerMock.Object,
            _sqlFactoryMock.Object,
            null!,
            _parallelExecutorMock.Object,
            _mapperMock.Object);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("configuration");
    }

    [Fact]
    public void Constructor_WithNullParallelExecutor_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new StockFarmaciasCCRepository(
            context,
            _loggerMock.Object,
            _sqlFactoryMock.Object,
            _configuration,
            null!,
            _mapperMock.Object);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("parallelSqlExecutor");
    }

    [Fact]
    public void Constructor_WithNullMapper_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new StockFarmaciasCCRepository(
            context,
            _loggerMock.Object,
            _sqlFactoryMock.Object,
            _configuration,
            _parallelExecutorMock.Object,
            null!);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("mapper");
    }

    [Fact]
    public async Task GetAllAsync_NoFarmaciasCC_ReturnsEmptyList()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable());
        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
        _parallelExecutorMock.Verify(
            p => p.ExecuteOnMultipleServersAsync(
                It.IsAny<List<FarmaciaDBConnectionInternal>>(),
                It.IsAny<string>(),
                It.IsAny<CommandType>(),
                It.IsAny<bool>(),
                It.IsAny<Dictionary<string, object>>()),
            Times.Never);
    }

    [Fact]
    public async Task GetAllAsync_WithEmptyFilters_ReturnsAllFarmaciasCC()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var unnId = 100;
        var codFarmacia = "1234";
        await SeedUnidadNegocio(context, unnId, codFarmacia);

        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable(codFarmacia));
        _mapperMock.Setup(m => m.Map<string>(It.IsAny<Direccion>())).Returns("Calle Test 123");

        var emptyStockTable = CreateStockDataTable();
        SetupParallelExecutor(CreateSuccessfulSummary(unnId, emptyStockTable));

        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync(new Dictionary<string, object>());

        // Assert
        result.Should().NotBeNull();
        result.Should().ContainSingle();
        var farmacia = result!.First();
        farmacia.IdFarmacia.Should().Be($"0{codFarmacia}");
        farmacia.Stock.Should().Be("SI"); // Sin artículos solicitados, todos los requisitos se cumplen (verdad vacua)
    }

    [Fact]
    public async Task GetAllAsync_WithSpecificFarmacia_ReturnsOnlyThatFarmacia()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var unnId = 101;
        var codFarmacia = "5678";
        await SeedUnidadNegocio(context, unnId, codFarmacia);

        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.FARMAINI, codFarmacia }
        };

        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable(codFarmacia));
        _mapperMock.Setup(m => m.Map<string>(It.IsAny<Direccion>())).Returns("Avenida Principal 456");

        var emptyStockTable = CreateStockDataTable();
        SetupParallelExecutor(CreateSuccessfulSummary(unnId, emptyStockTable));

        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().ContainSingle();
        var farmacia = result!.First();
        farmacia.IdFarmacia.Should().Be($"0{codFarmacia}");
    }

    [Fact]
    public async Task GetAllAsync_WithArticulosAndSufficientStock_ReturnsStockSi()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var unnId = 102;
        var codFarmacia = "9999";
        await SeedUnidadNegocio(context, unnId, codFarmacia);

        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.ARTICULOS, "ART001|ART002|ART003" },
            { FilterConstants.UDS, "5|10|3" }
        };

        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable(codFarmacia));
        _mapperMock.Setup(m => m.Map<string>(It.IsAny<Direccion>())).Returns("Plaza Mayor 1");

        // Stock real suficiente para todos los artículos
        var stockTable = CreateStockDataTable(
            ("ART001", 10),    // Solicitado: 5, Real: 10 ✓
            ("ART002", 15),    // Solicitado: 10, Real: 15 ✓
            ("ART003", 5)      // Solicitado: 3, Real: 5 ✓
        );
        SetupParallelExecutor(CreateSuccessfulSummary(unnId, stockTable));

        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        var farmacia = result!.Should().ContainSingle().Subject;
        farmacia.Stock.Should().Be("SI");
        farmacia.IdFarmacia.Should().Be($"0{codFarmacia}");
        farmacia.Descripcion.Should().NotBeNullOrEmpty();
        farmacia.Direccion.Should().Be("Plaza Mayor 1");
    }

    [Fact]
    public async Task GetAllAsync_WithArticulosAndInsufficientStock_ReturnsStockNo()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var unnId = 103;
        var codFarmacia = "7777";
        await SeedUnidadNegocio(context, unnId, codFarmacia);

        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.ARTICULOS, "ART001|ART002" },
            { FilterConstants.UDS, "20|10" }
        };

        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable(codFarmacia));
        _mapperMock.Setup(m => m.Map<string>(It.IsAny<Direccion>())).Returns("Calle Sin Stock 99");

        // Stock real insuficiente para el primer artículo
        var stockTable = CreateStockDataTable(
            ("ART001", 5),     // Solicitado: 20, Real: 5 ✗
            ("ART002", 15)     // Solicitado: 10, Real: 15 ✓
        );
        SetupParallelExecutor(CreateSuccessfulSummary(unnId, stockTable));

        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        var farmacia = result!.Should().ContainSingle().Subject;
        farmacia.Stock.Should().Be("NO");
        farmacia.IdFarmacia.Should().Be($"0{codFarmacia}");
    }

    [Fact]
    public async Task GetAllAsync_WithMissingArticleInStock_ReturnsStockNo()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var unnId = 104;
        var codFarmacia = "3333";
        await SeedUnidadNegocio(context, unnId, codFarmacia);

        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.ARTICULOS, "ART001|ART002|ART003" },
            { FilterConstants.UDS, "1|1|1" }
        };

        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable(codFarmacia));
        _mapperMock.Setup(m => m.Map<string>(It.IsAny<Direccion>())).Returns("Calle Incompleta 33");

        // Falta ART003 en la respuesta
        var stockTable = CreateStockDataTable(
            ("ART001", 5),
            ("ART002", 10)
        );
        SetupParallelExecutor(CreateSuccessfulSummary(unnId, stockTable));

        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        var farmacia = result!.Should().ContainSingle().Subject;
        farmacia.Stock.Should().Be("NO"); // ART003 tiene stock real 0 (no encontrado)
    }

    [Fact]
    public async Task GetAllAsync_WithFailedServerExecution_ReturnsStockNo()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var unnId = 105;
        var codFarmacia = "4444";
        await SeedUnidadNegocio(context, unnId, codFarmacia);

        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.ARTICULOS, "ART001" },
            { FilterConstants.UDS, "1" }
        };

        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable(codFarmacia));
        _mapperMock.Setup(m => m.Map<string>(It.IsAny<Direccion>())).Returns("Calle Error 404");

        // Simulamos un fallo en la ejecución
        var failedSummary = new MultiServerExecutionSummary<DataTable>
        {
            TotalServers = 1,
            SuccessCount = 0,
            FailureCount = 1,
            Results =
            [
                new MultiServerQueryResult<DataTable>
                {
                    Success = false,
                    IdUnidadNegocioERP = unnId,
                    ErrorMessage = "Connection timeout",
                    Data = null
                }
            ]
        };
        SetupParallelExecutor(failedSummary);

        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        var farmacia = result!.Should().ContainSingle().Subject;
        farmacia.Stock.Should().Be("NO"); // El stock se inicializa a "NO" por defecto
    }

    [Fact]
    public async Task GetAllAsync_FarmaciaNotInERP_LogsWarningAndMarksAsNotConfigured()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var codFarmaciaCC = "8888"; // Farmacia en CentralComun pero no en ERP

        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable(codFarmaciaCC));
        _mapperMock.Setup(m => m.Map<string>(It.IsAny<Direccion>())).Returns("Direccion Test");
        // NO agregamos la farmacia al ERP

        var emptyStockTable = CreateStockDataTable();
        SetupParallelExecutor(CreateSuccessfulSummary(999, emptyStockTable));

        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        var farmacia = result!.Should().ContainSingle().Subject;
        farmacia.Descripcion.Should().Be("FARMACIA NO CONFIGURADA EN ERP");
        farmacia.IdFarmacia.Should().Be(codFarmaciaCC);

        // Verificar que se registró el warning
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains(codFarmaciaCC)),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_WithArticulosButNoUds_InitializesStockToZero()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var unnId = 106;
        var codFarmacia = "6666";
        await SeedUnidadNegocio(context, unnId, codFarmacia);

        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.ARTICULOS, "ART001|ART002" }
            // Sin FilterConstants.UDS
        };

        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable(codFarmacia));
        _mapperMock.Setup(m => m.Map<string>(It.IsAny<Direccion>())).Returns("Calle Cero Stock");

        // Cualquier cantidad real debe marcar stock SI (porque se solicita 0)
        var stockTable = CreateStockDataTable(
            ("ART001", 1),
            ("ART002", 1)
        );
        SetupParallelExecutor(CreateSuccessfulSummary(unnId, stockTable));

        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        var farmacia = result!.Should().ContainSingle().Subject;
        farmacia.Stock.Should().Be("SI"); // 1 >= 0, entonces tiene stock
    }

    [Fact]
    public async Task GetByIdAsync_ThrowsNotImplementedException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.GetByIdAsync(1);

        await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task AddAsync_ThrowsNotImplementedException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.AddAsync(new FarmaciaStock());

        await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task UpdateAsync_ThrowsNotImplementedException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.UpdateAsync(new FarmaciaStock());

        await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task DeleteAsync_ThrowsNotImplementedException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.DeleteAsync(1);

        await act.Should().ThrowAsync<NotImplementedException>();
    }

    #region Helper Methods

    private static async Task SeedUnidadNegocio(TrebolDbContext context, int unnId, string codFarmacia)
    {
        var unnTrebol = $"0{codFarmacia}";
        
        // Create required navigation entities first
        var tipoVia = new TipoVia
        {
            TviId = unnId,
            TviNombre = "Calle",
            TviDefecto = false
        };
        
        var pais = new Pais
        {
            PaiId = unnId,
            PaiNombre = "España"
        };

        var comunidad = new ComunidadAut
        {
            CauId = unnId,
            CauNombre = "Test",
            PaiId = unnId,
            Pais = pais
        };

        var provincia = new Provincia
        {
            PrvId = unnId,
            PrvNombre = "Test Province",
            PaiId = unnId,
            CauId = unnId,
            ComunidadAutonoma = comunidad
        };

        var poblacion = new Poblacion
        {
            PobId = unnId,
            PobNombre = "Test City",
            PrvId = unnId,
            Provincia = provincia
        };

        var direccion = new Direccion
        {
            DirId = unnId,
            DirNombreCalle = "Calle Test",
            DirNumero = "123",
            DirCodPostal = "28001",
            PobId = unnId,
            PrvId = unnId,
            TviId = unnId,
            Poblacion = poblacion,
            Provincia = provincia,
            TipoVia = tipoVia
        };

        var unidadNegocioDb = new UnidadNegocioDb
        {
            UnnId = unnId,
            UnnDbserver = "SERVER" + unnId,
            UnnDbname = "DB" + unnId,
            UnnDbuser = "USER" + unnId,
            UnnDbpass = "PASS" + unnId
        };

        var unidadNegocio = new UnidadNegocio
        {
            UnnId = unnId,
            UnnNombre = $"Farmacia {codFarmacia}",
            UnnTrebol = unnTrebol,
            UnnActiva = true,
            UnnEsCentral = false,
            UnnEsAlmacen = false,
            UnnEsAlmacenTrebol = false,
            UnnFarmatic = false,
            UnnModeloDual = false,
            UnnCanonTrebol = false,
            UnnFincTrebol = DateTime.UtcNow.AddYears(-1),
            UnnFalta = DateTime.UtcNow.AddYears(-2),
            UnnUalta = 1,
            UnidadNegocioDb = unidadNegocioDb
        };

        var unidadNegocioDireccion = new UnidadNegocioDireccion
        {
            UnnId = unnId,
            DirId = unnId,
            DirDefecto = true,
            UnidadNegocio = unidadNegocio,
            Dir = direccion
        };

        // Add all entities to context
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddAsync(provincia);
        await context.Poblaciones.AddAsync(poblacion);
        await context.TiposVia.AddAsync(tipoVia);
        await context.Direcciones.AddAsync(direccion);
        await context.UnidadesNegocio.AddAsync(unidadNegocio);
        await context.UnidadesNegocioDb.AddAsync(unidadNegocioDb);
        await context.UnidadNegocioDirecciones.AddAsync(unidadNegocioDireccion);
        await context.SaveChangesAsync();
    }

    private void SetupSqlServiceForFarmaciasCC(DataTable dataTable)
    {
        _sqlServiceMock.Setup(s => s.GetConnection(
            It.IsAny<FarmaciaDBConnectionInternal>(), 
            It.IsAny<int>()))
            .Returns(Task.FromResult(true));
        _sqlServiceMock.Setup(s => s.ExecuteQueryAsync(
            It.IsAny<string>(), 
            It.IsAny<CommandType>(),
            It.IsAny<bool>(),
            It.IsAny<Dictionary<string, object>>()))
            .ReturnsAsync(dataTable);
    }

    private void SetupParallelExecutor(MultiServerExecutionSummary<DataTable> summary)
    {
        _parallelExecutorMock.Setup(p => p.ExecuteOnMultipleServersAsync(
            It.IsAny<List<FarmaciaDBConnectionInternal>>(),
            It.IsAny<string>(),
            It.IsAny<CommandType>(),
            It.IsAny<bool>(),
            It.IsAny<Dictionary<string, object>>()))
            .ReturnsAsync(summary);
    }

    private static DataTable CreateFarmaciasDataTable(params string[] idFarmacias)
    {
        var table = new DataTable();
        table.Columns.Add("IdFarmacia", typeof(string));

        foreach (var idFarmacia in idFarmacias)
        {
            table.Rows.Add(idFarmacia);
        }

        return table;
    }

    private static DataTable CreateStockDataTable(params (string articulo, int stock)[] rows)
    {
        var table = new DataTable();
        table.Columns.Add("IdArticulo", typeof(string));
        table.Columns.Add("Stock", typeof(int));

        foreach (var (articulo, stock) in rows)
        {
            table.Rows.Add(articulo, stock);
        }

        return table;
    }

    private static MultiServerExecutionSummary<DataTable> CreateSuccessfulSummary(int unnId, DataTable data)
    {
        return new MultiServerExecutionSummary<DataTable>
        {
            TotalServers = 1,
            SuccessCount = 1,
            FailureCount = 0,
            Results =
            [
                new MultiServerQueryResult<DataTable>
                {
                    Success = true,
                    IdUnidadNegocioERP = unnId,
                    Data = data,
                    ExecutionTime = TimeSpan.FromMilliseconds(100)
                }
            ]
        };
    }

    #endregion
}
