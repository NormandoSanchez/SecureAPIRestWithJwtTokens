using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Repository.Geographics;
using SecureAPIRestWithJwtTokens.Tests.Helpers;

namespace SecureAPIRestWithJwtTokens.Tests.Repository.Geographics;

/// <summary>
/// Pruebas unitarias para el repositorio de poblaciones
/// </summary>
public class PoblacionRepositoryTests
{
    private static PoblacionRepository CreateRepository(TrebolDbContext context)
    {
        var loggerMock = new Mock<ILogger<PoblacionRepository>>();
        return new PoblacionRepository(context, loggerMock.Object);
    }

    [Fact]
    public void Constructor_WithNullContext_ThrowsArgumentNullException()
    {
        var logger = new Mock<ILogger<PoblacionRepository>>().Object;
        var act = () => new PoblacionRepository(null!, logger);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("context");
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new PoblacionRepository(context, null!);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
    }

    [Fact]
    public async Task GetByIdAsync_WithExistingPoblacion_ReturnsExpectedPoblacion()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        var poblacion = TestDataBuilder.CreatePoblacion(id: 1, nombre: "Madrid", provinciaId: 1, paisId: 1, provincia: provincia);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddAsync(provincia);
        await context.Poblaciones.AddAsync(poblacion);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(1);

        result.Should().NotBeNull();
        result!.PobNombre.Should().Be("Madrid");
    }

    [Fact]
    public async Task GetByIdAsync_WhenPoblacionDoesNotExist_ReturnsNull()
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
    public async Task GetAllAsync_WithoutFilters_ReturnsAllPoblaciones()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        var poblacion1 = TestDataBuilder.CreatePoblacion(id: 1, nombre: "Madrid", provinciaId: 1, paisId: 1, provincia: provincia);
        var poblacion2 = TestDataBuilder.CreatePoblacion(id: 2, nombre: "Alcalá de Henares", provinciaId: 1, paisId: 1, provincia: provincia);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddAsync(provincia);
        await context.Poblaciones.AddRangeAsync(poblacion1, poblacion2);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetAllAsync();

        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(p => p.PobNombre == "Madrid");
        result.Should().Contain(p => p.PobNombre == "Alcalá de Henares");
    }

    [Fact]
    public async Task GetAllAsync_WithProvinciaFilter_ReturnsFilteredPoblaciones()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia1 = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        var provincia2 = TestDataBuilder.CreateProvincia(id: 2, nombre: "Barcelona", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        var poblacion1 = TestDataBuilder.CreatePoblacion(id: 1, nombre: "Madrid", provinciaId: 1, paisId: 1, provincia: provincia1);
        var poblacion2 = TestDataBuilder.CreatePoblacion(id: 2, nombre: "Barcelona", provinciaId: 2, paisId: 1, provincia: provincia2);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddRangeAsync(provincia1, provincia2);
        await context.Poblaciones.AddRangeAsync(poblacion1, poblacion2);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object> { { FilterConstants.PROVINCIA, 1 } };

        var result = await repository.GetAllAsync(filtros);

        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.Should().Contain(p => p.PobNombre == "Madrid");
        result.Should().NotContain(p => p.PobNombre == "Barcelona");
    }

    [Fact]
    public async Task GetAllAsync_WithPaisFilter_ReturnsFilteredPoblaciones()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais1 = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var pais2 = TestDataBuilder.CreatePais(id: 2, nombre: "Portugal");
        var comunidad1 = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais1);
        var comunidad2 = TestDataBuilder.CreateComunidadAut(id: 2, nombre: "Lisboa", paisId: 2, pais: pais2);
        var provincia1 = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad1);
        var provincia2 = TestDataBuilder.CreateProvincia(id: 2, nombre: "Lisboa", comunidadAutId: 2, paisId: 2, comunidadAut: comunidad2);
        var poblacion1 = TestDataBuilder.CreatePoblacion(id: 1, nombre: "Madrid", provinciaId: 1, paisId: 1, provincia: provincia1);
        var poblacion2 = TestDataBuilder.CreatePoblacion(id: 2, nombre: "Lisboa", provinciaId: 2, paisId: 2, provincia: provincia2);
        await context.Paises.AddRangeAsync(pais1, pais2);
        await context.ComunidadesAut.AddRangeAsync(comunidad1, comunidad2);
        await context.Provincias.AddRangeAsync(provincia1, provincia2);
        await context.Poblaciones.AddRangeAsync(poblacion1, poblacion2);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object> { { FilterConstants.PAIS, 1 } };

        var result = await repository.GetAllAsync(filtros);

        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.Should().Contain(p => p.PobNombre == "Madrid");
        result.Should().NotContain(p => p.PobNombre == "Lisboa");
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
    public async Task AddAsync_WithValidPoblacion_AddsPoblacionSuccessfully()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        var poblacion = TestDataBuilder.CreatePoblacion(id: 1, nombre: "Getafe", provinciaId: 1, paisId: 1, provincia: provincia);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddAsync(provincia);
        await context.SaveChangesAsync();

        await repository.AddAsync(poblacion);

        var result = await context.Poblaciones.FindAsync(1);
        result.Should().NotBeNull();
        result!.PobNombre.Should().Be("Getafe");
    }

    [Fact]
    public async Task AddAsync_WithNullPoblacion_ThrowsArgumentNullException()
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
        var provincia = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        var poblacion1 = TestDataBuilder.CreatePoblacion(id: 1, nombre: "Madrid", provinciaId: 1, paisId: 1, provincia: provincia);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddAsync(provincia);
        await context.Poblaciones.AddAsync(poblacion1);
        await context.SaveChangesAsync();
        var poblacion2 = TestDataBuilder.CreatePoblacion(id: 1, nombre: "Getafe", provinciaId: 1, paisId: 1, provincia: provincia);

        var act = async () => await repository.AddAsync(poblacion2);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*ya existe*");
    }

    [Fact]
    public async Task UpdateAsync_WithValidPoblacion_UpdatesPoblacionSuccessfully()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        var poblacion = TestDataBuilder.CreatePoblacion(id: 1, nombre: "Madrid", provinciaId: 1, paisId: 1, provincia: provincia);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.Provincias.AddAsync(provincia);
        await context.Poblaciones.AddAsync(poblacion);
        await context.SaveChangesAsync();

        poblacion.PobNombre = "Villa de Madrid";
        await repository.UpdateAsync(poblacion);

        var result = await context.Poblaciones.FindAsync(1);
        result.Should().NotBeNull();
        result!.PobNombre.Should().Be("Villa de Madrid");
    }

    [Fact]
    public async Task UpdateAsync_WithNullPoblacion_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.UpdateAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task UpdateAsync_WithNonExistentPoblacion_ThrowsInvalidOperationException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var provincia = TestDataBuilder.CreateProvincia(id: 1, nombre: "Madrid", comunidadAutId: 1, paisId: 1, comunidadAut: comunidad);
        var poblacion = TestDataBuilder.CreatePoblacion(id: 999, nombre: "NoExiste", provinciaId: 1, paisId: 1, provincia: provincia);

        var act = async () => await repository.UpdateAsync(poblacion);

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
