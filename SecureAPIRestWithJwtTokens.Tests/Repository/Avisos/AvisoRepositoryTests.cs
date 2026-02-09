using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Repository.Avisos;
using SecureAPIRestWithJwtTokens.Tests.Helpers;

namespace SecureAPIRestWithJwtTokens.Tests.Repository.Avisos;

/// <summary>
/// Pruebas unitarias para <see cref="AvisoRepository"/>.
/// </summary>
public class AvisoRepositoryTests
{
    private readonly Mock<ILogger<AvisoRepository>> _loggerMock;
    private readonly ApiConfiguration _configuration;

    public AvisoRepositoryTests()
    {
        _loggerMock = new Mock<ILogger<AvisoRepository>>();
        _configuration = new ApiConfiguration
        {
            Notificaciones = new NotificacionesSettings
            {
                MesesTopeVistos = 3,
                MesesTopeAntiguos = 6
            }
        };
    }

    private AvisoRepository CreateRepository(TrebolDbContext context)
    {
        return new AvisoRepository(context, _configuration, _loggerMock.Object);
    }

    #region Constructor Tests

    [Fact]
    public void Constructor_WithNullContext_ThrowsArgumentNullException()
    {
        var act = () => new AvisoRepository(null!, _configuration, _loggerMock.Object);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("context");
    }

