# AGENTS.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.
Generated fron NoteBookLM

## Build and Run Commands

```powershell
# Restore dependencies
dotnet restore

# Build (Debug)
dotnet build

# Build (Release)
dotnet build -c Release

# Run in development
dotnet run --project SecureAPIRestWithJwtTokens.csproj

# Publish for production
dotnet publish -c Release -o ./publish
```

The API runs at `https://localhost:7017` with Swagger UI at the root.

## Architecture Overview

### Request Flow

HTTP Request → GlobalExceptionHandlerMiddleware → Controller → Service → Repository → TrebolDbContext (EF Core) → SQL Server

### Key Layers

- **Controllers/**: REST endpoints, receive DTOs, return `ApiResponse<T>` via `ApiResponseBuilder`
- **Services/**: Business logic, injected via interfaces (e.g., `IGenericService<T>`)
- **Repository/**: Data access via EF Core, implements `IGenericRepository<T>`
- **DataContexts/**: `TrebolDbContext` - main EF Core context with encrypted connection strings

### Service Registration

All DI registration happens in `Extensions/WebApplicationExtensions.cs`:
    - `AddServices()` - configures all services, auth, caching, CORS
    - `ConfigureDbContext()` - sets up EF Core with decrypted connection strings
    - `ConfigurePipeline()` - middleware order and HTTP pipeline

### Authentication Flow (JWT with HttpOnly Cookies)

1. `POST /api/auth/login` validates credentials via `AuthService`
2. `JwtService` generates access/refresh tokens
3. Tokens stored in HttpOnly cookies (`access_token`, `refresh_token`)
4. `JwtBearerEvents.OnMessageReceived` extracts token from cookie (not headers)

### Custom Authorization

Use `[ProcesoAuthorize("PROCESS_CODE")]` attribute for process-based authorization:

```csharp

[ProcesoAuthorize("ADM001", "ADM002")]  // Requires any of these process codes
public async Task<IActionResult> SomeEndpoint() { ... }
```

Handler: `Authorization/ProcesoClaimHandler.cs`

### Cryptographic Services (Keyed DI)

Two crypto services exist for internal vs external encryption:

```csharp
// Internal (default) - for DB passwords, connection strings
ICryptoGraphicService internalCrypto

// External (keyed) - for client-submitted encrypted data
[FromKeyedServices("external")] ICryptoGraphicService externalCrypto
```

### Parallel SQL Execution (Multi-Server)

For executing queries across 70+ remote databases:

```csharp

IParallelSqlExecutor<DataTable>  // For SELECT queries
IParallelSqlExecutor<int>        // For INSERT/UPDATE/DELETE commands
```

Uses `CircuitBreakerService` to handle unavailable servers gracefully. Configuration in `appsettings.json` under `Resilience`.

### Response Pattern

All endpoints return standardized responses:

```csharp
return Ok(ApiResponseBuilder.Success(data, "Message"));
return BadRequest(ApiResponseBuilder.Error<T>("Error", statusCode, null, traceId));
return Unauthorized(ApiResponseBuilder.Unauthorized<T>("Message", traceId));
```

---

## Guía de Normas y Buenas Prácticas para clases en C# (.NET)

Convenciones de desarrollo para el proyecto **SecureAPIRestWithJwtTokens**.

### 1. Estructura y Organización del Código

- **Separación de responsabilidades:** Cada clase debe tener una única responsabilidad clara (principio SRP).
- **Nombres significativos:** Usa nombres descriptivos para clases, métodos y variables. Evita abreviaturas ambiguas.
- **Organización en carpetas:** Agrupa clases por funcionalidad o dominio en carpetas separadas (Ej: `Repository/`, `Services/`, `Controllers/`).
- **Archivo por clase:** Cada clase debe estar en su propio archivo, el nombre del archivo debe coincidir con el nombre de la clase.

### 2. Convenciones de Nomenclatura

- **Clases y métodos públicos:** PascalCase (Ej: `InventoryAgent`, `ProcessOrder()`).
- **Variables, campos privados y parámetros:** camelCase (Ej: `orderId`, `userRepository`).
- **Interfaces:** Prefijo `I` (Ej: `IOrderAgent`).
- **Constantes:** UPPER_SNAKE_CASE (Ej: `DEFAULT_TIMEOUT`).

### 3. Diseño de Clases y Métodos

- **Inyección de dependencias:** Utiliza constructor injection para dependencias. Evita instanciar dependencias internas.
- **Métodos cortos:** Los métodos deben ser breves, claros y realizar una sola tarea.
- **Accesibilidad:** Expón solo lo necesario. Mantén los campos y métodos privados a menos que deban ser públicos.
- **Inmutabilidad donde sea posible:** Prefiere objetos inmutables para entidades simples.
- **Utiliza constructor principal:** Usa constructor principal
- **Solo usings utilizados:** No incluir usings que no se usen en la clase

### 4. Manejo de Excepciones

- **Uso de excepciones específicas:** Lanza y captura excepciones concretas (Ej: `ArgumentNullException`).
- **No ocultar errores:** No uses bloques `catch` vacíos ni suprimas errores silenciosamente.
- **Registro de errores:** Utiliza un sistema de logging (Ej: `ILogger`) para registrar excepciones relevantes.

## 5. Documentación y Comentarios

- **Documenta las clases públicas y sus métodos con XML comments:**

  ```csharp
  /// <summary>
  /// Procesa la orden y actualiza el inventario.
  /// </summary>
  /// <param ame="pais">Identificador de País</param>
  /// <remarks>
  /// Comentarios de la clase o metodo 
  /// </remarks>
  public void ProcessOrder(Order order) { ... }
  ```

- **Explicaciones necesarias:** Solo comenta donde el código no sea autoexplicativo.

## 6. Pruebas y Validación

- **Cobertura de pruebas:** Todo clase debe tener pruebas unitarias asociadas.
- **Mocking de dependencias:** Utiliza frameworks de mocking para pruebas de clases con dependencias externas.

## 7. Seguridad

- **Validación de entrada:** Valida todos los parámetros públicos y datos de entrada.
- **No expongas información sensible:** Evita escribir datos sensibles en logs.

## 9. Ejemplo de Clase

```csharp
using Microsoft.Extensions.Logging;

namespace Agents
{
    /// <summary>
    /// Agente encargado de procesar órdenes.
    /// </summary>
    public class OrderAgent(InventoryService inventoryService, ILogger<OrderAgent> logger) : IOrderAgent
    {
        private readonly IInventoryService _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        private readonly ILogger<OrderAgent> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public void ProcessOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            try
            {
                inventoryService.UpdateInventory(order);
                logger.LogInformation("Orden procesada correctamente.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al procesar la orden.");
                throw;
            }
        }
    }
}
```

---

## 9. Referencias

- [Microsoft C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Clean Code in C#](https://github.com/torokmark/clean-code-csharp)
- [SOLID Principles](https://deviq.com/principles/solid)

---

**Cumpliendo estas normas se facilita la mantenibilidad, escalabilidad y calidad del código en el proyecto.**
