using SecureAPIRestWithJwtTokens.Extensions;
using Serilog;

// Configurar un logger de arranque para registrar problemas durante el inicio
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Cargar configuración personalizada desde appsettings.json
    var apiConfiguration = builder.LoadConfiguration();

    Log.Information("Aplicación iniciada.");

    // Configurar Serilog como el proveedor de registro
    builder.ConfigureSerilog();

    // Registrar servicios personalizados
    builder.AddServices(apiConfiguration);

    // Configurar DbContexts con las cadenas de conexión desencriptadas
    builder.ConfigureDbContext();

    var app = builder.Build();

    // Configurar el pipeline de solicitudes HTTP
    app.ConfigurePipeline(apiConfiguration);

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "La aplicación ha terminado inesperadamente.");
}
finally
{
    Log.Information("Aplicación cerrada.");
    await Log.CloseAndFlushAsync();
}