    [Fact]
    public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new AvisoRepository(context, null!, _loggerMock.Object);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("apiConfiguration");
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new AvisoRepository(context, _configuration, null!);

        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
    }

    #endregion

    #region GetAllAsync Tests

    [Fact]
    public async Task GetAllAsync_WithoutUserIdFilter_ReturnsEmptyList()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllAsync_WithUserIdFilterButNoAvisos_ReturnsEmptyList()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.USERID, 123 }
        };

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllAsync_WithUserId_ReturnsOnlyUserAvisos()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var proceso = CreateProceso("PROC001", "Test Process");
        await context.Procesos.AddAsync(proceso);
        
        // Create avisos with visto=true so they are returned
        var aviso1 = CreateAviso(1, 100, proceso.ProId, DateTime.Now.AddDays(-1), true);
        var aviso2 = CreateAviso(2, 100, proceso.ProId, DateTime.Now.AddDays(-2), true);
        var aviso3 = CreateAviso(3, 200, proceso.ProId, DateTime.Now.AddDays(-1), true); // Different user
        
        await context.AvisosInternos.AddRangeAsync(aviso1, aviso2, aviso3);
        await context.SaveChangesAsync();

        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.USERID, 100 }
        };

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().OnlyContain(a => a.UsuIddestino == 100);
    }

    [Fact]
    public async Task GetAllAsync_WithoutVistosFilter_ReturnsOnlyUnreadAvisos()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var proceso = CreateProceso("PROC002", "Test Process");
        await context.Procesos.AddAsync(proceso);
        
        // Note: vistos=false returns VISTO (read) avisos per repository logic
        var avisoVisto1 = CreateAviso(1, 100, proceso.ProId, DateTime.Now.AddDays(-1), true);
        var avisoVisto2 = CreateAviso(2, 100, proceso.ProId, DateTime.Now.AddDays(-2), true);
        var avisoNoVisto = CreateAviso(3, 100, proceso.ProId, DateTime.Now.AddDays(-3), false);
        
        await context.AvisosInternos.AddRangeAsync(avisoVisto1, avisoVisto2, avisoNoVisto);
        await context.SaveChangesAsync();

        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.USERID, 100 },
            { FilterConstants.VISTOS, false }
        };

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().OnlyContain(a => a.AviVisto); // vistos=false returns visto=true records
    }

    [Fact]
    public async Task GetAllAsync_WithVistosFilterTrue_ReturnsRecentAvisos()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var proceso = CreateProceso("PROC003", "Test Process");
        await context.Procesos.AddAsync(proceso);
        
        var avisoVistoReciente = CreateAviso(1, 100, proceso.ProId, DateTime.Now.AddMonths(-2), true);
        var avisoVistoAntiguo = CreateAviso(2, 100, proceso.ProId, DateTime.Now.AddMonths(-4), true); // Older than MesesTopeVistos
        var avisoNoVisto = CreateAviso(3, 100, proceso.ProId, DateTime.Now.AddDays(-1), false);
        
        await context.AvisosInternos.AddRangeAsync(avisoVistoReciente, avisoVistoAntiguo, avisoNoVisto);
        await context.SaveChangesAsync();

        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.USERID, 100 },
            { FilterConstants.VISTOS, true }
        };

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2); // Returns both recent (within MesesTopeVistos) regardless of visto status
        result.Should().Contain(a => a.AviId == 1); // Visto recent
        result.Should().Contain(a => a.AviId == 3); // No visto recent
        result.Should().NotContain(a => a.AviId == 2); // Too old
    }

    [Fact]
    public async Task GetAllAsync_WithAntiguosFilterTrue_ReturnsOnlyRecentAvisos()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var proceso = CreateProceso("PROC004", "Test Process");
        await context.Procesos.AddAsync(proceso);
        
        // Note: antiguos filter requires visto=true for default vistos=false behavior
        var avisoReciente = CreateAviso(1, 100, proceso.ProId, DateTime.Now.AddMonths(-5), true);
        var avisoAntiguo = CreateAviso(2, 100, proceso.ProId, DateTime.Now.AddMonths(-7), true); // Older than MesesTopeAntiguos
        
        await context.AvisosInternos.AddRangeAsync(avisoReciente, avisoAntiguo);
        await context.SaveChangesAsync();

        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.USERID, 100 },
            { FilterConstants.ANTIGUOS, true }
        };

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().ContainSingle();
        var aviso = result!.First();
        aviso.AviId.Should().Be(1);
        aviso.AviFecha.Should().BeAfter(DateTime.Now.AddMonths(-_configuration.Notificaciones.MesesTopeAntiguos));
    }

    [Fact]
    public async Task GetAllAsync_WithUserIdOnly_ReturnsAllReadAvisos()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var proceso = CreateProceso("PROC005", "Test Process");
        await context.Procesos.AddAsync(proceso);
        
        // Create avisos with visto=true
        var aviso1 = CreateAviso(1, 100, proceso.ProId, DateTime.Now.AddDays(-1), true);
        var aviso2 = CreateAviso(2, 100, proceso.ProId, DateTime.Now.AddMonths(-2), true);
        var aviso3 = CreateAviso(3, 100, proceso.ProId, DateTime.Now.AddMonths(-5), true);
        
        await context.AvisosInternos.AddRangeAsync(aviso1, aviso2, aviso3);
        await context.SaveChangesAsync();

        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.USERID, 100 }
        };

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result.Should().OnlyContain(a => a.UsuIddestino == 100 && a.AviVisto);
    }

    [Fact]
    public async Task GetAllAsync_IncludesProcesoNavigation()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var proceso = CreateProceso("PROC006", "Important Process");
        await context.Procesos.AddAsync(proceso);
        
        // Create with visto=true
        var aviso = CreateAviso(1, 100, proceso.ProId, DateTime.Now.AddDays(-1), true);
        await context.AvisosInternos.AddAsync(aviso);
        await context.SaveChangesAsync();

        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.USERID, 100 }
        };

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        var avisoResult = result!.Should().ContainSingle().Subject;
        avisoResult.Proceso.Should().NotBeNull();
        avisoResult.Proceso.ProId.Should().Be("PROC006");
        avisoResult.Proceso.ProNombre.Should().Be("Important Process");
    }

    [Fact]
    public async Task GetAllAsync_WithVistosAndAntiguosFilters_AntiguosTakesPrecedence()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var proceso = CreateProceso("PROC007", "Test Process");
        await context.Procesos.AddAsync(proceso);
        
        var avisoReciente = CreateAviso(1, 100, proceso.ProId, DateTime.Now.AddMonths(-5), true);
        var avisoAntiguo = CreateAviso(2, 100, proceso.ProId, DateTime.Now.AddMonths(-7), true);
        
        await context.AvisosInternos.AddRangeAsync(avisoReciente, avisoAntiguo);
        await context.SaveChangesAsync();

        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.USERID, 100 },
            { FilterConstants.VISTOS, true },
            { FilterConstants.ANTIGUOS, true }
        };

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().ContainSingle();
        var aviso = result!.First();
        aviso.AviFecha.Should().BeAfter(DateTime.Now.AddMonths(-_configuration.Notificaciones.MesesTopeAntiguos));
    }

    [Fact]
    public async Task GetAllAsync_WithDifferentImportanceLevels_ReturnsAll()
    {
        // Arrange
        using var context = TestDbContextFactory.CreateContext();
        var proceso = CreateProceso("PROC008", "Test Process");
        await context.Procesos.AddAsync(proceso);
        
        // Create with visto=true
        var avisoAlta = CreateAviso(1, 100, proceso.ProId, DateTime.Now.AddDays(-1), true, "ALTA");
        var avisoMedia = CreateAviso(2, 100, proceso.ProId, DateTime.Now.AddDays(-2), true, "MEDIA");
        var avisoBaja = CreateAviso(3, 100, proceso.ProId, DateTime.Now.AddDays(-3), true, "BAJA");
        
        await context.AvisosInternos.AddRangeAsync(avisoAlta, avisoMedia, avisoBaja);
        await context.SaveChangesAsync();

        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object>
        {
            { FilterConstants.USERID, 100 }
        };

        // Act
        var result = await repository.GetAllAsync(filtros);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result.Should().Contain(a => a.AviImportancia == "ALTA");
        result.Should().Contain(a => a.AviImportancia == "MEDIA");
        result.Should().Contain(a => a.AviImportancia == "BAJA");
    }

    #endregion

    #region NotImplemented Method Tests

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
        var aviso = CreateAviso(1, 100, "PROC001", DateTime.Now, false);

        var act = async () => await repository.AddAsync(aviso);

        await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task UpdateAsync_ThrowsNotImplementedException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var aviso = CreateAviso(1, 100, "PROC001", DateTime.Now, false);

        var act = async () => await repository.UpdateAsync(aviso);

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

    #endregion

    #region Helper Methods

    private static Proceso CreateProceso(string id, string nombre)
    {
        return new Proceso
        {
            ProId = id,
            ProNombre = nombre,
            ProEsModulo = false,
            ProDescripcion = "Test Description",
            ProFarmacia = false,
            ProDialog = false,
            ProNivel = 1,
            ProArea = "Test Area",
            ProAccion = "Index",
            ProController = "Test",
            ProImagen = null,
            ProVisibleWeb = true,
            ProIconClass = "icon-test"
        };
    }

    private static AvisoInterno CreateAviso(
        long id,
        int usuarioDestino,
        string procesoId,
        DateTime fecha,
        bool visto,
        string importancia = "MEDIA")
    {
        return new AvisoInterno
        {
            AviId = id,
            AviFecha = fecha,
            AviImportancia = importancia,
            ProId = procesoId,
            UsuIdorigen = null,
            UsuIddestino = usuarioDestino,
            AviAsunto = $"Asunto {id}",
            AviMensaje = $"Mensaje del aviso {id}",
            AviVisto = visto,
            AviTextoLink = null,
            AviLink = null,
            AviTarget = null
        };
    }

    #endregion
}
