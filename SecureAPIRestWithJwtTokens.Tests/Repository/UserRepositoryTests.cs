using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Repository;
using SecureAPIRestWithJwtTokens.Tests.Helpers;
using Xunit;

namespace SecureAPIRestWithJwtTokens.Tests.Repository;

public class UserRepositoryTests
{
    private static UserRepository CreateRepository(TrebolDbContext context)
    {
        var loggerMock = new Mock<ILogger<UserRepository>>();
        return new UserRepository(context, loggerMock.Object);
    }

    [Fact]
    public void Constructor_WithNullContext_ThrowsArgumentNullException()
    {
        var logger = new Mock<ILogger<UserRepository>>().Object;
        var act = () => new UserRepository(null!, logger);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("context");
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new UserRepository(context, null!);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
    }

    [Fact]
    public async Task GetByIdAsync_WithExistingUser_ReturnsExpectedUser()
    {
        using var context = TestDbContextFactory.CreateContext();
        var profile = TestDataBuilder.CreateProfile(id: 9);
        var user = TestDataBuilder.CreateUser(id: 101, login: "user-101", profile: profile);
        user.Empleados.Add(TestDataBuilder.CreateEmployee(id: 1));
        await context.Usuarios.AddAsync(user);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(101);

        result.Should().NotBeNull();
        result!.UsrLogin.Should().Be("user-101");
        result.Empleados.Should().NotBeNull();
    }

    [Fact]
    public async Task GetByIdAsync_WhenUserDoesNotExist_ReturnsNull()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(999);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_WithMultipleEmployees_ReturnsOnlyOneEmployee()
    {
        using var context = TestDbContextFactory.CreateContext();
        var profile = TestDataBuilder.CreateProfile(id: 2);
        var user = TestDataBuilder.CreateUser(id: 200, login: "user-200", profile: profile);
        var employee1 = TestDataBuilder.CreateEmployee(id: 10, businessUnitId: 10);
        var employee2 = TestDataBuilder.CreateEmployee(id: 11, businessUnitId: 11);
        user.Empleados.Add(employee1);
        user.Empleados.Add(employee2);
        await context.Usuarios.AddAsync(user);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(200);

        result.Should().NotBeNull();
        result!.Empleados.Should().NotBeNull();
        result.Empleados!.Should().ContainSingle();
        result.Empleados!.First().EmpId.Should().Be(employee1.EmpId);
    }

    [Fact]
    public async Task GetAllAsync_ThrowsNotImplementedException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);

        var act = async () => await repository.GetAllAsync();

        await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task AddAsync_ThrowsNotImplementedException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var user = TestDataBuilder.CreateUser();

        var act = async () => await repository.AddAsync(user);

        await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task UpdateAsync_ThrowsNotImplementedException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var repository = CreateRepository(context);
        var user = TestDataBuilder.CreateUser();

        var act = async () => await repository.UpdateAsync(user);

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
}
