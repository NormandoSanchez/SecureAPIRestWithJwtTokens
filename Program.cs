using SecureAPIRestWithJwtTokens.Extensions;
using Serilog;

namespace SecureAPIRestWithJwtTokens
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configurar un logger de arranque para registrar problemas durante el inicio
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            try
            {
                // Crear el constructor de la aplicación web con los argumentos de línea de comandos
                var builder = WebApplication.CreateBuilder(args);

                // Cargar configuración personalizada desde appsettings.json
                var apiConfiguration = builder.LoadConfiguration(); // Extensión en WebApplicationExtensions.cs

                Log.Information("Aplicación iniciada.");

                // Configurar Serilog como el proveedor de registro
                builder.ConfigureSerilog(); // Extensión en WebApplicationExtensions.cs

                // Registrar servicios personalizados
                builder.AddServices(apiConfiguration); // Extensión en WebApplicationExtensions.cs

                // Configurar DbContexts con las cadenas de conexión desencriptadas
                // Debe ir despues de tener los servicios registrados 
                builder.ConfigureDbContext(); // Extensión en WebApplicationExtensions.cs

                // Construir la aplicación web
                var app = builder.Build();

                // Configurar el pipeline de solicitudes HTTP
                app.ConfigurePipeline(apiConfiguration);

                // Iniciar la aplicación y escuchar solicitudes HTTP
                app.Run();
            }

            catch (Exception ex)
            {
                // Registrar cualquier excepción fatal que detenga la aplicación
                Log.Fatal(ex, "La aplicación ha terminado inesperadamente.");
            }

            finally
            {
                // Asegurarse de que todos los registros se escriban antes de salir
                Log.Information("Aplicación cerrada.");
                Log.CloseAndFlush();
            }
        }
    }
}