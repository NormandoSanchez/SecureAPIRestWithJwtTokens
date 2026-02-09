using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Repository;
using SecureAPIRestWithJwtTokens.Tests.Helpers;
using SecureAPIRestWithJwtTokens.Tools;

namespace SecureAPIRestWithJwtTokens.Tests.Repository;

public class SecurityRepositoryTests
{
    private const string DefaultUser = "valid-user";
    private const string DefaultPassword = "verySecure";

    private static SecurityRepository CreateRepository(TrebolDbContext context)
    {
        var loggerMock = new Mock<ILogger<SecurityRepository>>();
        return new SecurityRepository(context, loggerMock.Object);
    }

    [Fact]
    public void Constructor_WithNullContext_ThrowsArgumentNullException()
    {
        var logger = new Mock<ILogger<SecurityRepository>>().Object;
        var act = () => new SecurityRepository(null!, logger);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("context");
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        using var context = TestDbContextFactory.CreateContext();
        var act = () => new SecurityRepository(context, null!);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
    }

    [Fact]
    public async Task GetByCredentialsAsync_WithValidCredentials_ReturnsUser()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(login: DefaultUser, password: DefaultPassword);
        await context.Usuarios.AddAsync(user);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var request = TestDataBuilder.CreateLoginRequest(DefaultUser, DefaultPassword);
        var result = await repository.GetByCredentialsAsync(request);

