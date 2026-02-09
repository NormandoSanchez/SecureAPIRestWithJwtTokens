  using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Services;

namespace SecureAPIRestWithJwtTokens.Tests.Services;

/// <summary>
/// Pruebas unitarias para MappingService
/// </summary>
public class MappingServiceTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<ILogger<MappingService>> _mockLogger;

    public MappingServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockLogger = new Mock<ILogger<MappingService>>();
    }

    private MappingService CreateService() => new(_mockMapper.Object, _mockLogger.Object);

    #region MapUsuarioToUserInfo Tests

    /// <summary>
    /// Verifica que MapUsuarioToUserInfo mapea correctamente un Usuario a UserInfoDto
    /// </summary>
    [Fact]
    public void MapUsuarioToUserInfo_WithValidUsuario_ReturnsUserInfoDto()
    {
        // Arrange
        var usuario = new Usuario
        {
            UsrId = 1,
            UsrLogin = "testuser",
            UsrNombre = "Test User",
            PeaId = 10
        };

        var expectedUserInfo = new UserInfoDto
        {
            Id = 1,
            UserName = "testuser",
            FullName = "Test User",
            PerfilId = 10
        };

        _mockMapper.Setup(m => m.Map<UserInfoDto>(usuario))
            .Returns(expectedUserInfo);

        var service = CreateService();

        // Act
        var result = service.MapUsuarioToUserInfo(usuario);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.UserName.Should().Be("testuser");
        result.FullName.Should().Be("Test User");
        result.PerfilId.Should().Be(10);
        _mockMapper.Verify(m => m.Map<UserInfoDto>(usuario), Times.Once);
    }

    /// <summary>
    /// Verifica que MapUsuarioToUserInfo lanza ArgumentNullException cuando el usuario es null
    /// </summary>
    [Fact]
    public void MapUsuarioToUserInfo_WithNullUsuario_ThrowsArgumentNullException()
    {
        // Arrange
        var service = CreateService();

        // Act
        Action act = () => service.MapUsuarioToUserInfo(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("usuario");
    }

    /// <summary>
    /// Verifica que MapUsuarioToUserInfo lanza InvalidOperationException cuando el mapper falla
    /// </summary>
    [Fact]
    public void MapUsuarioToUserInfo_WhenMapperThrowsException_ThrowsInvalidOperationException()
    {
        // Arrange
        var usuario = new Usuario
        {
            UsrId = 1,
            UsrLogin = "testuser",
            UsrNombre = "Test User"
        };

        _mockMapper.Setup(m => m.Map<UserInfoDto>(usuario))
            .Throws(new AutoMapperMappingException("Mapping error"));

        var service = CreateService();

        // Act
        Action act = () => service.MapUsuarioToUserInfo(usuario);

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Error mapeando Usuario 1 a UserInfo")
            .WithInnerException<AutoMapperMappingException>();
    }

    #endregion

    #region MapUsuarioToUserInfoAsync Tests

    /// <summary>
    /// Verifica que MapUsuarioToUserInfoAsync mapea correctamente un Usuario a UserInfoDto de forma asíncrona
    /// </summary>
    [Fact]
    public async Task MapUsuarioToUserInfoAsync_WithValidUsuario_ReturnsUserInfoDto()
    {
        // Arrange
        var usuario = new Usuario
        {
            UsrId = 2,
            UsrLogin = "asyncuser",
            UsrNombre = "Async User",
            PeaId = 20
        };

        var expectedUserInfo = new UserInfoDto
        {
            Id = 2,
            UserName = "asyncuser",
            FullName = "Async User",
            PerfilId = 20
        };

        _mockMapper.Setup(m => m.Map<UserInfoDto>(usuario))
            .Returns(expectedUserInfo);

        var service = CreateService();

        // Act
        var result = await service.MapUsuarioToUserInfoAsync(usuario);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(2);
        result.UserName.Should().Be("asyncuser");
        result.FullName.Should().Be("Async User");
        result.PerfilId.Should().Be(20);
        _mockMapper.Verify(m => m.Map<UserInfoDto>(usuario), Times.Once);
    }

    /// <summary>
    /// Verifica que MapUsuarioToUserInfoAsync lanza ArgumentNullException cuando el usuario es null
    /// </summary>
    [Fact]
    public async Task MapUsuarioToUserInfoAsync_WithNullUsuario_ThrowsArgumentNullException()
    {
        // Arrange
        var service = CreateService();

        // Act
        Func<Task> act = async () => await service.MapUsuarioToUserInfoAsync(null!);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("usuario");
    }

    /// <summary>
    /// Verifica que MapUsuarioToUserInfoAsync lanza InvalidOperationException cuando el mapper falla
    /// </summary>
    [Fact]
    public async Task MapUsuarioToUserInfoAsync_WhenMapperThrowsException_ThrowsInvalidOperationException()
    {
        // Arrange
        var usuario = new Usuario
        {
            UsrId = 3,
            UsrLogin = "erroruser",
            UsrNombre = "Error User"
        };

        _mockMapper.Setup(m => m.Map<UserInfoDto>(usuario))
            .Throws(new AutoMapperMappingException("Async mapping error"));

        var service = CreateService();

        // Act
        Func<Task> act = async () => await service.MapUsuarioToUserInfoAsync(usuario);

        // Assert
        var exception = await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Error mapeando Usuario 3 a UserInfo");
        
        exception.And.InnerException.Should().BeOfType<AutoMapperMappingException>();
    }

    #endregion

    #region MapDireccionToString Tests

    /// <summary>
    /// Verifica que MapDireccionToString mapea correctamente una Direccion a string
    /// </summary>
    [Fact]
    public void MapDireccionToString_WithValidDireccion_ReturnsString()
    {
        // Arrange
        var direccion = new Direccion
        {
            DirId = 1,
            TviId = 5,
            DirNombreCalle = "Gran Vía",
            DirNumero = "100",
            DirCodPostal = "28013",
            PobId = 1,
            PrvId = 1
        };

        const string expectedDireccionString = "Gran Vía, 100, 28013";

        _mockMapper.Setup(m => m.Map<string>(direccion))
            .Returns(expectedDireccionString);

        var service = CreateService();

        // Act
        var result = service.MapDireccionToString(direccion);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(expectedDireccionString);
        _mockMapper.Verify(m => m.Map<string>(direccion), Times.Once);
    }

    /// <summary>
    /// Verifica que MapDireccionToString retorna null cuando la direccion es null
    /// </summary>
    [Fact]
    public void MapDireccionToString_WithNullDireccion_ReturnsNull()
    {
        // Arrange
        var service = CreateService();

        // Act
        var result = service.MapDireccionToString(null!);

        // Assert
        result.Should().BeNull();
        _mockMapper.Verify(m => m.Map<string>(It.IsAny<Direccion>()), Times.Never);
    }

    /// <summary>
    /// Verifica que MapDireccionToString lanza InvalidOperationException cuando el mapper falla
    /// </summary>
    [Fact]
    public void MapDireccionToString_WhenMapperThrowsException_ThrowsInvalidOperationException()
    {
        // Arrange
        var direccion = new Direccion
        {
            DirId = 2,
            TviId = 5,
            DirNombreCalle = "Test Street",
            DirCodPostal = "28001",
            PobId = 1,
            PrvId = 1
        };

        _mockMapper.Setup(m => m.Map<string>(direccion))
            .Throws(new AutoMapperMappingException("Direccion mapping error"));

        var service = CreateService();

        // Act
        Action act = () => service.MapDireccionToString(direccion);

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Error mapeando Direccion a string")
            .WithInnerException<AutoMapperMappingException>();
    }

    /// <summary>
    /// Verifica que MapDireccionToString maneja direcciones completas con todos los campos
    /// </summary>
    [Fact]
    public void MapDireccionToString_WithCompleteDireccion_ReturnsCompleteString()
    {
        // Arrange
        var direccion = new Direccion
        {
            DirId = 3,
            TviId = 5,
            DirNombreCalle = "Calle Mayor",
            DirNumero = "25",
            DirPortal = "B",
            DirEscalera = "2",
            DirPiso = "3",
            DirPuerta = "A",
            DirComplemento = "Cerca del parque",
            DirCodPostal = "28012",
            PobId = 1,
            PrvId = 1
        };

        const string expectedDireccionString = "Calle Mayor, 25, Portal B, Escalera 2, Piso 3, Puerta A, 28012 (Cerca del parque)";

        _mockMapper.Setup(m => m.Map<string>(direccion))
            .Returns(expectedDireccionString);

        var service = CreateService();

        // Act
        var result = service.MapDireccionToString(direccion);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(expectedDireccionString);
        _mockMapper.Verify(m => m.Map<string>(direccion), Times.Once);
    }

    #endregion
}
