# Guía de Normas y Buenas Prácticas para clases en C# (.NET)

Este documento presenta las normas y buenas prácticas recomendadas para desarrollar por ejemplo, clases de servicios,  controladores, etc. en el proyecto **SecureAPIRestWithJwtTokens**, empleando C# y el ecosistema .NET. Aplica las convenciones modernas y más aceptadas en la comunidad profesional.

---

## 1. Estructura y Organización del Código

- **Separación de responsabilidades:** Cada clase debe tener una única responsabilidad clara (principio SRP).
- **Nombres significativos:** Usa nombres descriptivos para clases, métodos y variables. Evita abreviaturas ambiguas.
- **Organización en carpetas:** Agrupa clases por funcionalidad o dominio en carpetas separadas (Ej: `Repository/`, `Services/`, `Controllers/`).
- **Archivo por clase:** Cada clase debe estar en su propio archivo, el nombre del archivo debe coincidir con el nombre de la clase.

## 2. Convenciones de Nomenclatura

- **Clases y métodos públicos:** PascalCase (Ej: `InventoryAgent`, `ProcessOrder()`).
- **Variables, campos privados y parámetros:** camelCase (Ej: `orderId`, `userRepository`).
- **Interfaces:** Prefijo `I` (Ej: `IOrderAgent`).
- **Constantes:** UPPER_SNAKE_CASE (Ej: `DEFAULT_TIMEOUT`).

## 3. Diseño de Clases y Métodos

- **Inyección de dependencias:** Utiliza constructor injection para dependencias. Evita instanciar dependencias internas.
- **Métodos cortos:** Los métodos deben ser breves, claros y realizar una sola tarea.
- **Accesibilidad:** Expón solo lo necesario. Mantén los campos y métodos privados a menos que deban ser públicos.
- **Inmutabilidad donde sea posible:** Prefiere objetos inmutables para entidades simples.
- **Utiliza constructor principal:** Usa constructor principal 
- **Solo usings utilizados:** No incluir usings que no se usen en la clase 

## 4. Manejo de Excepciones

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