        result.Should().NotBeNull();
        result!.UsrLogin.Should().Be(DefaultUser);
    }

    [Fact]
    public async Task GetByCredentialsAsync_WithInvalidPassword_ReturnsNull()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(login: DefaultUser, password: DefaultPassword);
        await context.Usuarios.AddAsync(user);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var request = TestDataBuilder.CreateLoginRequest(DefaultUser, "wrong");
        var result = await repository.GetByCredentialsAsync(request);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByCredentialsAsync_WithDisabledUser_ReturnsNull()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(login: DefaultUser, password: DefaultPassword, enabled: false);
        await context.Usuarios.AddAsync(user);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var request = TestDataBuilder.CreateLoginRequest(DefaultUser, DefaultPassword);
        var result = await repository.GetByCredentialsAsync(request);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_WithEnabledUser_ReturnsEntity()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(id: 55, login: DefaultUser);
        await context.Usuarios.AddAsync(user);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(55);

        result.Should().NotBeNull();
        result!.UsrId.Should().Be(55);
    }

    [Fact]
    public async Task GetByIdAsync_WithDisabledUser_ReturnsNull()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(id: 55, login: DefaultUser, enabled: false);
        await context.Usuarios.AddAsync(user);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetByIdAsync(55);

        result.Should().BeNull();
    }

    [Fact]
    public async Task SaveRefreshToken_AddsTokenForEnabledUser()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(id: 77, login: DefaultUser);
        await context.Usuarios.AddAsync(user);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        await repository.SaveRefreshToken(77, DefaultUser, "token-new", DateTime.UtcNow.AddHours(1));
        var savedToken = await context.UsuariosJwtRefresh.SingleAsync();

        savedToken.RefreshToken.Should().Be("token-new");
        savedToken.UsrId.Should().Be(77);
    }

    [Fact]
    public async Task SaveRefreshToken_ReplacesExistingTokens()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(id: 10, login: DefaultUser);
        await context.Usuarios.AddAsync(user);
        var existing = TestDataBuilder.CreateRefreshToken(userId: 10, token: "old-token");
        existing.Usuario = user;
        await context.UsuariosJwtRefresh.AddAsync(existing);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        await repository.SaveRefreshToken(10, DefaultUser, "new-token", DateTime.UtcNow.AddHours(2));
        var tokens = await context.UsuariosJwtRefresh.ToListAsync();

        tokens.Should().ContainSingle();
        tokens[0].RefreshToken.Should().Be("new-token");
    }

    [Fact]
    public async Task GetRefreshToken_WithValidEntry_ReturnsValue()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(id: 15, login: DefaultUser);
        await context.Usuarios.AddAsync(user);
        var refreshToken = TestDataBuilder.CreateRefreshToken(userId: 15, token: "valid-token");
        refreshToken.Usuario = user;
        await context.UsuariosJwtRefresh.AddAsync(refreshToken);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetRefreshToken(15);

        result.Should().Be("valid-token");
    }

    [Fact]
    public async Task GetRefreshToken_WithExpiredEntry_ReturnsNull()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(id: 15, login: DefaultUser);
        await context.Usuarios.AddAsync(user);
        var refreshToken = TestDataBuilder.CreateRefreshToken(userId: 15, token: "expired", expiry: DateTime.UtcNow.AddMinutes(-5));
        refreshToken.Usuario = user;
        await context.UsuariosJwtRefresh.AddAsync(refreshToken);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetRefreshToken(15);

        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteRefreshToken_RemovesAllTokens()
    {
        using var context = TestDbContextFactory.CreateContext();
        var user = TestDataBuilder.CreateUser(id: 33, login: DefaultUser);
        var otherProfile = TestDataBuilder.CreateProfile(id: 99);
        var otherUser = TestDataBuilder.CreateUser(id: 34, login: "other-user", profile: otherProfile);
        await context.Usuarios.AddRangeAsync(user, otherUser);
        var tokenToDelete = TestDataBuilder.CreateRefreshToken(userId: 33, token: "t1");
        tokenToDelete.Usuario = user;
        var tokenToKeep = TestDataBuilder.CreateRefreshToken(userId: 34, token: "keep");
        tokenToKeep.Usuario = otherUser;
        await context.UsuariosJwtRefresh.AddRangeAsync(tokenToDelete, tokenToKeep);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        await repository.DeleteRefreshToken(33);
        var tokens = await context.UsuariosJwtRefresh.ToListAsync();

        tokens.Should().ContainSingle(t => t.UsrId == 34);
    }

    [Fact]
    public async Task GetCodeProcessByUserAndProfileAsync_ReturnsCodes()
    {
        using var context = TestDbContextFactory.CreateContext();
        var profile = TestDataBuilder.CreateProfile(id: 5);
        var user = TestDataBuilder.CreateUser(id: 44, login: DefaultUser, profile: profile);
        var module = TestDataBuilder.CreateProcess(id: "AB000100", isModule: true);
        var option = TestDataBuilder.CreateProcess(id: "AB000200", isModule: false);
        module.Perfiles.Add(profile);
        option.Perfiles.Add(profile);
        profile.Procesos.Add(module);
        profile.Procesos.Add(option);
        await context.Usuarios.AddAsync(user);
        await context.Procesos.AddRangeAsync(module, option);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetCodeProcessByUserAndProfileAsync(user.UsrId, profile.PeaId);

        result.Should().NotBeNull();
        result!.Should().Contain(new[] { "AB000100", "AB000200" });
    }

    [Fact]
    public async Task GetProcessByUserAndProfileAsync_WithModuleFilter_ReturnsOnlyModules()
    {
        using var context = TestDbContextFactory.CreateContext();
        var profile = TestDataBuilder.CreateProfile(id: 6);
        var user = TestDataBuilder.CreateUser(id: 60, login: DefaultUser, profile: profile);
        var module = TestDataBuilder.CreateProcess(id: "CD000100", isModule: true, visibleWeb: true);
        var menu = TestDataBuilder.CreateProcess(id: "CD000200", isModule: false, visibleWeb: true);
        module.Perfiles.Add(profile);
        menu.Perfiles.Add(profile);
        profile.Procesos.Add(module);
        profile.Procesos.Add(menu);
        await context.Usuarios.AddAsync(user);
        await context.Procesos.AddRangeAsync(module, menu);
        await context.SaveChangesAsync();
        var repository = CreateRepository(context);

        var result = await repository.GetProcessByUserAndProfileAsync(
            user.UsrId,
            profile.PeaId,
            ProcessType.Modules,
            true);

        result.Should().NotBeNull();
        result!.Should().ContainSingle(p => p.ProId == "CD000100");
    }
}
