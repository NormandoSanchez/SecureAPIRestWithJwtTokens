using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Repository.Geographics;
using SecureAPIRestWithJwtTokens.Tests.Helpers;

namespace SecureAPIRestWithJwtTokens.Tests.Repository.Geographics;

/// <summary>
/// Pruebas unitarias para el repositorio de países
/// </summary>
public class PaisRepositoryTests
{
    private static PaisRepository CreateRepository(TrebolDbContext context)
    {
        var loggerMock = new Mock<ILogger<PaisRepository>>();
        return new PaisRepository(context, loggerMock.Object);
    }

    [Fact]
    public void Constructor_WithNullContext_ThrowsArgumentNullException()
    {
        var logger = new Mock<ILogger<PaisRepository>>().Object;
        var act = () => new PaisRepository(null!, logger);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("context");
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new PaisRepository(context, null!);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
    }

    [Fact]
    public async Task GetByIdAsync_WithExistingPais_ReturnsExpectedPais()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        await context.Paises.AddAsync(pais);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(1);

        result.Should().NotBeNull();
        result!.PaiNombre.Should().Be("España");
    }

    [Fact]
    public async Task GetByIdAsync_WhenPaisDoesNotExist_ReturnsNull()
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
    public async Task GetAllAsync_ReturnsAllPaises()
    {
        using var context = TestDbContextFactory.CreateContext();
        var pais1 = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        var pais2 = TestDataBuilder.CreatePais(id: 2, nombre: "Portugal");
        await context.Paises.AddRangeAsync(pais1, pais2);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetAllAsync();

        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(p => p.PaiNombre == "España");
        result.Should().Contain(p => p.PaiNombre == "Portugal");
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
    public async Task AddAsync_WithValidPais_AddsPaisSuccessfully()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "Francia");

        await repository.AddAsync(pais);

        var result = await context.Paises.FindAsync(1);
        result.Should().NotBeNull();
        result!.PaiNombre.Should().Be("Francia");
    }

    [Fact]
    public async Task AddAsync_WithNullPais_ThrowsArgumentNullException()
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
        var pais1 = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        await context.Paises.AddAsync(pais1);
        await context.SaveChangesAsync();
        var pais2 = TestDataBuilder.CreatePais(id: 1, nombre: "Portugal");

        var act = async () => await repository.AddAsync(pais2);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*ya existe*");
    }

    [Fact]
    public async Task UpdateAsync_WithValidPais_UpdatesPaisSuccessfully()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 1, nombre: "España");
        await context.Paises.AddAsync(pais);
        await context.SaveChangesAsync();
        
        var paisUpdate = TestDataBuilder.CreatePais(id: 1, nombre: "Reino de España");

        await repository.UpdateAsync(paisUpdate);

        var result = await context.Paises.FindAsync(1);
        result.Should().NotBeNull();
        result!.PaiNombre.Should().Be("Reino de España");
    }

    [Fact]
    public async Task UpdateAsync_WithNullPais_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.UpdateAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task UpdateAsync_WithNonExistentPais_ThrowsInvalidOperationException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var pais = TestDataBuilder.CreatePais(id: 999, nombre: "NoExiste");

        var act = async () => await repository.UpdateAsync(pais);

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
