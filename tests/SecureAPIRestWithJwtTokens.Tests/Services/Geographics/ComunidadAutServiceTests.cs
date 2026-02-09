using AutoMapper;
using FluentAssertions;
using Moq;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Geographics;

namespace SecureAPIRestWithJwtTokens.Tests.Services.Geographics;

/// <summary>
/// Tests unitarios para ComunidadAutService
/// </summary>
public class ComunidadAutServiceTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<ComunidadAut>> _mockRepository;

    public ComunidadAutServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepository = new Mock<IGenericRepository<ComunidadAut>>();
    }

    private ComunidadAutService CreateService()
    {
        return new ComunidadAutService(_mockMapper.Object, _mockRepository.Object);
    }



    #region GetAllAsync Tests

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista de comunidades autónomas correctamente
    /// </summary>
    [Fact]
    public async Task GetAllAsync_ReturnsListOfComunidades()
    {
        // Arrange
        var comunidades = new List<ComunidadAut>
        {
            new() { CauId = 1, CauNombre = "Andalucía", PaiId = 1, CauExencionIva = false, CauConsejo = 1 },
            new() { CauId = 2, CauNombre = "Cataluña", PaiId = 1, CauExencionIva = false, CauConsejo = 2 }
        };

        var comunidadesDto = new List<ComunidadAutDto>
        {
            new() { Id = 1, Nombre = "Andalucía", IdPais = 1, ExencionIVA = false, ComunidadConsejoId = 1 },
            new() { Id = 2, Nombre = "Cataluña", IdPais = 1, ExencionIVA = false, ComunidadConsejoId = 2 }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(comunidades);

        _mockMapper.Setup(m => m.Map<List<ComunidadAutDto>>(comunidades))
            .Returns(comunidadesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result![0].Nombre.Should().Be("Andalucía");
        result[1].Nombre.Should().Be("Cataluña");

        _mockRepository.Verify(r => r.GetAllAsync(null), Times.Once);
        _mockMapper.Verify(m => m.Map<List<ComunidadAutDto>>(comunidades), Times.Once);
    }

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista vacía cuando no hay comunidades
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WhenNoComunidadesExist_ReturnsEmptyList()
    {
        // Arrange
        var comunidades = new List<ComunidadAut>();
        var comunidadesDto = new List<ComunidadAutDto>();

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(comunidades);

        _mockMapper.Setup(m => m.Map<List<ComunidadAutDto>>(comunidades))
            .Returns(comunidadesDto);

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
            { "PaiId", 1 }
        };

        var comunidades = new List<ComunidadAut>
        {
            new() { CauId = 1, CauNombre = "Andalucía", PaiId = 1, CauExencionIva = false, CauConsejo = 1 }
        };

        var comunidadesDto = new List<ComunidadAutDto>
        {
            new() { Id = 1, Nombre = "Andalucía", IdPais = 1, ExencionIVA = false, ComunidadConsejoId = 1 }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(comunidades);

        _mockMapper.Setup(m => m.Map<List<ComunidadAutDto>>(comunidades))
            .Returns(comunidadesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        _mockRepository.Verify(r => r.GetAllAsync(filtros), Times.Once);
    }

    /// <summary>
    /// Verifica que GetAllAsync maneje correctamente las comunidades con exención IVA
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WithExencionIVA_MapsCorrectly()
    {
        // Arrange
        var comunidades = new List<ComunidadAut>
        {
            new() { CauId = 1, CauNombre = "Canarias", PaiId = 1, CauExencionIva = true, CauConsejo = 1 }
        };

        var comunidadesDto = new List<ComunidadAutDto>
        {
            new() { Id = 1, Nombre = "Canarias", IdPais = 1, ExencionIVA = true, ComunidadConsejoId = 1 }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(comunidades);

        _mockMapper.Setup(m => m.Map<List<ComunidadAutDto>>(comunidades))
            .Returns(comunidadesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result![0].ExencionIVA.Should().BeTrue();
    }

    #endregion

    #region GetByIdAsync Tests

    /// <summary>
    /// Verifica que GetByIdAsync devuelva una comunidad cuando el ID existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithValidId_ReturnsComunidad()
    {
        // Arrange
        var comunidad = new ComunidadAut 
        { 
            CauId = 1, 
            CauNombre = "Madrid", 
            PaiId = 1, 
            CauExencionIva = false, 
            CauConsejo = 3 
        };

        var comunidadDto = new ComunidadAutDto 
        { 
            Id = 1, 
            Nombre = "Madrid", 
            IdPais = 1, 
            ExencionIVA = false, 
            ComunidadConsejoId = 3 
        };

        _mockRepository.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(comunidad);

        _mockMapper.Setup(m => m.Map<ComunidadAutDto>(comunidad))
            .Returns(comunidadDto);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
        result.Nombre.Should().Be("Madrid");
        result.IdPais.Should().Be(1);

        _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
        _mockMapper.Verify(m => m.Map<ComunidadAutDto>(comunidad), Times.Once);
    }

    /// <summary>
    /// Verifica que GetByIdAsync devuelva null cuando el ID no existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithInvalidId_ReturnsNull()
    {
        // Arrange
        _mockRepository.Setup(r => r.GetByIdAsync(999))
            .ReturnsAsync((ComunidadAut?)null);

        _mockMapper.Setup(m => m.Map<ComunidadAutDto>(It.IsAny<ComunidadAut?>()))
            .Returns(default(ComunidadAutDto)!);

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
        var comunidadDto = new ComunidadAutDto { Id = 1, Nombre = "Andalucía" };

        // Act
        Func<Task> act = async () => await service.AddAsync(comunidadDto);

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
        var comunidadDto = new ComunidadAutDto { Id = 1, Nombre = "Andalucía" };

        // Act
        Func<Task> act = async () => await service.UpdateAsync(comunidadDto);

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
