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
    private readonly Mock<ICryptoGraphicService> _cryptoGraphicServiceMock;
    private readonly Mock<ISqlDataServiceFactory> _sqlFactoryMock;
    private readonly Mock<ISqlDataService> _sqlServiceMock;
    private readonly Mock<IParallelSqlExecutor<DataTable>> _parallelExecutorMock;
    private readonly Mock<IMapper> _mapperMock;

    public StockFarmaciasCCRepositoryTests()
    {
        _loggerMock = new Mock<ILogger<StockFarmaciasCCRepository>>();
        _cryptoGraphicServiceMock = new Mock<ICryptoGraphicService>();
        _sqlFactoryMock = new Mock<ISqlDataServiceFactory>();
        _sqlServiceMock = new Mock<ISqlDataService>();
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
            _cryptoGraphicServiceMock.Object,
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
            _cryptoGraphicServiceMock.Object,
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
            _cryptoGraphicServiceMock.Object,
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
            _cryptoGraphicServiceMock.Object,
            _parallelExecutorMock.Object,
            _mapperMock.Object);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("sqlDataServiceFactory");
    }

    [Fact]
    public void Constructor_WithNullCriptoGraphicService_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new StockFarmaciasCCRepository(
            context,
            _loggerMock.Object,
            _sqlFactoryMock.Object,
            null!,
            _parallelExecutorMock.Object,
            _mapperMock.Object);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("cryptoGraphicService");
    }

    [Fact]
    public void Constructor_WithNullParallelExecutor_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new StockFarmaciasCCRepository(
            context,
            _loggerMock.Object,
            _sqlFactoryMock.Object,
            _cryptoGraphicServiceMock.Object,
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
            _cryptoGraphicServiceMock.Object,
            _parallelExecutorMock.Object,
            null!);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("mapper");
    }

    [Fact]
    public async Task GetAllAsync_WithEmptyFilters_ReturnsEmptyList()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        SetupSqlServiceForFarmaciasCC(CreateFarmaciasDataTable());

        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync(new Dictionary<string, object>());

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


    #region Helper Methods

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
    #endregion
}
