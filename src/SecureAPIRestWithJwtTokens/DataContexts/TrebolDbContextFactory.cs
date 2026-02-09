using SecureAPIRestWithJwtTokens.Tools;
using SecureAPIRestWithJwtTokens.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SecureAPIRestWithJwtTokens.DataContexts;

/// <summary>
/// Fábrica de tiempo de diseño para TrebolDbContext.
/// La utiliza 'dotnet ef' para crear el contexto cuando genera migraciones, etc.
/// </summary>
public class TrebolDbContextFactory : IDesignTimeDbContextFactory<TrebolDbContext>
{
    public TrebolDbContext CreateDbContext(string[] args)
    {
        // Usar el mismo helper y constante que en ConfigureDbContext
        var helper = new ConnectionStringHelper(new CryptoGraphicService());
        var connectionString = helper
            .GetDecriptedConnectionStringOfContext()
            .GetAwaiter()
            .GetResult();

        var optionsBuilder = new DbContextOptionsBuilder<TrebolDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new TrebolDbContext(optionsBuilder.Options);
    }
}
