using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Repository.Geographics;
using SecureAPIRestWithJwtTokens.Tests.Helpers;

namespace SecureAPIRestWithJwtTokens.Tests.Repository.Geographics;

/// <summary>
/// Pruebas unitarias para el repositorio de comunidades autónomas
/// </summary>
public class ComunidadAutRepositoryTests
{
    private static ComunidadAutRepository CreateRepository(TrebolDbContext context)
    {
        var loggerMock = new Mock<ILogger<ComunidadAutRepository>>();
        return new ComunidadAutRepository(context, loggerMock.Object);
    }

    [Fact]
    public void Constructor_WithNullContext_ThrowsArgumentNullException()
    {
        var logger = new Mock<ILogger<ComunidadAutRepository>>().Object;
        var act = () => new ComunidadAutRepository(null!, logger);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("context");
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new ComunidadAutRepository(context, null!);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
    }

    [Fact]
    public async Task GetByIdAsync_WithExistingComunidadAut_ReturnsExpectedComunidadAut()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(1);

        result.Should().NotBeNull();
        result!.CauNombre.Should().Be("Madrid");
    }

    [Fact]
    public async Task GetByIdAsync_WhenComunidadAutDoesNotExist_ReturnsNull()
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
    public async Task GetAllAsync_WithoutFilters_ReturnsAllComunidadesAut()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad1 = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        var comunidad2 = TestDataBuilder.CreateComunidadAut(id: 2, nombre: "Cataluña", paisId: 1, pais: pais);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddRangeAsync(comunidad1, comunidad2);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetAllAsync();

        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(c => c.CauNombre == "Madrid");
        result.Should().Contain(c => c.CauNombre == "Cataluña");
    }

    [Fact]
    public async Task GetAllAsync_WithPaisFilter_ReturnsFilteredComunidadesAut()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais1 = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var pais2 = TestDataBuilder.CreatePais(id: 2, nombre: "Portugal");
        var comunidad1 = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais1);
        var comunidad2 = TestDataBuilder.CreateComunidadAut(id: 2, nombre: "Lisboa", paisId: 2, pais: pais2);
        await context.Paises.AddRangeAsync(pais1, pais2);
        await context.ComunidadesAut.AddRangeAsync(comunidad1, comunidad2);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);
        var filtros = new Dictionary<string, object> { { FilterConstants.PAIS, 1 } };

        var result = await repository.GetAllAsync(filtros);

        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.Should().Contain(c => c.CauNombre == "Madrid");
        result.Should().NotContain(c => c.CauNombre == "Lisboa");
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
    public async Task AddAsync_WithValidComunidadAut_AddsComunidadAutSuccessfully()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Andalucía", paisId: 1, pais: pais);
        await context.Paises.AddAsync(pais);
        await context.SaveChangesAsync();

        await repository.AddAsync(comunidad);

        var result = await context.ComunidadesAut.FindAsync(1);
        result.Should().NotBeNull();
        result!.CauNombre.Should().Be("Andalucía");
    }

    [Fact]
    public async Task AddAsync_WithNullComunidadAut_ThrowsArgumentNullException()
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
        var comunidad1 = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad1);
        await context.SaveChangesAsync();
        var comunidad2 = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Cataluña", paisId: 1, pais: pais);

        var act = async () => await repository.AddAsync(comunidad2);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*ya existe*");
    }

    [Fact]
    public async Task UpdateAsync_WithValidComunidadAut_UpdatesComunidadAutSuccessfully()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 1, nombre: "Madrid", paisId: 1, pais: pais);
        await context.Paises.AddAsync(pais);
        await context.ComunidadesAut.AddAsync(comunidad);
        await context.SaveChangesAsync();

        comunidad.CauNombre = "Comunidad de Madrid";
        await repository.UpdateAsync(comunidad);

        var result = await context.ComunidadesAut.FindAsync(1);
        result.Should().NotBeNull();
        result!.CauNombre.Should().Be("Comunidad de Madrid");
    }

    [Fact]
    public async Task UpdateAsync_WithNullComunidadAut_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.UpdateAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task UpdateAsync_WithNonExistentComunidadAut_ThrowsInvalidOperationException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var comunidad = TestDataBuilder.CreateComunidadAut(id: 999, nombre: "NoExiste", paisId: 1, pais: pais);

        var act = async () => await repository.UpdateAsync(comunidad);

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
