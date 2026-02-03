# SecureAPIRestWithJwtTokens

## a. Descripción general del proyecto

API RESTful empresarial desarrollada en .NET 9 con autenticación JWT robusta, gestión de cookies HttpOnly seguras, y arquitectura modular escalable. El proyecto implementa patrones de diseño avanzados como Repository, Circuit Breaker, y autorización basada en políticas personalizadas.

## b. Stack tecnológico utilizado

- **Lenguaje principal:** C# 12 con características modernas (Primary Constructors, Pattern Matching)
- **Framework:** .NET 9.0 (ASP.NET Core)
- **Base de datos:** SQL Server con soporte para operaciones paralelas
- **ORM:** Entity Framework Core 9.0
- **Logging:** Serilog con múltiples sinks (Console, File)
- **Autenticación:** JWT Bearer Authentication con cookies HttpOnly
- **Resiliencia:** Polly para Circuit Breaker y políticas de reintentos
- **Mapeo:** AutoMapper 13.0
- **API Documentation:** Swagger/OpenAPI 9.0
- **Gestión de dependencias:** NuGet
- **Seguridad:** 
    - Cifrado personalizado de datos sensibles
    - Sanitización de entradas
    - Autorización basada en políticas y claims
- **Otros:**
    - Inyección de dependencias nativa
    - Middleware personalizado para manejo global de excepciones
    - Cache distribuido para optimización

## c. Información sobre su instalación y ejecución

### Prerrequisitos
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) o superior
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 2019 o superior
- Editor recomendado: Visual Studio 2022, Visual Studio Code o JetBrains Rider

### Instalación
1. Clona el repositorio:
   ```bash
   git clone https://github.com/NormandoSanchez/SecureAPIRestWithJwtTokens.git
   ```
2. Accede al directorio del proyecto:
   ```bash
   cd SecureAPIRestWithJwtTokens
   ```
3. Restaura los paquetes NuGet:
   ```bash
   dotnet restore
   ```
4. Configura las cadenas de conexión en `appsettings.json` o `appsettings.Development.json`:
   - Actualiza las conexiones a la base de datos
   - Configura las claves JWT y parámetros de seguridad
   - Ajusta los niveles de logging según el entorno

### Ejecución

#### Desarrollo
```bash
dotnet run --project SecureAPIRestWithJwtTokens.csproj
```
La API estará disponible en:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`
- Swagger UI: `https://localhost:5001/swagger`

#### Producción
```bash
dotnet build -c Release
dotnet publish -c Release -o ./publish
cd publish
dotnet SecureAPIRestWithJwtTokens.dll
```

### Archivo de pruebas HTTP
El proyecto incluye `SecureAPIRestWithJwtTokens.http` con ejemplos de todas las peticiones disponibles para probar los endpoints.


## d. Estructura del proyecto

