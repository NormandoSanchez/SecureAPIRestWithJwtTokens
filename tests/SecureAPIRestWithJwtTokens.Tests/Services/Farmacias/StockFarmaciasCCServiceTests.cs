using AutoMapper;
using FluentAssertions;
using Moq;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Farmacias;

namespace SecureAPIRestWithJwtTokens.Tests.Services.Farmacias;

/// <summary>
/// Tests unitarios para StockFarmaciasCCService
/// </summary>
public class StockFarmaciasCCServiceTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<FarmaciaStock>> _mockRepository;

    public StockFarmaciasCCServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepository = new Mock<IGenericRepository<FarmaciaStock>>();
    }

    private StockFarmaciasCCService CreateService()
    {
        return new StockFarmaciasCCService(_mockMapper.Object, _mockRepository.Object);
    }

    #region GetItemsAsync Tests

    /// <summary>
    /// Verifica que GetItemsAsync devuelva lista de farmacias con stock correctamente
    /// </summary>
    [Fact]
    public async Task GetItemsAsync_ReturnsFarmaciasWithStock()
    {
        // Arrange
        var filtros = new Dictionary<string, object>
        {
            { "ARTICULOS", "123,456" },
            { "UDS", "2,1" },
            { "FARMAINI", "FAR001" }
        };

        var farmaciasStock = new List<FarmaciaStock>
        {
            new() 
            { 
                IdFarmacia = "FAR001", 
                Descripcion = "Farmacia Central",
                Direccion = "Calle Mayor 1, 28001 Madrid, Madrid",
                Stock = "SI"
            },
            new() 
            { 
                IdFarmacia = "FAR002", 
                Descripcion = "Farmacia Norte",
                Direccion = "Avenida Norte 25, 28002 Madrid, Madrid",
                Stock = "SI"
            }
        };

        var stockFarmaciasDto = new List<StockFarmaciaDto>
        {
            new() 
            { 
                IdFarmacia = "FAR001", 
                Descripcion = "Farmacia Central",
                Direccion = "Calle Mayor 1, 28001 Madrid, Madrid",
                Stock = "SI"
            },
            new() 
            { 
                IdFarmacia = "FAR002", 
                Descripcion = "Farmacia Norte",
                Direccion = "Avenida Norte 25, 28002 Madrid, Madrid",
                Stock = "SI"
            }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(farmaciasStock);

        _mockMapper.Setup(m => m.Map<List<StockFarmaciaDto>>(farmaciasStock))
            .Returns(stockFarmaciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].IdFarmacia.Should().Be("FAR001");
        result[1].IdFarmacia.Should().Be("FAR002");
        result.Should().OnlyContain(f => f.Stock == "SI");

        _mockRepository.Verify(r => r.GetAllAsync(filtros), Times.Once);
        _mockMapper.Verify(m => m.Map<List<StockFarmaciaDto>>(farmaciasStock), Times.Once);
    }

    /// <summary>
    /// Verifica que GetItemsAsync devuelva lista vacía cuando no hay farmacias con stock
    /// </summary>
    [Fact]
    public async Task GetItemsAsync_WhenNoStockAvailable_ReturnsEmptyList()
    {
        // Arrange
        var filtros = new Dictionary<string, object>
        {
            { "ARTICULOS", "999" },
            { "UDS", "100" }
        };

        var farmaciasStock = new List<FarmaciaStock>();
        var stockFarmaciasDto = new List<StockFarmaciaDto>();

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(farmaciasStock);

        _mockMapper.Setup(m => m.Map<List<StockFarmaciaDto>>(farmaciasStock))
            .Returns(stockFarmaciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Verifica que GetItemsAsync pase correctamente los filtros al repositorio
    /// </summary>
    [Fact]
    public async Task GetItemsAsync_WithFilters_PassesFiltersToRepository()
    {
        // Arrange
        var filtros = new Dictionary<string, object>
        {
            { "ARTICULOS", "123" },
            { "UDS", "5" },
            { "FARMAINI", "FAR100" }
        };

        var farmaciasStock = new List<FarmaciaStock>
        {
            new() 
            { 
                IdFarmacia = "FAR100", 
                Descripcion = "Farmacia Test",
                Stock = "SI"
            }
        };

        var stockFarmaciasDto = new List<StockFarmaciaDto>
        {
            new() 
            { 
                IdFarmacia = "FAR100", 
                Descripcion = "Farmacia Test",
                Stock = "SI"
            }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(farmaciasStock);

        _mockMapper.Setup(m => m.Map<List<StockFarmaciaDto>>(farmaciasStock))
            .Returns(stockFarmaciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        _mockRepository.Verify(r => r.GetAllAsync(filtros), Times.Once);
    }

    /// <summary>
    /// Verifica que GetItemsAsync maneje farmacias con y sin stock
    /// </summary>
    [Fact]
    public async Task GetItemsAsync_WithMixedStock_ReturnsBothStates()
    {
        // Arrange
        var filtros = new Dictionary<string, object>
        {
            { "ARTICULOS", "123" },
            { "UDS", "1" }
        };

        var farmaciasStock = new List<FarmaciaStock>
        {
            new() 
            { 
                IdFarmacia = "FAR001", 
                Descripcion = "Farmacia Con Stock",
                Direccion = "Calle 1",
                Stock = "SI"
            },
            new() 
            { 
                IdFarmacia = "FAR002", 
                Descripcion = "Farmacia Sin Stock",
                Direccion = "Calle 2",
                Stock = "NO"
            }
        };

        var stockFarmaciasDto = new List<StockFarmaciaDto>
        {
            new() 
            { 
                IdFarmacia = "FAR001", 
                Descripcion = "Farmacia Con Stock",
                Direccion = "Calle 1",
                Stock = "SI"
            },
            new() 
            { 
                IdFarmacia = "FAR002", 
                Descripcion = "Farmacia Sin Stock",
                Direccion = "Calle 2",
                Stock = "NO"
            }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(farmaciasStock);

        _mockMapper.Setup(m => m.Map<List<StockFarmaciaDto>>(farmaciasStock))
            .Returns(stockFarmaciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(f => f.Stock == "SI");
        result.Should().Contain(f => f.Stock == "NO");
    }

    /// <summary>
    /// Verifica que GetItemsAsync maneje múltiples farmacias con diferentes ubicaciones
    /// </summary>
    [Fact]
    public async Task GetItemsAsync_WithMultipleFarmacias_ReturnsFarmaciasWithCompleteData()
    {
        // Arrange
        var filtros = new Dictionary<string, object>
        {
            { "ARTICULOS", "123,456,789" },
            { "UDS", "1,2,3" }
        };

        var farmaciasStock = new List<FarmaciaStock>
        {
            new() 
            { 
                IdFarmacia = "FAR001", 
                Descripcion = "Farmacia Madrid",
                Direccion = "Gran Vía 10, 28013 Madrid, Madrid",
                Stock = "SI"
            },
            new() 
            { 
                IdFarmacia = "FAR002", 
                Descripcion = "Farmacia Barcelona",
                Direccion = "Paseo Gracia 50, 08007 Barcelona, Barcelona",
                Stock = "SI"
            },
            new() 
            { 
                IdFarmacia = "FAR003", 
                Descripcion = "Farmacia Valencia",
                Direccion = "Calle Colón 20, 46004 Valencia, Valencia",
                Stock = "SI"
            }
        };

        var stockFarmaciasDto = new List<StockFarmaciaDto>
        {
            new() 
            { 
                IdFarmacia = "FAR001", 
                Descripcion = "Farmacia Madrid",
                Direccion = "Gran Vía 10, 28013 Madrid, Madrid",
                Stock = "SI"
            },
            new() 
            { 
                IdFarmacia = "FAR002", 
                Descripcion = "Farmacia Barcelona",
                Direccion = "Paseo Gracia 50, 08007 Barcelona, Barcelona",
                Stock = "SI"
            },
            new() 
            { 
                IdFarmacia = "FAR003", 
                Descripcion = "Farmacia Valencia",
                Direccion = "Calle Colón 20, 46004 Valencia, Valencia",
                Stock = "SI"
            }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(farmaciasStock);

        _mockMapper.Setup(m => m.Map<List<StockFarmaciaDto>>(farmaciasStock))
            .Returns(stockFarmaciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result.Should().OnlyContain(f => !string.IsNullOrEmpty(f.IdFarmacia));
        result.Should().OnlyContain(f => !string.IsNullOrEmpty(f.Descripcion));
        result.Should().OnlyContain(f => !string.IsNullOrEmpty(f.Direccion));
    }

    /// <summary>
    /// Verifica que GetItemsAsync maneje farmacias con articulos múltiples
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WithMultipleArticles_FiltersCorrectly()
    {
        // Arrange
        var filtros = new Dictionary<string, object>
        {
            { "ARTICULOS", "ART001,ART002,ART003" },
            { "UDS", "1,1,1" }
        };

        var farmaciasStock = new List<FarmaciaStock>
        {
            new() 
            { 
                IdFarmacia = "FAR001", 
                Descripcion = "Farmacia Completa",
                Direccion = "Test Address",
                Stock = "SI"
            }
        };

        var stockFarmaciasDto = new List<StockFarmaciaDto>
        {
            new() 
            { 
                IdFarmacia = "FAR001", 
                Descripcion = "Farmacia Completa",
                Direccion = "Test Address",
                Stock = "SI"
            }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(farmaciasStock);

        _mockMapper.Setup(m => m.Map<List<StockFarmaciaDto>>(farmaciasStock))
            .Returns(stockFarmaciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result[0].Stock.Should().Be("SI");
    }

    /// <summary>
    /// Verifica que GetAllAsync maneje correctamente el mapper
    /// </summary>
    [Fact]
    public async Task GetAllAsync_MapsEntitiesCorrectly()
    {
        // Arrange
        var filtros = new Dictionary<string, object>
        {
            { "ARTICULOS", "123" },
            { "UDS", "1" }
        };

        var farmaciasStock = new List<FarmaciaStock>
        {
            new() 
            { 
                IdFarmacia = "FAR999", 
                Descripcion = "Farmacia Mapping Test",
                Direccion = "Mapping Address Test",
                IdUnidadNegocioERP = 100,
                Server = "server.test",
                DataBase = "TestDB",
                Stock = "SI"
            }
        };

        var stockFarmaciasDto = new List<StockFarmaciaDto>
        {
            new() 
            { 
                IdFarmacia = "FAR999", 
                Descripcion = "Farmacia Mapping Test",
                Direccion = "Mapping Address Test",
                Stock = "SI"
            }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(farmaciasStock);

        _mockMapper.Setup(m => m.Map<List<StockFarmaciaDto>>(farmaciasStock))
            .Returns(stockFarmaciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result[0].IdFarmacia.Should().Be("FAR999");
        result[0].Descripcion.Should().Be("Farmacia Mapping Test");
        result[0].Direccion.Should().Be("Mapping Address Test");
        result[0].Stock.Should().Be("SI");

        _mockMapper.Verify(m => m.Map<List<StockFarmaciaDto>>(farmaciasStock), Times.Once);
    }

    #endregion
}
