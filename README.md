# SecureAPIRestWithJwtTokens

## a. Descripción general del proyecto

API RESTful empresarial desarrollada en .NET 9 con autenticación JWT robusta, gestión de cookies HttpOnly seguras, y arquitectura modular escalable. El proyecto implementa patrones de diseño avanzados como Repository, Circuit Breaker, y autorización basada en políticas personalizadas.

## b. Historia

   El entorno de explotación para este proyecto es el siguiente:
   Numerosos centros de explotación (70+), cada uno es un negocio propiedad de diferentes empresas
   Cada centro de explotación dispone de un sistema informático propio para su gestión interna. Todos los centros de explotación disponen del mismo sistema en servidores propios.
   Estos servidores son accesibles, pero pueden sufrir desconexiones puntuales por averia u otras incidencias.

   La aplicación de gestión de los centros de explotación no es gestionado por la organización, es un paquete comercial.
   El conocimiento de este paquete es amplio pero no completo. Se dispone de acceso completo a la base de datos SQL de este paquete.

   En una ubicación que denominaremos Central, se alojará el resultado de este proyecto (API)
   En Central se mantiene una base de datos que debe alimentar y mantener sincronización con cada uno de los sistemas propios de gestión. Artículos, Clientes, etc.
   Las principales problemáticas a cubrir son:
      Seguridad.
      Sincronización, es necesario ejecutar queries (SQL) en cada uno de los centros de explotación, asegurando que se ha ejecutado correctamente o en su defecto mantener un control de los fallos para realizar repeticiones.
   Dado el número de centros y las posibles incidencias es necesario:
      - Obviar aquellos centros que se encuentren con conexión perdida.
      - Retomar centros tras subsanación de la incidenia de conexión.
      - Ejecucion en paralelo en varios centros simultaneamente.

## c. Stack tecnológico utilizado

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

## d. Información sobre su instalación y ejecución

### Prerrequisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) o superior
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 2019 o superior
- Editor recomendado: Visual Studio Code, Visual Studio 2022 o JetBrains Rider

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

   Para la valoración del TFM NO ES NECESARIO CAMBIAR NADA. Se apunta a BD Azure:
   [nsm-tfm-master.database.windows.net]

### Ejecución

#### Desarrollo

```bash
dotnet run --project SecureAPIRestWithJwtTokens.csproj
```

La API estará disponible en:

- HTTPS: `https://localhost:7017/index.html`
- Swagger UI: `https://localhost:7017/index.html`

#### Producción

```bash
dotnet build -c Release
dotnet publish -c Release -o ./publish
cd publish
dotnet SecureAPIRestWithJwtTokens.dll
```

### Archivos de pruebas

El proyecto incluye:

- `SecureAPIRestWithJwtTokens.http` - Ejemplos de todas las peticiones disponibles para probar los endpoints

Recomendado:

- `SecureAPIRestWithJwtTokens.postman_collection.json` - Colección de Postman lista para importar con todos los endpoints configurados a la solucion publicada.

## e. Conexiones a base de datos

La API utiliza tres tipos de conexiones:

1. **Base de datos principal (ERP - EF Core)**
   - Base de datos principal del proyecto. Es una base de datos existente desde 2014.  
   - Se configura mediante variables de entorno para evitar cadenas en claro.
   - Variables requeridas:
     - `DB_STRING_CONNECTION`: cadena de conexion con el placeholder `${DB_PASSWORD}`.
     - `DB_PASSWORD`: password cifrada que se desencripta en tiempo de ejecucion.
   - El helper `ConnectionStringHelper` sustituye `${DB_PASSWORD}` por la password desencriptada.
   - Para el proyecto se ha crreado una version reducida en Google Cloud.  
      Se ha habilitado un servidor SQL en Azure: nsm-tfm-master.database.windows.net

2. **Base CentralComun (SQL directo)**
    - Base de datos diferente a la principal, de uso por la organizacion para otras operaciones.
    - Se configura mediante variables de entorno para evitar cadenas en claro.
    - Variables requeridas:
       - `DBCOMUN_STRING_CONNECTION`: cadena de conexión con el placeholder `${DBCOMUN_PASSWORD}`.
       - `DBCOMUN_PASSWORD`: password cifrada que se desencripta en tiempo de ejecución.
    - El helper `ConnectionStringHelper` sustituye `${DBCOMUN_PASSWORD}` por la password desencriptada.
    - Para el TFM se ha alojado en el mismo servidor que la conexion anterior.

3. **Conexiones a centros de explotación (multi-servidor)**
   - Los datos de servidor, base de datos y usuario se recuperan desde la tabla UnidadesNegocioDB.
   - La password se almacena cifrada en el ERP y se desencripta al conectar. (Cifrado interno)
   - Se usan en la ejecución en paralelo con `ParallelSqlExecutor`.

## f. Estructura del proyecto

```text
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
├── SecureAPIRestWithJwtTokens.http    # Colección de peticiones HTTP
└── SecureAPIRestWithJwtTokens.postman_collection.json # Colección peticiones HTTP para importar a Postman
```

## g. Funcionalidades principales

Las funciones principales solo incluyen una mínima parte de todas las funciones necesarias.
Por confidencialidad y tiempo, solo se incluyen las básicas.
El objetivo es demostrar que el proyecto es sólido.

### EndPoints Seguridad y Autenticación

- **Autenticación JWT:** Tokens seguros con cookies HttpOnly para prevenir ataques XSS
- **Autorización personalizada:** Sistema basado en políticas, claims y atributos personalizados
- **Cifrado de datos sensibles:** Servicio de criptografía para cadenas de conexión y datos críticos
- **Sanitización de entradas:** Protección contra inyección SQL y XSS

