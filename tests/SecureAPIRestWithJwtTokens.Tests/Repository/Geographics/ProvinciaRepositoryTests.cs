using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Repository.Geographics;
using SecureAPIRestWithJwtTokens.Services.Interfaces;
using SecureAPIRestWithJwtTokens.Tests.Helpers;

namespace SecureAPIRestWithJwtTokens.Tests.Repository.Geographics;

/// <summary>
/// Pruebas unitarias para el repositorio de provincias
/// </summary>
public class ProvinciaRepositoryTests
{
    private static ProvinciaRepository CreateRepository(
        TrebolDbContext context,
        ISqlDataServiceFactory? sqlFactory = null,
        ICryptoGraphicService? cryptoService = null)
    {
        var loggerMock = new Mock<ILogger<ProvinciaRepository>>();
        var sqlFactoryMock = sqlFactory ?? new Mock<ISqlDataServiceFactory>().Object;
        var cryptoServiceMock = cryptoService ?? new Mock<ICryptoGraphicService>().Object;
        return new ProvinciaRepository(context, sqlFactoryMock, cryptoServiceMock, loggerMock.Object);
    }

    [Fact]
    public void Constructor_WithNullContext_ThrowsArgumentNullException()
    {
        var logger = new Mock<ILogger<ProvinciaRepository>>().Object;
        var sqlFactory = new Mock<ISqlDataServiceFactory>().Object;
        var cryptoService = new Mock<ICryptoGraphicService>().Object;
        var act = () => new ProvinciaRepository(null!, sqlFactory, cryptoService, logger);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("context");
    }

    [Fact]
    public void Constructor_WithNullSqlFactory_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var logger = new Mock<ILogger<ProvinciaRepository>>().Object;
        var cryptoService = new Mock<ICryptoGraphicService>().Object;
        var act = () => new ProvinciaRepository(context, null!, cryptoService, logger);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("sqlDataServiceFactory");
    }

    [Fact]
    public void Constructor_WithNullCryptoService_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var logger = new Mock<ILogger<ProvinciaRepository>>().Object;
        var sqlFactory = new Mock<ISqlDataServiceFactory>().Object;
        var act = () => new ProvinciaRepository(context, sqlFactory, null!, logger);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("cryptoGraphicService");
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var sqlFactory = new Mock<ISqlDataServiceFactory>().Object;
        var cryptoService = new Mock<ICryptoGraphicService>().Object;
        var act = () => new ProvinciaRepository(context, sqlFactory, cryptoService, null!);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
    }

    [Fact]
    public async Task GetByIdAsync_WithExistingProvincia_ReturnsExpectedProvincia()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddAsync(provincia);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(1);

        result.Should().NotBeNull();
        result!.PrvNombre.Should().Be("Madrid");
    }

    [Fact]
    public async Task GetByIdAsync_WhenProvinciaDoesNotExist_ReturnsNull()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(999);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_WithZeroId_ThrowsArgumentException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.GetByIdAsync(0);

        await act.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("id");
    }

    [Fact]
    public async Task GetAllAsync_WithoutFilters_ReturnsAllProvincias()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia1 = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        var provincia2 = TestDataBuilder.CreateProvincia(id: 2, nombre: "Barcelona", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddRangeAsync(provincia1, provincia2);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetAllAsync();

        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(p => p.PrvNombre == "Madrid");
        result.Should().Contain(p => p.PrvNombre == "Barcelona");
    }

    [Fact]
    public async Task GetAllAsync_WithComunidadAutFilter_ReturnsFilteredProvincias()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad1 = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var comunidad2 = TestDataBuilder.CreateComunidadAut(id: 2, nombre: "Cataluña", paisId: 1, pais: pais);
        var provincia1 = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad1);
        var provincia2 = TestDataBuilder.CreateProvincia(id: 2, nombre: "Barcelona", comunidadAutId: 2, paisId: 1, comunidadAut: comunidad2);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddRangeAsync(comunidad1, comunidad2);
        await context.Provincias.AddRangeAsync(provincia1, provincia2);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object> { { FilterConstants.COMUNIDADAUT, 1 } };

        var result = await repository.GetAllAsync(filtros);

        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.Should().Contain(p => p.PrvNombre == "Madrid");
        result.Should().NotContain(p => p.PrvNombre == "Barcelona");
    }

    [Fact]
    public async Task GetAllAsync_WithPaisFilter_ReturnsFilteredProvincias()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais1 = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var pais2 = TestDataBuilder.CreatePais(id: 2, nombre: "Portugal");
        var comunidad1 = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais1);
        var comunidad2 = TestDataBuilder.CreateComunidadAut(id: 2, nombre: "Lisboa", paisId: 2, pais: pais2);
        var provincia1 = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad1);
        var provincia2 = TestDataBuilder.CreateProvincia(id: 2, nombre: "Lisboa", comunidadAutId: 2, paisId: 2, comunidadAut: comunidad2);
        await context.Paises.AddRangeAsync(pais1, pais2);
        await context.ComunidadesAut.AddRangeAsync(comunidad1, comunidad2);
        await context.Provincias.AddRangeAsync(provincia1, provincia2);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object> { { FilterConstants.PAIS, 1 } };

        var result = await repository.GetAllAsync(filtros);

        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.Should().Contain(p => p.PrvNombre == "Madrid");
        result.Should().NotContain(p => p.PrvNombre == "Lisboa");
    }

    [Fact]
    public async Task GetAllAsync_WhenEmpty_ReturnsEmptyList()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var result = await repository.GetAllAsync();

        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task AddAsync_WithValidProvincia_AddsProvinciaSuccessfully()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Andalucía", paisId: 1, pais: pais);
        var provincia = TestDataBuilder.CreateProvincia(id: 1, nombre: "Sevilla", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.SaveChangesAsync();

        await repository.AddAsync(provincia);

        var result = await context.Provincias.FindAsync(1);
        result.Should().NotBeNull();
        result!.PrvNombre.Should().Be("Sevilla");
    }

    [Fact]
    public async Task AddAsync_WithNullProvincia_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.AddAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task AddAsync_WithDuplicateId_ThrowsInvalidOperationException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia1 = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddAsync(provincia1);
        await context.SaveChangesAsync();
        var provincia2 = TestDataBuilder.CreateProvincia(id: 1, nombre: "Barcelona", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);

        var act = async () => await repository.AddAsync(provincia2);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*ya existe*");
    }

    [Fact]
    public async Task UpdateAsync_WithValidProvincia_UpdatesProvinciaSuccessfully()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddAsync(provincia);
        await context.SaveChangesAsync();

        provincia.PrvNombre = "Comunidad de Madrid";
        await repository.UpdateAsync(provincia);

        var result = await context.Provincias.FindAsync(1);
        result.Should().NotBeNull();
        result!.PrvNombre.Should().Be("Comunidad de Madrid");
    }

    [Fact]
    public async Task UpdateAsync_WithNullProvincia_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.UpdateAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task UpdateAsync_WithNonExistentProvincia_ThrowsInvalidOperationException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia = TestDataBuilder.CreateProvincia(id: 999, nombre: "NoExiste", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);

        var act = async () => await repository.UpdateAsync(provincia);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*no existe*");
    }

    [Fact]
    public async Task DeleteAsync_ThrowsNotImplementedException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.DeleteAsync(1);

        await act.Should().ThrowAsync<NotImplementedException>();
    }
}
