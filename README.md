# SecureAPIRestWithJwtTokens

## a. Descripción general del proyecto

Este repositorio contiene el proyecto principal:

- **SecureAPIRestWithJwtTokens**: API RESTful con gestión de tokens JWT y envío mediante cookies httponly

## b. Stack tecnológico utilizado

- **Lenguaje principal:** C#
- **Framework:** .NET 6 (ASP.NET Core)
- **ORM:** Entity Framework Core
- **Base de datos:** SQL Server (configurable)
- **Testing:** xUnit
- **Logging:** Microsoft.Extensions.Logging
- **Gestión de dependencias:** NuGet
- **Otros:**
    - Inyección de dependencias nativa de .NET
    - Middleware personalizado para manejo de excepciones

## c. Información sobre su instalación y ejecución

### Prerrequisitos
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (o base de datos compatible)

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
4. Configura la cadena de conexión en `appsettings.json` según tu entorno.


### Ejecución de los proyectos

#### API
- Para compilar y ejecutar la API:
	```bash
	dotnet build SecureAPIRestWithJwtTokens/SecureAPIRestWithJwtTokens.csproj
	dotnet run --project SecureAPIRestWithJwtTokens/SecureAPIRestWithJwtTokens.csproj
	```
- La API estará disponible por defecto en `https://localhost:5001` o `http://localhost:5000`.

#### Tests
- Para ejecutar los tests unitarios y de integración:
	```bash
	dotnet test SecureAPIRestWithJwtTokens/SecureAPIRestWithJwtTokens.Test.csproj
	```


## d. Estructura del proyecto

```
SecureAPIRestWithJwtTokens/            # Proyecto principal de la API
├── Authorization/                     # Políticas y atributos de autorización
├── Constants/                         # Constantes de uso global
├── Controllers/                       # Controladores de la API REST
├── DataContexts/                      # Contextos de acceso a datos (EF Core)
├── Exceptions/                        # Manejo y definición de excepciones
├── Extensions/                        # Métodos de extensión y helpers
├── Logging/                           # Configuración y utilidades de logging
├── Logs/                              # Archivos de logs generados
├── Mappings/                          # Perfiles de AutoMapper
├── Middleware/                        # Middlewares personalizados
├── Models/                            # Modelos de datos (DTOs, entidades, respuestas)
├── Repository/                        # Repositorios de acceso a datos
├── Services/                          # Lógica de negocio y servicios
├── Tools/                             # Utilidades y herramientas auxiliares
├── appsettings.json                   # Configuración de la aplicación
└── Program.cs                         # Punto de entrada principal

SecureAPIRestWithJwtTokens.Test/       # Proyecto de pruebas unitarias y de integración
├── Assertions/                        # Utilidades y helpers para aserciones
├── Controllers/                       # Pruebas de controladores
├── Mappings/                          # Pruebas de mapeos
├── Middleware/                        # Pruebas de middlewares
├── Mocks/                             # Objetos simulados para pruebas
├── Repository/                        # Pruebas de repositorios
├── Services/                          # Pruebas de servicios
├── TestRepositoryBase.cs              # Base para pruebas de repositorios
├── PROMPT_GENERATION_TEST.md          # Documentación de pruebas
└── xunit.runner.json                  # Configuración de xUnit
```

## e. Funcionalidades principales

- **Autenticación y autorización:**
	- Soporte para políticas personalizadas y claims.
- **Gestión de inventario:**
	- Actualización y consulta de stock de productos.
- **Procesamiento de órdenes:**
	- Creación, validación y seguimiento de órdenes.
- **Geolocalización:**
	- Administración de países, provincias, comunidades y poblaciones.
- **Avisos y notificaciones:**
	- Gestión de avisos internos y externos.
- **Manejo centralizado de excepciones:**
	- Middleware para captura y logging de errores.
- **Pruebas unitarias:**
	- Cobertura de agentes, controladores y servicios clave.

## Referencias
- [Documentación oficial de .NET](https://learn.microsoft.com/en-us/dotnet/)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [xUnit Testing](https://xunit.net/)
- [Guía de buenas prácticas del proyecto (AGENTS.md)](AGENTS.md)