### Gestión Geográfica

- **Países, Comunidades Autónomas, Provincias y Poblaciones:** Listados básicos con filtros avanzados
Requieren autorización básica, es decir la peticion debe ir con las httponly cookies recibidas tras la autentificación.

### Ejecución multiple de queries

- **Stock Click & Collect:** Obtención de stock en centros para servicio Click & Collect
Ejemplo de uso de parallelexecutor, no requiere autenficación. (Ver controlador para explicación)

### Avisos y Notificaciones

- **Avisos internos:** Sistema de comunicación entre usuarios y módulos del sistema
Requiere autentificacion y politica de permisos especifica. CRUD básico.

### Características técnicas

- **Circuit Breaker:** Resiliencia en llamadas a servicios externos con Polly
- **Ejecución paralela:** Optimización de consultas SQL mediante paralelización
- **Cache distribuido:** Sistema de caché para mejorar el rendimiento
- **Logging estructurado:** Serilog con salidas a consola y archivos rotativos
- **Manejo global de excepciones:** Middleware centralizado para respuestas consistentes
- **Validación de DTOs:** Validación automática mediante FluentValidation integrada
- **Repository Pattern:** Abstracción de acceso a datos con repositorios genéricos
- **AutoMapper:** Mapeo automático entre entidades y DTOs

## h. Arquitectura y patrones de diseño

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

## i. Endpoints principales

### Autenticación

- `POST /api/auth/login` - Autenticación de usuarios
- `POST /api/auth/refresh` - Renovación de tokens
- `GET /api/Auth/session/verify` - Comprobación de sesión autenticada
- `POST /api/auth/logout` - Cierre de sesión

### Autorización

Para un usuario autentificado.

- `GET /api/Auth/processes/mainModules` - Obtencion de info de modulos del sistema autorizados.
- `GET /api/Auth/processes/menuOptions` - Obtencion de info de procesos autorizados de un modulo. Para construir menu de un modulo.
- `GET /api/Auth/processes/Codes` - Obtencion de codigos de procesos autorizados. Para generar los permisos a procesos de un asuario.

### Geografía

Metodos cacheados

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

- `GET /api/clickcollect` - Recuperar centros con stock para servir peticion Click & Collet

Consulta el archivo [SecureAPIRestWithJwtTokens.http](src\SecureAPIRestWithJwtTokens\SecureAPIRestWithJwtTokens.http) para ver ejemplos completos de todas las peticiones.

Recomendado:

Importar a WorkSpace en Postman el archivo [SecureAPIRestWithJwtTokens.postman_collection.json](src\SecureAPIRestWithJwtTokens\SecureAPIRestWithJwtTokens.postman_collection.json) para ver ejemplos completos de todas las peticiones en postman.

## Secuencia de ejecucion de EndPoints

### Circuito normal

- Login ->  session/verify -> refresh
- processes/mainModules -> processes/menuOptions -> processes/Codes
- paises -> comunidadesaut -> provincias -> Poblaciones
- Logout

### No Autorizados

- Logout (por sí aún estamos autenticados)
- session/verify (UnAuthorized)

## Referencias

### Documtación oficial

- [Documentación oficial de .NET 9](https://learn.microsoft.com/en-us/dotnet/)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [Entity Framework Core 9](https://learn.microsoft.com/en-us/ef/core/)
- [Serilog para .NET](https://serilog.net/)
- [AutoMapper](https://automapper.org/)
- [Polly - Resiliencia](https://www.pollydocs.org/)

### Documentación del proyecto

- [Guía de buenas prácticas (AGENTS.md)](AGENTS.md) - Normas de desarrollo del proyecto

- [Documentación de seguridad (SECURITY.md)](SECURITY.md) - Políticas y configuración de seguridad

- [Colección de peticiones HTTP](src\SecureAPIRestWithJwtTokens\SecureAPIRestWithJwtTokens.http) - Ejemplos de uso de la API

> **Importante:**  - [Colección Postman](src\SecureAPIRestWithJwtTokens\SecureAPIRestWithJwtTokens.postman_collection.json) - Importar en Postman para probar la API

- [Ejemplo de uso en codigo de ParallelSqlExecutor](src\SecureAPIRestWithJwtTokens\Services\_CodeExamples\ParallelSqlExecutor.md) - Uso práctico del ejecutor paralelo de SQL

- [Ejemplo de uso en codigo de SqlDataService](src\SecureAPIRestWithJwtTokens\Services\_CodeExamples\SqlDataService.md) - Uso práctico del servicio de datos SQL

### Paquetes NuGet utilizados

- **AutoMapper** 13.0.1
- **Microsoft.AspNetCore.Authentication.JwtBearer** 9.0.9
- **Microsoft.AspNetCore.OpenApi** 9.0.9
- **Microsoft.EntityFrameworkCore.Design** 9.0.9
- **Microsoft.EntityFrameworkCore.SqlServer** 9.0.9
- **Microsoft.EntityFrameworkCore.Tools** 9.0.9
- **Polly** 8.6.4
- **Serilog.AspNetCore** 9.0.0
- **Serilog.Settings.Configuration** 9.0.0
- **Serilog.Sinks.Console** 6.0.0
- **Serilog.Sinks.File** 7.0.0
- **Swashbuckle.AspNetCore** 9.0.6
- **System.IdentityModel.Tokens.Jwt** 8.14.0

---

**Desarrollado con .NET 9 siguiendo las mejores prácticas y patrones de diseño de la industria.**
