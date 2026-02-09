using Microsoft.EntityFrameworkCore;
using SecureAPIRestWithJwtTokens.DataContexts;

namespace SecureAPIRestWithJwtTokens.Tests.Helpers;

public static class TestDbContextFactory
{
    public static TrebolDbContext CreateContext(string? databaseName = null)
    {
        var options = new DbContextOptionsBuilder<TrebolDbContext>()
            .UseInMemoryDatabase(databaseName ?? Guid.NewGuid().ToString())
            .Options;

        var context = new TrebolDbContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }
}
