using AutoMapper;
using FluentAssertions;
using Moq;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Geographics;

namespace SecureAPIRestWithJwtTokens.Tests.Services.Geographics;

/// <summary>
/// Tests unitarios para PoblacionService
/// </summary>
public class PoblacionServiceTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<Poblacion>> _mockRepository;

    public PoblacionServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepository = new Mock<IGenericRepository<Poblacion>>();
    }

    private PoblacionService CreateService()
    {
        return new PoblacionService(_mockMapper.Object, _mockRepository.Object);
    }



    #region GetAllAsync Tests

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista de poblaciones correctamente
    /// </summary>
    [Fact]
    public async Task GetAllAsync_ReturnsListOfPoblaciones()
    {
        // Arrange
        var poblaciones = new List<Poblacion>
        {
            new() { PobId = 1, PobNombre = "Alcalá de Henares", PrvId = 1, PaiId = 1 },
            new() { PobId = 2, PobNombre = "Getafe", PrvId = 1, PaiId = 1 }
        };

        var poblacionesDto = new List<PoblacionDto>
        {
            new() { Id = 1, Nombre = "Alcalá de Henares", IdProvincia = 1, IdPais = 1 },
            new() { Id = 2, Nombre = "Getafe", IdProvincia = 1, IdPais = 1 }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(poblaciones);

        _mockMapper.Setup(m => m.Map<List<PoblacionDto>>(poblaciones))
            .Returns(poblacionesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result![0].Nombre.Should().Be("Alcalá de Henares");
        result[1].Nombre.Should().Be("Getafe");

        _mockRepository.Verify(r => r.GetAllAsync(null), Times.Once);
        _mockMapper.Verify(m => m.Map<List<PoblacionDto>>(poblaciones), Times.Once);
    }

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista vacía cuando no hay poblaciones
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WhenNoPoblacionesExist_ReturnsEmptyList()
    {
        // Arrange
        var poblaciones = new List<Poblacion>();
        var poblacionesDto = new List<PoblacionDto>();

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(poblaciones);

        _mockMapper.Setup(m => m.Map<List<PoblacionDto>>(poblaciones))
            .Returns(poblacionesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Verifica que GetAllAsync pase los filtros al repositorio
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WithFilters_PassesFiltersToRepository()
    {
        // Arrange
        var filtros = new Dictionary<string, object>
        {
            { "PrvId", 1 }
        };

        var poblaciones = new List<Poblacion>
        {
            new() { PobId = 1, PobNombre = "Madrid", PrvId = 1, PaiId = 1 }
        };

        var poblacionesDto = new List<PoblacionDto>
        {
            new() { Id = 1, Nombre = "Madrid", IdProvincia = 1, IdPais = 1 }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(poblaciones);

        _mockMapper.Setup(m => m.Map<List<PoblacionDto>>(poblaciones))
            .Returns(poblacionesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        _mockRepository.Verify(r => r.GetAllAsync(filtros), Times.Once);
    }

    /// <summary>
    /// Verifica que GetAllAsync maneje múltiples poblaciones de diferentes provincias
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WithMultiplePoblaciones_ReturnsAll()
    {
        // Arrange
        var poblaciones = new List<Poblacion>
        {
            new() { PobId = 1, PobNombre = "Madrid", PrvId = 1, PaiId = 1 },
            new() { PobId = 2, PobNombre = "Barcelona", PrvId = 2, PaiId = 1 },
            new() { PobId = 3, PobNombre = "Valencia", PrvId = 3, PaiId = 1 },
            new() { PobId = 4, PobNombre = "Sevilla", PrvId = 4, PaiId = 1 }
        };

        var poblacionesDto = new List<PoblacionDto>
        {
            new() { Id = 1, Nombre = "Madrid", IdProvincia = 1, IdPais = 1 },
            new() { Id = 2, Nombre = "Barcelona", IdProvincia = 2, IdPais = 1 },
            new() { Id = 3, Nombre = "Valencia", IdProvincia = 3, IdPais = 1 },
            new() { Id = 4, Nombre = "Sevilla", IdProvincia = 4, IdPais = 1 }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(poblaciones);

        _mockMapper.Setup(m => m.Map<List<PoblacionDto>>(poblaciones))
            .Returns(poblacionesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(4);
    }

    #endregion

    #region GetByIdAsync Tests

    /// <summary>
    /// Verifica que GetByIdAsync devuelva una población cuando el ID existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithValidId_ReturnsPoblacion()
    {
        // Arrange
        var poblacion = new Poblacion 
        { 
            PobId = 1, 
            PobNombre = "Málaga", 
            PrvId = 29, 
            PaiId = 1 
        };

        var poblacionDto = new PoblacionDto 
        { 
            Id = 1, 
            Nombre = "Málaga", 
            IdProvincia = 29, 
            IdPais = 1 
        };

        _mockRepository.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(poblacion);

        _mockMapper.Setup(m => m.Map<PoblacionDto>(poblacion))
            .Returns(poblacionDto);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
        result.Nombre.Should().Be("Málaga");
        result.IdProvincia.Should().Be(29);
        result.IdPais.Should().Be(1);

        _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
        _mockMapper.Verify(m => m.Map<PoblacionDto>(poblacion), Times.Once);
    }

    /// <summary>
    /// Verifica que GetByIdAsync devuelva null cuando el ID no existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithInvalidId_ReturnsNull()
    {
        // Arrange
        _mockRepository.Setup(r => r.GetByIdAsync(999))
            .ReturnsAsync((Poblacion?)null);

        _mockMapper.Setup(m => m.Map<PoblacionDto>(It.IsAny<Poblacion?>()))
            .Returns(default(PoblacionDto)!);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(999);

        // Assert
        result.Should().BeNull();
        _mockRepository.Verify(r => r.GetByIdAsync(999), Times.Once);
    }

    #endregion

    #region NotImplementedException Tests

    /// <summary>
    /// Verifica que AddAsync lance NotImplementedException
    /// </summary>
    [Fact]
    public async Task AddAsync_ThrowsNotImplementedException()
    {
        // Arrange
        var service = CreateService();
        var poblacionDto = new PoblacionDto { Id = 1, Nombre = "Madrid" };

        // Act
        Func<Task> act = async () => await service.AddAsync(poblacionDto);

        // Assert
        await act.Should().ThrowAsync<NotImplementedException>();
    }

    /// <summary>
    /// Verifica que UpdateAsync lance NotImplementedException
    /// </summary>
    [Fact]
    public async Task UpdateAsync_ThrowsNotImplementedException()
    {
        // Arrange
        var service = CreateService();
        var poblacionDto = new PoblacionDto { Id = 1, Nombre = "Madrid" };

        // Act
        Func<Task> act = async () => await service.UpdateAsync(poblacionDto);

        // Assert
        await act.Should().ThrowAsync<NotImplementedException>();
    }

    /// <summary>
    /// Verifica que DeleteAsync lance NotImplementedException
    /// </summary>
    [Fact]
    public async Task DeleteAsync_ThrowsNotImplementedException()
    {
        // Arrange
        var service = CreateService();

        // Act
        Func<Task> act = async () => await service.DeleteAsync(1);

        // Assert
        await act.Should().ThrowAsync<NotImplementedException>();
    }

    #endregion
}
