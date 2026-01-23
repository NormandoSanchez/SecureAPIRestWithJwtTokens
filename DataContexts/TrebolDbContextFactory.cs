using SecureAPIRestWithJwtTokens.Tools;
using SecureAPIRestWithJwtTokens.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SecureAPIRestWithJwtTokens.Constants;

namespace SecureAPIRestWithJwtTokens.DataContexts;

/// <summary>
/// Fábrica de tiempo de diseño para TrebolDbContext.
/// La utiliza 'dotnet ef' para crear el contexto cuando genera migraciones, etc.
/// </summary>
public class TrebolDbContextFactory : IDesignTimeDbContextFactory<TrebolDbContext>
{
    public TrebolDbContext CreateDbContext(string[] args)
    {
        // Cargar configuración desde appsettings
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
            .Build();

        // Usar el mismo helper y constante que en ConfigureDbContext
        var helper = new ConnectionStringHelper(new CryptoGraphicService(), configuration);
        var connectionString = helper
            .GetDecriptedConnectionStringOfContext(EntitiesConstants.CONTEXT_TREBOLDB)
            .GetAwaiter()
            .GetResult();

        var optionsBuilder = new DbContextOptionsBuilder<TrebolDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new TrebolDbContext(optionsBuilder.Options);
    }
}