```
SecureAPIRestWithJwtTokens/
├── Authorization/                     # Sistema de autorización personalizado
│   ├── ProcesoAuthorizationPolicyProvider.cs
│   ├── ProcesoAuthorizeAttribute.cs
│   └── ProcesoClaimRequirement.cs
├── Constants/                         # Constantes organizadas por dominio
│   ├── AuthConstants.cs              # Constantes de autenticación
│   ├── CacheConstants.cs             # Configuración de caché
│   ├── EntitiesConstants.cs          # Entidades del dominio
│   ├── EnvironmentConstants.cs       # Variables de entorno
│   ├── GenericConstants.cs           # Constantes genéricas
│   ├── ModulesConstants.cs           # Módulos del sistema
│   ├── ProcessConstants.cs           # Procesos de negocio
│   └── QueryConstants.cs             # Consultas SQL predefinidas
├── Controllers/                       # Endpoints de la API REST
│   ├── AuthController.cs             # Autenticación y autorización
│   ├── AvisosController.cs           # Gestión de avisos
│   ├── ClickCollectController.cs     # Click & Collect de farmacias
│   ├── ComunidadesAutController.cs   # Comunidades Autónomas
│   ├── PaisesController.cs           # Gestión de países
│   ├── PoblacionesController.cs      # Gestión de poblaciones
│   └── ProvinciasController.cs       # Gestión de provincias
├── DataContexts/                      # Contextos de Entity Framework
│   ├── TrebolDbContext.cs            # Contexto principal
│   └── TrebolDbContextFactory.cs     # Factory para migraciones
├── Exceptions/                        # Excepciones personalizadas
│   └── ApiExceptions.cs              # Excepciones de la API
├── Extensions/                        # Métodos de extensión
│   └── WebApplicationExtensions.cs   # Configuración del pipeline
├── Logs/                              # Archivos de log (Serilog)
│   ├── log-YYYYMMDD.txt             # Logs rotativos por fecha
├── Mappings/                          # Perfiles de AutoMapper
│   ├── AuthMappingProfile.cs
│   ├── AvisosInernosMappingProfile.cs
│   ├── DireccionMappingProfile.cs
│   ├── FarmaciaStockProfile.cs
│   └── GeografiaMappingProfile.cs
├── Middleware/                        # Middlewares personalizados
│   ├── ExceptionHandlerMIddleware.cs
│   └── GlobalExceptionHandlerMiddleware.cs
├── Models/                            # Modelos de datos
│   ├── DTO/                          # Data Transfer Objects
│   ├── Entities/                     # Entidades de base de datos
│   ├── InternalDTO/                  # DTOs internos
│   └── Responses/                    # Respuestas estándar
├── Repository/                        # Capa de acceso a datos
│   ├── IGenericRepository.cs         # Interfaz genérica
│   ├── SecurityRepository.cs         # Repositorio de seguridad
│   ├── UserRepository.cs             # Repositorio de usuarios
│   ├── Avisos/                       # Repositorios de avisos
│   ├── Farmacias/                    # Repositorios de farmacias
│   └── Geographics/                  # Repositorios de geografía
├── Services/                          # Lógica de negocio
│   ├── AuthService.cs                # Servicio de autenticación
│   ├── CircuitBreakerService.cs      # Patrón Circuit Breaker
│   ├── CryptoGraphicService.cs       # Cifrado/descifrado
│   ├── JwtService.cs                 # Generación de JWT
│   ├── MappingService.cs             # Servicio de mapeo
│   ├── ParallelSqlExecutor.cs        # Ejecución paralela SQL
│   ├── SqlDataService.cs             # Servicio de datos SQL
│   ├── IGenericService.cs            # Interfaz genérica
│   ├── ISqlDataSqlFactoryService.cs  # Factory de datos
│   ├── Avisos/                       # Servicios de avisos
│   ├── Farmacias/                    # Servicios de farmacias
│   └── Geographics/                  # Servicios de geografía
├── Tools/                             # Utilidades auxiliares
│   ├── CacheHelpers.cs               # Helpers de caché
│   ├── DataSetExtensions.cs          # Extensiones de DataSet
│   ├── Enum.cs                       # Enumeraciones
│   ├── Sanitizer.cs                  # Sanitización de entradas
│   └── Tools.cs                      # Herramientas generales
├── appsettings.json                   # Configuración base
├── appsettings.Development.json       # Configuración de desarrollo
├── Program.cs                         # Punto de entrada
├── AGENTS.md                          # Guía de buenas prácticas
├── Security.md                        # Documentación de seguridad
└── SecureAPIRestWithJwtTokens.http   # Colección de peticiones HTTP
```

## e. Funcionalidades principales

### Seguridad y Autenticación
- **Autenticación JWT:** Tokens seguros con cookies HttpOnly para prevenir ataques XSS
- **Autorización personalizada:** Sistema basado en políticas, claims y atributos personalizados
- **Cifrado de datos sensibles:** Servicio de criptografía para cadenas de conexión y datos críticos
- **Sanitización de entradas:** Protección contra inyección SQL y XSS

### Gestión Geográfica
- **Países, Provincias y Comunidades Autónomas:** CRUD completo con filtros avanzados
- **Poblaciones:** Gestión jerárquica de ubicaciones

