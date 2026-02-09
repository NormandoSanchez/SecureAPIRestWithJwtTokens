using AutoMapper;
using FluentAssertions;
using Moq;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Avisos;

namespace SecureAPIRestWithJwtTokens.Tests.Services.Avisos;

/// <summary>
/// Tests unitarios para AvisoService
/// </summary>
public class AvisoServiceTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<AvisoInterno>> _mockRepository;

    public AvisoServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepository = new Mock<IGenericRepository<AvisoInterno>>();
    }

    private AvisoService CreateService()
    {
        return new AvisoService(_mockMapper.Object, _mockRepository.Object);
    }

    #region GetAllAsync Tests

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista de avisos correctamente
    /// </summary>
    [Fact]
    public async Task GetAllAsync_ReturnsListOfAvisos()
    {
        // Arrange
        var avisos = new List<AvisoInterno>
        {
            new() { AviId = 1, AviAsunto = "Aviso 1", AviMensaje = "Mensaje 1" },
            new() { AviId = 2, AviAsunto = "Aviso 2", AviMensaje = "Mensaje 2" }
        };

        var avisosDto = new List<AvisoInternoDto>
        {
            new() { IdAviso = 1, Asunto = "Aviso 1" },
            new() { IdAviso = 2, Asunto = "Aviso 2" }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(avisos);

        _mockMapper.Setup(m => m.Map<IEnumerable<AvisoInternoDto>>(avisos))
            .Returns(avisosDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result![0].Asunto.Should().Be("Aviso 1");
        result[1].Asunto.Should().Be("Aviso 2");

        _mockRepository.Verify(r => r.GetAllAsync(null), Times.Once);
        _mockMapper.Verify(m => m.Map<IEnumerable<AvisoInternoDto>>(avisos), Times.Once);
    }

    /// <summary>
    /// Verifica que GetAllAsync devuelva lista vacía cuando no hay avisos
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WhenNoAvisosExist_ReturnsEmptyList()
    {
        // Arrange
        var avisos = new List<AvisoInterno>();
        var avisosDto = new List<AvisoInternoDto>();

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(avisos);

        _mockMapper.Setup(m => m.Map<IEnumerable<AvisoInternoDto>>(avisos))
            .Returns(avisosDto);

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
            { "USERID", 100 },
            { "VISTOS", false }
        };

        var avisos = new List<AvisoInterno>
        {
            new() { AviId = 1, AviAsunto = "Aviso 1", UsuIddestino = 100, AviVisto = false }
        };

        var avisosDto = new List<AvisoInternoDto>
        {
            new() { IdAviso = 1, Asunto = "Aviso 1", Visto = "No" }
        };

        _mockRepository.Setup(r => r.GetAllAsync(filtros))
            .ReturnsAsync(avisos);

        _mockMapper.Setup(m => m.Map<IEnumerable<AvisoInternoDto>>(avisos))
            .Returns(avisosDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        _mockRepository.Verify(r => r.GetAllAsync(filtros), Times.Once);
    }

    /// <summary>
    /// Verifica que GetAllAsync maneje múltiples avisos de diferentes importancias
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WithMultipleAvisos_ReturnsAll()
    {
        // Arrange
        var avisos = new List<AvisoInterno>
        {
            new() { AviId = 1, AviAsunto = "Aviso Alta", AviImportancia = "ALTA" },
            new() { AviId = 2, AviAsunto = "Aviso Media", AviImportancia = "MEDIA" },
            new() { AviId = 3, AviAsunto = "Aviso Baja", AviImportancia = "BAJA" }
        };

        var avisosDto = new List<AvisoInternoDto>
        {
            new() { IdAviso = 1, Asunto = "Aviso Alta", Importancia = "ALTA" },
            new() { IdAviso = 2, Asunto = "Aviso Media", Importancia = "MEDIA" },
            new() { IdAviso = 3, Asunto = "Aviso Baja", Importancia = "BAJA" }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(avisos);

        _mockMapper.Setup(m => m.Map<IEnumerable<AvisoInternoDto>>(avisos))
            .Returns(avisosDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result.Should().Contain(a => a.Importancia == "ALTA");
        result.Should().Contain(a => a.Importancia == "MEDIA");
        result.Should().Contain(a => a.Importancia == "BAJA");
    }

    /// <summary>
    /// Verifica que GetAllAsync maneje avisos con diferentes estados de visto
    /// </summary>
    [Fact]
    public async Task GetAllAsync_WithVistoStates_MapsCorrectly()
    {
        // Arrange
        var avisos = new List<AvisoInterno>
        {
            new() { AviId = 1, AviAsunto = "Aviso Visto", AviVisto = true },
            new() { AviId = 2, AviAsunto = "Aviso No Visto", AviVisto = false }
        };

        var avisosDto = new List<AvisoInternoDto>
        {
            new() { IdAviso = 1, Asunto = "Aviso Visto", Visto = "Sí" },
            new() { IdAviso = 2, Asunto = "Aviso No Visto", Visto = "No" }
        };

        _mockRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(avisos);

        _mockMapper.Setup(m => m.Map<IEnumerable<AvisoInternoDto>>(avisos))
            .Returns(avisosDto);

        var service = CreateService();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
    }

    #endregion

    #region GetByIdAsync Tests

    /// <summary>
    /// Verifica que GetByIdAsync devuelva un aviso cuando el ID existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithValidId_ReturnsAviso()
    {
        // Arrange
        var aviso = new AvisoInterno 
        { 
            AviId = 1, 
            AviAsunto = "Aviso Importante", 
            AviMensaje = "Contenido del mensaje",
            AviImportancia = "ALTA",
            AviVisto = false
        };

        var avisoDto = new AvisoInternoDto 
        { 
            IdAviso = 1, 
            Asunto = "Aviso Importante", 
            Importancia = "ALTA",
            Visto = "No"
        };

        _mockRepository.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(aviso);

        _mockMapper.Setup(m => m.Map<AvisoInternoDto>(aviso))
            .Returns(avisoDto);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.IdAviso.Should().Be(1);
        result.Asunto.Should().Be("Aviso Importante");
        result.Importancia.Should().Be("ALTA");

        _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
        _mockMapper.Verify(m => m.Map<AvisoInternoDto>(aviso), Times.Once);
    }

    /// <summary>
    /// Verifica que GetByIdAsync devuelva null cuando el ID no existe
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithInvalidId_ReturnsNull()
    {
        // Arrange
        _mockRepository.Setup(r => r.GetByIdAsync(999))
            .ReturnsAsync((AvisoInterno?)null);

        _mockMapper.Setup(m => m.Map<AvisoInternoDto>(It.IsAny<AvisoInterno?>()))
            .Returns(default(AvisoInternoDto)!);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(999);

        // Assert
        result.Should().BeNull();
        _mockRepository.Verify(r => r.GetByIdAsync(999), Times.Once);
    }

    /// <summary>
    /// Verifica que GetByIdAsync maneje avisos con proceso asociado
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_WithProceso_MapsCorrectly()
    {
        // Arrange
        var aviso = new AvisoInterno 
        { 
            AviId = 1, 
            AviAsunto = "Aviso con Proceso",
            ProId = "PROC001"
        };

        var avisoDto = new AvisoInternoDto 
        { 
            IdAviso = 1, 
            Asunto = "Aviso con Proceso",
            IdProceso = "PROC001",
            Proceso = "Proceso Test"
        };

        _mockRepository.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(aviso);

        _mockMapper.Setup(m => m.Map<AvisoInternoDto>(aviso))
            .Returns(avisoDto);

        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.IdProceso.Should().Be("PROC001");
        result.Proceso.Should().Be("Proceso Test");
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
        var avisoDto = new AvisoInternoDto { IdAviso = 1, Asunto = "Nuevo Aviso" };

        // Act
        Func<Task> act = async () => await service.AddAsync(avisoDto);

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
        var avisoDto = new AvisoInternoDto { IdAviso = 1, Asunto = "Aviso Actualizado" };

        // Act
        Func<Task> act = async () => await service.UpdateAsync(avisoDto);

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
