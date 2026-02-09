using AutoMapper;
using FluentAssertions;
using Moq;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Geographics;

namespace SecureAPIRestWithJwtTokens.Tests.Services.Geographics;

/// <summary>
/// Tests unitarios para PaisService
/// </summary>
public class PaisServiceTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<Pais>> _mockRepository;

    public PaisServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepository = new Mock<IGenericRepository<Pais>>();
    }

    private PaisService CreateService()
    {
        return new PaisService(_mockMapper.Object, _mockRepository.Object);
    }



    #region GetAllAsync Tests

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista de países correctamente
    /// </summary>
    [Fact]
    public async Task GetAllAsync_ReturnsListOfPaises()
    {
        // Arrange
        var paises = new List<Pais>
        {
            new() { PaiId = 1, PaiNombre = "España" },
            new() { PaiId = 2, PaiNombre = "Francia" }
        };

        var paisesDto = new List<PaisDto>
        {
            new() { Id = 1, Nombre = "España" },
            new() { Id = 2, Nombre = "Francia" }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(paises);

        _mockMapper.Setup(m => m.Map<IEnumerable<PaisDto>>(paises))
            .Returns(paisesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result![0].Nombre.Should().Be("España");
        result[1].Nombre.Should().Be("Francia");

        _mockRepository.Verify(r => r.GetAllAsync(null), Times.Once);
        _mockMapper.Verify(m => m.Map<IEnumerable<PaisDto>>(paises), Times.Once);
    }

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista vacía cuando no hay países
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WhenNoPaisesExist_ReturnsEmptyList()
    {
        // Arrange
        var paises = new List<Pais>();
        var paisesDto = new List<PaisDto>();

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(paises);

        _mockMapper.Setup(m => m.Map<IEnumerable<PaisDto>>(paises))
            .Returns(paisesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Verifica que GetAllAsync ignore los filtros pasados
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WithFilters_IgnoresFilters()
    {
        // Arrange
        var filtros = new Dictionary<string, object>
        {
            { "someFilter", "someValue" }
        };

        var paises = new List<Pais>
        {
            new() { PaiId = 1, PaiNombre = "España" }
        };

        var paisesDto = new List<PaisDto>
        {
            new() { Id = 1, Nombre = "España" }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(paises);

        _mockMapper.Setup(m => m.Map<IEnumerable<PaisDto>>(paises))
            .Returns(paisesDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        _mockRepository.Verify(r => r.GetAllAsync(null), Times.Once);
    }

    #endregion

    #region GetByIdAsync Tests

    /// <summary>
    /// Verifica que GetByIdAsync devuelva un país cuando el ID existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithValidId_ReturnsPais()
    {
        // Arrange
        var pais = new Pais { PaiId = 1, PaiNombre = "España" };
        var paisDto = new PaisDto { Id = 1, Nombre = "España" };

        _mockRepository.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(pais);

        _mockMapper.Setup(m => m.Map<PaisDto>(pais))
            .Returns(paisDto);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
        result.Nombre.Should().Be("España");

        _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
        _mockMapper.Verify(m => m.Map<PaisDto>(pais), Times.Once);
    }

    /// <summary>
    /// Verifica que GetByIdAsync devuelva null cuando el ID no existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithInvalidId_ReturnsNull()
    {
        // Arrange
        _mockRepository.Setup(r => r.GetByIdAsync(999))
            .ReturnsAsync((Pais?)null);

        _mockMapper.Setup(m => m.Map<PaisDto>(It.IsAny<Pais?>()))
            .Returns(default(PaisDto)!);
        
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
        var paisDto = new PaisDto { Id = 1, Nombre = "España" };

        // Act
        Func<Task> act = async () => await service.AddAsync(paisDto);

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
        var paisDto = new PaisDto { Id = 1, Nombre = "España" };

        // Act
        Func<Task> act = async () => await service.UpdateAsync(paisDto);

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