### Farmacias
- **Click & Collect:** Sistema de pedidos y recogida en farmacia
- **Gestión de stock:** Control de inventario y disponibilidad

### Avisos y Notificaciones
- **Avisos internos:** Sistema de comunicación entre usuarios y módulos del sistema
- **Filtros avanzados:** Búsqueda por estado, usuario, fechas y módulo

### Características técnicas
- **Circuit Breaker:** Resiliencia en llamadas a servicios externos con Polly
- **Ejecución paralela:** Optimización de consultas SQL mediante paralelización
- **Cache distribuido:** Sistema de caché para mejorar el rendimiento
- **Logging estructurado:** Serilog con salidas a consola y archivos rotativos
- **Manejo global de excepciones:** Middleware centralizado para respuestas consistentes
- **Validación de DTOs:** Validación automática mediante FluentValidation integrada
- **Repository Pattern:** Abstracción de acceso a datos con repositorios genéricos
- **AutoMapper:** Mapeo automático entre entidades y DTOs

## f. Arquitectura y patrones de diseño

### Patrones implementados
- **Repository Pattern:** Abstracción de la capa de acceso a datos
- **Service Layer:** Separación de lógica de negocio
- **Dependency Injection:** Inversión de control mediante inyección de dependencias
- **Circuit Breaker:** Gestión de fallos en servicios externos
- **Factory Pattern:** Para creación de contextos y servicios
- **DTO Pattern:** Transferencia de datos desacoplada de entidades

### Arquitectura
- **Arquitectura en capas:** Separación clara entre Controllers → Services → Repository → DataContext
- **Primary Constructors:** Uso de constructores principales de C# 12
- **Middleware Pipeline:** Procesamiento de peticiones mediante middlewares personalizados
- **Claims-based Authorization:** Autorización basada en claims y políticas

## g. Endpoints principales

### Autenticación
- `POST /api/auth/login` - Autenticación de usuarios
- `POST /api/auth/refresh` - Renovación de tokens
- `POST /api/auth/logout` - Cierre de sesión

### Geografía
- `GET /api/paises` - Listado de países
- `GET /api/provincias` - Listado de provincias
- `GET /api/comunidadesaut` - Listado de comunidades autónomas
- `GET /api/poblaciones` - Listado de poblaciones

### Avisos
- `GET /api/avisos` - Listado de avisos
- `POST /api/avisos` - Crear nuevo aviso
- `PUT /api/avisos/{id}` - Actualizar aviso
- `DELETE /api/avisos/{id}` - Eliminar aviso

### Click & Collect
- `GET /api/clickcollect` - Gestión de pedidos de farmacia

Consulta el archivo [SecureAPIRestWithJwtTokens.http](SecureAPIRestWithJwtTokens.http) para ver ejemplos completos de todas las peticiones.

## Referencias

### Documentación oficial
- [Documentación oficial de .NET 9](https://learn.microsoft.com/en-us/dotnet/)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [Entity Framework Core 9](https://learn.microsoft.com/en-us/ef/core/)
- [Serilog para .NET](https://serilog.net/)
- [AutoMapper](https://automapper.org/)
- [Polly - Resiliencia](https://www.pollydocs.org/)

### Documentación del proyecto
- [Guía de buenas prácticas (AGENTS.md)](AGENTS.md) - Normas de desarrollo del proyecto
- [Documentación de seguridad (Security.md)](Security.md) - Políticas y configuración de seguridad
- [Colección de peticiones HTTP](SecureAPIRestWithJwtTokens.http) - Ejemplos de uso de la API

### Paquetes NuGet utilizados
- **AutoMapper** 13.0.1
- **Microsoft.AspNetCore.Authentication.JwtBearer** 9.0.9
- **Microsoft.EntityFrameworkCore.SqlServer** 9.0.9
- **Polly** 8.6.4
- **Serilog.AspNetCore** 9.0.0
- **Swashbuckle.AspNetCore** 9.0.6
- **System.IdentityModel.Tokens.Jwt** 8.14.0

---

**Desarrollado con .NET 9 siguiendo las mejores prácticas y patrones de diseño de la industria.**
