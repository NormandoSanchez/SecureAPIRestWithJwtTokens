using SecureAPIRestWithJwtTokens.Authorization;
using SecureAPIRestWithJwtTokens.Constants;
using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Exceptions;
using SecureAPIRestWithJwtTokens.Middleware;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Repository;
using SecureAPIRestWithJwtTokens.Repository.Farmacias;
using SecureAPIRestWithJwtTokens.Repository.Geographics;
using SecureAPIRestWithJwtTokens.Services;
using SecureAPIRestWithJwtTokens.Services.Farmacias;
using SecureAPIRestWithJwtTokens.Services.Geographics;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace SecureAPIRestWithJwtTokens.Extensions
{
    public static class WebApplicationExtensions
    {
        /// <summary>
        /// Carga la configuración de la API desde el archivo appsettings.json.
        /// </summary>
        /// <param name="builder"></param>
        public static ApiConfiguration LoadConfiguration(this WebApplicationBuilder builder)
        {
            // Cargar configuración personalizada desde appsettings.json
            var configuration = builder.Configuration;
            var apiConfiguration = new ApiConfiguration();
            configuration.Bind(apiConfiguration);
            builder.Services.AddSingleton(apiConfiguration);

            return apiConfiguration;
        }

        /// <summary>
        /// Configura Serilog como el proveedor de registro para la aplicación.
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureSerilog(this WebApplicationBuilder builder)
        {
            // Configurar Serilog como el proveedor de registro
            builder.Host.UseSerilog((context, services, configuration) =>
            {
                configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext();
            });
        }

        /// <summary>
        /// Configura los DbContexts con las cadenas de conexión desencriptadas.
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="ValidationException"></exception>
        public static void ConfigureDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TrebolDbContext>((sp, options) =>
            {
                // Obtener dependencias desde DI
                var helper = sp.GetRequiredService<ConnectionStringHelper>();

                var connectionString = helper
                    .GetDecriptedConnectionStringOfContext()
                    .GetAwaiter()
                    .GetResult();

                if (string.IsNullOrEmpty(connectionString))
                {
                    Log.Error("Problemas en la configuración de la cadena de conexión.");
                    throw new ValidationException("La cadena de conexión no puede ser nula o vacía.");
                }

                options.UseSqlServer(connectionString);
            });
        }

        /// <summary>
        /// Configura el pipeline de solicitudes HTTP para la aplicación.
        /// </summary>
        /// <remarks>Este método configura los componentes de middleware para manejar excepciones globales, habilitar
        /// Swagger para la documentación de la API, forzar la redirección HTTPS, configurar la autenticación y autorización,
        /// y mapear los controladores. También aplica la limitación de velocidad y ajusta el comportamiento del pipeline en función del
        /// entorno de la aplicación (p. ej., habilitando HSTS en entornos que no son de desarrollo).</remarks>
        /// <param name="app">La instancia de <see cref="WebApplication"/> a configurar.</param>
        /// <param name="apiConfiguration">La configuración de la API utilizada para configurar la documentación de Swagger.</param>
        public static void ConfigurePipeline(this WebApplication app, ApiConfiguration apiConfiguration)
        {
            // *** ADD GLOBAL EXCEPTION HANDLING MIDDLEWARE ***
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            // Activar Swagger en desarrollo y producción 
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(apiConfiguration.DatosDocumentacion.Path, "V1");
                options.RoutePrefix = string.Empty;
            });

            // Configurar el pipeline de solicitudes HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            // Forzar el uso de HTTPS en las redirecciones
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseResponseCaching();

            // Política de cookies por defecto (fuerza HttpOnly y Secure)
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                Secure = CookieSecurePolicy.Always,
                MinimumSameSitePolicy = SameSiteMode.None
            });

            // CORS debe ir entre UseRouting y autenticación
            app.UseCors("SpaClient");

            // *** AGREGAR AUTENTICACIÓN Y AUTORIZACIÓN ***
            app.UseAuthentication();
            app.UseAuthorization();

            // Limitar uso 
            app.UseRateLimiter();

            app.MapControllers();
        }

        public static void AddServices(this WebApplicationBuilder builder, ApiConfiguration apiConfiguration)
        {
            builder.Services.AddControllers();
            
            // Habilitar caché de respuesta
            builder.Services.AddResponseCaching();
            // Configurar caché en memoria con límite de tamaño
            builder.Services.AddMemoryCache(options =>
            {
                options.SizeLimit = 1024; // Límite de tamaño total (unidades relativas)
                options.CompactionPercentage = 0.25; // Liberar 25% cuando se alcance el límite
                options.ExpirationScanFrequency = TimeSpan.FromMinutes(5); // Escanear cada 5 minutos
            });

            // Swagger
            AddSwaggerDocumentation(builder, apiConfiguration);

            // AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Custom Services
            builder.Services.AddScoped<IExceptionHandlerService, ExceptionHandlerMiddleware>();
            // Servicio de encriptación (interno por defecto) y variante externa (keyed)
            // Debe estar registrado antes que IJwtService
            builder.Services.AddSingleton<ICryptoGraphicService, CryptoGraphicService>(sp => new CryptoGraphicService(true));
            builder.Services.AddKeyedSingleton<ICryptoGraphicService>("external", (sp, _) => new CryptoGraphicService(false));
            builder.Services.AddTransient<ConnectionStringHelper>(); // Cada vez que se inyecte, se crea una nueva instancia
            builder.Services.AddScoped<IJwtService, JwtService>();
                        
            // Opciones JWT con clave ya desencriptada
            AddJWTOptions( builder);

            AddCircuitBreaker(builder);
            AddCustomServices(builder);
            AddCustomRepositories(builder);

            builder.Services.AddScoped<IMappingService, MappingService>();

            // Configurar autenticación JWT (sin BuildServiceProvider manual)
            ConfigureJwtAuthentication(builder);

            AddCors(builder, apiConfiguration);

            // Customn Authorization
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, ProcesoAuthorizationPolicyProvider>();
            builder.Services.AddScoped<IAuthorizationHandler, ProcesoClaimHandler>();

            // Configurar limitación de tasa
            SetRateLimitProgram(builder);
        }

        /// <summary>
        /// Agrega servicios relacionados con el patrón Circuit Breaker al contenedor de servicios.
        /// </summary>
        /// <param name="builder"></param>  
        private static void  AddCircuitBreaker(this WebApplicationBuilder builder)
        {
            // El gestor de Circuit Breakers debe ser Singleton para mantener el estado de los circuitos.
            builder.Services.AddSingleton<ICircuitBreakerService, CircuitBreakerService>();
            builder.Services.AddSingleton<ISqlDataServiceFactory, SqlDataServiceFactory>();
            builder.Services.AddScoped<IParallelSqlExecutor<DataTable>, ParallelSqlExecutor<DataTable>>(); // DataTable para queries
            builder.Services.AddScoped<IParallelSqlExecutor<int>, ParallelSqlExecutor<int>>(); // int para comandos 
        }

        /// <summary>
        /// Configura las políticas de CORS para la aplicación.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="apiConfiguration"></param>
        private static void AddCors(this WebApplicationBuilder builder, ApiConfiguration apiConfiguration)
        {
            // CORS con credenciales, leyendo orígenes permitidos desde configuración
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("SpaClient", policy =>
                {
                    ConfigureSpaClientCorsPolicy(policy, apiConfiguration);
                });
            });

        }

        /// <summary>
        /// Configura la política de CORS para SpaClient.
        /// </summary>
        /// <param name="policy">El builder de la política de CORS.</param>
        /// <param name="apiConfiguration">Configuración de la API.</param>
        private static void ConfigureSpaClientCorsPolicy(CorsPolicyBuilder policy, ApiConfiguration apiConfiguration)
        {
            var origins = apiConfiguration.Cors.AllowedOrigins ?? [];
            var allowAnyHeader = apiConfiguration.Cors.AllowAnyHeader;
            var allowAnyMethod = apiConfiguration.Cors.AllowAnyMethod;

            if (origins.Length > 0 && origins[0] == "*")
            {
                policy.AllowAnyOrigin()
                      .WithHeaders(allowAnyHeader ? "*" : "Authorization", "Content-Type")
                      .WithMethods(allowAnyMethod ? "*" : "GET", "POST", "PUT", "DELETE", "OPTIONS");
            }
            else if (origins.Length > 0)
            {
                policy.WithOrigins(origins)
                      .AllowCredentials()
                      .WithHeaders(allowAnyHeader ? "*" : "Authorization", "Content-Type")
                      .WithMethods(allowAnyMethod ? "*" : "GET", "POST", "PUT", "DELETE", "OPTIONS");
            }
            else
            {
                // Sin orígenes configurados, crea política cerrada sin permitir cross-site
                policy.DisallowCredentials();
            }
        }

        /// <summary>
        /// Agrega las opciones de JWT al contenedor de servicios.
        /// SecretKey se recupera de la configuracion y se desencripta con el metodo interno 
        /// </summary>
        /// <param name="builder"></param>
        private static void AddJWTOptions(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<JwtAuthOptions>(sp =>
            {
                var config = sp.GetRequiredService<ApiConfiguration>();
                var crypto = sp.GetRequiredService<ICryptoGraphicService>();

                var encryptedKey = config.JwtSettings.SecretKey;
                if (string.IsNullOrEmpty(encryptedKey))
                {
                    throw new JwtKeyFFailureException("La clave JWT no está configurada en appsettings.json");
                }

                var decryptedKey = crypto.DecriptAsync(encryptedKey).GetAwaiter().GetResult();
                if (string.IsNullOrEmpty(decryptedKey))
                {
                    throw new JwtKeyFFailureException("No se pudo desencriptar la clave JWT");
                }

                return new JwtAuthOptions
                {
                    Issuer = config.JwtSettings.Issuer,
                    SecretKey = decryptedKey,
                    AccessTokenExpirationMinutes = config.JwtSettings.AccessTokenExpirationMinutes
                };
            });
        }

        /// <summary>
        /// Agrega servicios de entidades al contenedor de servicios.
        /// </summary>
        /// <param name="builder"></param>
        private static void AddCustomServices(this WebApplicationBuilder builder)
        {
            // Security
            builder.Services.AddScoped<IAuthService, AuthService>();

            // Geographics
            builder.Services.AddScoped<IGenericService<PaisDto>, PaisService>();
            builder.Services.AddScoped<IGenericService<ComunidadAutDto>, ComunidadAutService>();
            builder.Services.AddScoped<IGenericService<ProvinciaDto>, ProvinciaService>();
            builder.Services.AddScoped<IGenericService<PoblacionDto>, PoblacionService>();
            
            // Farmacias
            builder.Services.AddScoped<IStockFarmaciaCCResultService, StockFarmaciasCCService>();
        }

        /// <summary>
        /// Agrega repositorios personalizados al contenedor de servicios.
        /// </summary>
        /// <param name="builder"></param>
        private static void AddCustomRepositories(this WebApplicationBuilder builder)
        {
            // Security
            builder.Services.AddScoped<ISecurityRepo, SecurityRepository>();
            builder.Services.AddScoped<IUserRepo, UserRepository>();
            // Geographics
            builder.Services.AddScoped<IGenericRepository<Pais>, PaisRepository>();
            builder.Services.AddScoped<IGenericRepository<ComunidadAut>, ComunidadAutRepository>();
            builder.Services.AddScoped<IGenericRepository<Provincia>, ProvinciaRepository>();
            builder.Services.AddScoped<IGenericRepository<Poblacion>, PoblacionRepository>();
            // Farmacias    
            builder.Services.AddScoped<IStockFarmaciaCCRepo, StockFarmaciasCCRepository>();
        }

        /// <summary>
        /// Agrega la documentación de Swagger al contenedor de servicios.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="apiConfiguration"></param>
        private static void AddSwaggerDocumentation(this WebApplicationBuilder builder, ApiConfiguration apiConfiguration)
        {
            // swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = apiConfiguration.DatosDocumentacion.Titulo,
                    Version = apiConfiguration.DatosDocumentacion.Version,
                    Description = apiConfiguration.DatosDocumentacion.Descripcion,
                    Contact = new OpenApiContact
                    {
                        Name = apiConfiguration.DatosDocumentacion.Contacto,
                        Email = apiConfiguration.DatosDocumentacion.Email
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // 1. Define el esquema de seguridad JWT        
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autenticación JWT usando el esquema Bearer. Ejemplo: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                // 2. Requiere el esquema de seguridad en los endpoints protegidos
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        // Método para configurar autenticación JWT usando JwtAuthOptions desde DI
        private static void ConfigureJwtAuthentication(this WebApplicationBuilder builder)
        {
            // Registrar autenticación JWT básica
            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer();

            // Configurar JwtBearerOptions usando JwtAuthOptions (con clave ya desencriptada)
            builder.Services
                .AddOptions<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme)
                .Configure<JwtAuthOptions>((options, jwtOptions) =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        // Fuerza uso exclusivo de cookie HttpOnly para el token
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Cookies.TryGetValue("access_token", out var tokenFromCookie))
                            {
                                context.Token = tokenFromCookie;
                            }
                            else
                            {
                                context.Token = null; // No usar Authorization header
                            }
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            var logger = context.HttpContext.RequestServices
                                .GetRequiredService<ILogger<Program>>();
                            logger.LogError(context.Exception, "Error de autenticación");
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            var username = context.Principal?.Identity?.Name;
                            Log.Information("Token JWT validado para usuario: {Username}", Sanitizer.Sanitize(username));
                            return Task.CompletedTask;
                        }
                    };
                });

            builder.Services.AddAuthorization();
        }

        /// <summary>
        /// Configura la limitación de tasa para la aplicación, incluyendo políticas globales y específicas.
        /// </summary>
        /// <remarks>Este método configura un limitador de tasa global y una política de limitación específica para
        /// las solicitudes de inicio de sesión. El limitador global restringe las solicitudes basándose en la dirección IP del cliente, 
        /// permitiendo hasta 10 solicitudes por minuto. La política "login" restringe aún más los intentos de inicio de sesión a 5 
        /// solicitudes cada 5 minutos por dirección IP.</remarks>
        /// <param name="builder">El <see cref="WebApplicationBuilder"/> utilizado para configurar los servicios de la aplicación.</param>
        private static void SetRateLimitProgram(this WebApplicationBuilder builder)
        {
            builder.Services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "anónimo",
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 10,
                            QueueLimit = 0,
                            Window = TimeSpan.FromMinutes(1)
                        }));

                // Política específica para login
                options.AddPolicy("login", httpContext =>
                     RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "anónimo",
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 5,
                            QueueLimit = 0,
                            Window = TimeSpan.FromMinutes(5)
                        }));
            });
        }
    }
}
