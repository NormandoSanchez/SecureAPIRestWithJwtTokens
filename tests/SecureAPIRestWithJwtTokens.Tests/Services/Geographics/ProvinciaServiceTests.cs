using AutoMapper;
using FluentAssertions;
using Moq;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Geographics;

namespace SecureAPIRestWithJwtTokens.Tests.Services.Geographics;

/// <summary>
/// Tests unitarios para ProvinciaService
/// </summary>
public class ProvinciaServiceTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<Provincia>> _mockRepository;

    public ProvinciaServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepository = new Mock<IGenericRepository<Provincia>>();
    }

    private ProvinciaService CreateService()
    {
        return new ProvinciaService(_mockMapper.Object, _mockRepository.Object);
    }



    #region GetAllAsync Tests

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista de provincias correctamente
    /// </summary>
    [Fact]
    public async Task GetAllAsync_ReturnsListOfProvincias()
    {
        // Arrange
        var provincias = new List<Provincia>
        {
            new() { PrvId = 1, PrvNombre = "Madrid", CauId = 1, PaiId = 1 },
            new() { PrvId = 2, PrvNombre = "Barcelona", CauId = 2, PaiId = 1 }
        };

        var provinciasDto = new List<ProvinciaDto>
        {
            new() { Id = 1, Nombre = "Madrid", IdComunidadAut = 1, IdPais = 1 },
            new() { Id = 2, Nombre = "Barcelona", IdComunidadAut = 2, IdPais = 1 }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(provincias);

        _mockMapper.Setup(m => m.Map<List<ProvinciaDto>>(provincias))
            .Returns(provinciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result![0].Nombre.Should().Be("Madrid");
        result[1].Nombre.Should().Be("Barcelona");

        _mockRepository.Verify(r => r.GetAllAsync(null), Times.Once);
        _mockMapper.Verify(m => m.Map<List<ProvinciaDto>>(provincias), Times.Once);
    }

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista vacía cuando no hay provincias
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WhenNoProvinciasExist_ReturnsEmptyList()
    {
        // Arrange
        var provincias = new List<Provincia>();
        var provinciasDto = new List<ProvinciaDto>();

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(provincias);

        _mockMapper.Setup(m => m.Map<List<ProvinciaDto>>(provincias))
            .Returns(provinciasDto);

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
            { "CauId", 1 }
        };

        var provincias = new List<Provincia>
        {
            new() { PrvId = 1, PrvNombre = "Madrid", CauId = 1, PaiId = 1 }
        };

        var provinciasDto = new List<ProvinciaDto>
        {
            new() { Id = 1, Nombre = "Madrid", IdComunidadAut = 1, IdPais = 1 }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(provincias);

        _mockMapper.Setup(m => m.Map<List<ProvinciaDto>>(provincias))
            .Returns(provinciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        _mockRepository.Verify(r => r.GetAllAsync(filtros), Times.Once);
    }

    /// <summary>
    /// Verifica que GetAllAsync maneje múltiples provincias correctamente
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WithMultipleProvincias_ReturnsAll()
    {
        // Arrange
        var provincias = new List<Provincia>
        {
            new() { PrvId = 1, PrvNombre = "Álava", CauId = 1, PaiId = 1 },
            new() { PrvId = 2, PrvNombre = "Albacete", CauId = 2, PaiId = 1 },
            new() { PrvId = 3, PrvNombre = "Alicante", CauId = 3, PaiId = 1 }
        };

        var provinciasDto = new List<ProvinciaDto>
        {
            new() { Id = 1, Nombre = "Álava", IdComunidadAut = 1, IdPais = 1 },
            new() { Id = 2, Nombre = "Albacete", IdComunidadAut = 2, IdPais = 1 },
            new() { Id = 3, Nombre = "Alicante", IdComunidadAut = 3, IdPais = 1 }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(provincias);

        _mockMapper.Setup(m => m.Map<List<ProvinciaDto>>(provincias))
            .Returns(provinciasDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
    }

    #endregion

    #region GetByIdAsync Tests

    /// <summary>
    /// Verifica que GetByIdAsync devuelva una provincia cuando el ID existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithValidId_ReturnsProvincia()
    {
        // Arrange
        var provincia = new Provincia 
        { 
            PrvId = 1, 
            PrvNombre = "Sevilla", 
            CauId = 1, 
            PaiId = 1 
        };

        var provinciaDto = new ProvinciaDto 
        { 
            Id = 1, 
            Nombre = "Sevilla", 
            IdComunidadAut = 1, 
            IdPais = 1 
        };

        _mockRepository.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(provincia);

        _mockMapper.Setup(m => m.Map<ProvinciaDto>(provincia))
            .Returns(provinciaDto);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
        result.Nombre.Should().Be("Sevilla");
        result.IdComunidadAut.Should().Be(1);
        result.IdPais.Should().Be(1);

        _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
        _mockMapper.Verify(m => m.Map<ProvinciaDto>(provincia), Times.Once);
    }

    /// <summary>
    /// Verifica que GetByIdAsync devuelva null cuando el ID no existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithInvalidId_ReturnsNull()
    {
        // Arrange
        _mockRepository.Setup(r => r.GetByIdAsync(999))
            .ReturnsAsync((Provincia?)null);

        _mockMapper.Setup(m => m.Map<ProvinciaDto>(It.IsAny<Provincia?>()))
            .Returns(default(ProvinciaDto)!);

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
        var provinciaDto = new ProvinciaDto { Id = 1, Nombre = "Madrid" };

        // Act
        Func<Task> act = async () => await service.AddAsync(provinciaDto);

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
        var provinciaDto = new ProvinciaDto { Id = 1, Nombre = "Madrid" };

        // Act
        Func<Task> act = async () => await service.UpdateAsync(provinciaDto);

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
