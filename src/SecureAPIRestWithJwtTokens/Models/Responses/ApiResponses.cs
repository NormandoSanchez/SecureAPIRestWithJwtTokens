namespace SecureAPIRestWithJwtTokens.Models.Responses;

/// <summary>
/// Respuesta unificada de la API que maneja tanto éxitos como errores
/// </summary>
/// <typeparam name="T">Tipo de dato que contiene el resultado</typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// Código de estado HTTP
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Indica si la operación fue exitosa
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Mensaje descriptivo de la operación
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Datos del resultado (null en caso de error)
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Lista de errores (null en caso de éxito)
    /// </summary>
    public List<ApiError>? Errors { get; set; }

    /// <summary>
    /// Metadatos adicionales de la respuesta
    /// </summary>
    public ResponseMetadata? Metadata { get; set; }

    /// <summary>
    /// Timestamp de la respuesta
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// TraceId para seguimiento distribuido
    /// </summary>
    public string? TraceId { get; set; }
}

/// <summary>
/// Información de error específico
/// </summary>
public class ApiError
{
    /// <summary>
    /// Código de error
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del error
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Campo relacionado con el error (para errores de validación)
    /// </summary>
    public string? Field { get; set; }

    /// <summary>
    /// Detalles adicionales del error
    /// </summary>
    public Dictionary<string, object>? Details { get; set; }
}

/// <summary>
/// Metadatos adicionales de la respuesta
/// </summary>
public class ResponseMetadata
{
    /// <summary>
    /// Información de paginación
    /// </summary>
    public PaginationInfo? Pagination { get; set; }

    /// <summary>
    /// Tiempo de ejecución en milisegundos
    /// </summary>
    public long? ExecutionTimeMs { get; set; }

    /// <summary>
    /// Información adicional contextual
    /// </summary>
    public Dictionary<string, object>? AdditionalInfo { get; set; }
}

/// <summary>
/// Información de paginación
/// </summary>
public class PaginationInfo
{
    /// <summary>
    /// Página actual
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Tamaño de página
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Total de registros
    /// </summary>
    public int TotalItems { get; set; }

    /// <summary>
    /// Total de páginas
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// Indica si hay página anterior
    /// </summary>
    public bool HasPreviousPage => CurrentPage > 1;

    /// <summary>
    /// Indica si hay página siguiente
    /// </summary>
    public bool HasNextPage => CurrentPage < TotalPages;
}

/// <summary>
/// Builder para construir respuestas API unificadas de manera fluida
/// </summary>
public static class ApiResponseBuilder
{
    /// <summary>
    /// Crea una respuesta exitosa con datos
    /// </summary>
    /// <typeparam name="T">Tipo de datos a retornar</typeparam>
    /// <param name="data">Datos a incluir en la respuesta</param>
    /// <param name="message">Mensaje descriptivo</param>
    /// <param name="statusCode">Código de estado HTTP</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta exitosa tipada</returns>
    public static ApiResponse<T> Success<T>(
        T data,
        string message = "Operación completada exitosamente",
        int statusCode = StatusCodes.Status200OK,
        string? traceId = null)
    {
        return new ApiResponse<T>
        {
            Status = statusCode,
            Success = true,
            Message = message,
            Data = data,
            Errors = null,
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Crea una respuesta de error
    /// </summary>
    /// <typeparam name="T">Tipo de datos esperado</typeparam>
    /// <param name="message">Mensaje de error</param>
    /// <param name="statusCode">Código de estado HTTP</param>
    /// <param name="errors">Lista de errores específicos</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta de error tipada</returns>
    public static ApiResponse<T> Error<T>(
        string message,
        int statusCode,
        List<ApiError>? errors = null,
        string? traceId = null)
    {
        return new ApiResponse<T>
        {
            Status = statusCode,
            Success = false,
            Message = message,
            Data = default(T),
            Errors = errors,
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Crea una respuesta de error de validación
    /// </summary>
    /// <typeparam name="T">Tipo de datos esperado</typeparam>
    /// <param name="message">Mensaje de error</param>
    /// <param name="validationErrors">Errores de validación por campo</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta de error de validación tipada</returns>
    public static ApiResponse<T> ValidationError<T>(
        string message = "Error de validación",
        Dictionary<string, string[]>? validationErrors = null,
        string? traceId = null)
    {
        var errors = validationErrors?.SelectMany(kvp =>
            kvp.Value.Select(error => new ApiError
            {
                Code = "VALIDATION_ERROR",
                Description = error,
                Field = kvp.Key
            })).ToList();

        return new ApiResponse<T>
        {
            Status = StatusCodes.Status400BadRequest,
            Success = false,
            Message = message,
            Data = default(T),
            Errors = errors,
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Crea una respuesta exitosa con paginación
    /// </summary>
    /// <typeparam name="T">Tipo de datos a retornar</typeparam>
    /// <param name="data">Datos a incluir en la respuesta</param>
    /// <param name="currentPage">Página actual</param>
    /// <param name="pageSize">Tamaño de página</param>
    /// <param name="totalItems">Total de elementos</param>
    /// <param name="message">Mensaje descriptivo</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta exitosa con paginación</returns>
    public static ApiResponse<T> SuccessWithPagination<T>(
        T data,
        int currentPage,
        int pageSize,
        int totalItems,
        string message = "Operación completada exitosamente",
        string? traceId = null)
    {
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        return new ApiResponse<T>
        {
            Status = StatusCodes.Status200OK,
            Success = true,
            Message = message,
            Data = data,
            Errors = null,
            Metadata = new ResponseMetadata
            {
                Pagination = new PaginationInfo
                {
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalItems = totalItems,
                    TotalPages = totalPages
                }
            },
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Crea una respuesta de recurso no encontrado
    /// </summary>
    /// <typeparam name="T">Tipo de datos esperado</typeparam>
    /// <param name="message">Mensaje de error</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta de recurso no encontrado</returns>
    public static ApiResponse<T> NotFound<T>(
        string message = "Recurso no encontrado",
        string? traceId = null)
    {
        return Error<T>(
            message,
            StatusCodes.Status404NotFound,
            new List<ApiError>
            {
                new ApiError
                {
                    Code = "RESOURCE_NOT_FOUND",
                    Description = message
                }
            },
            traceId);
    }

    /// <summary>
    /// Crea una respuesta exitosa sin contenido (204)
    /// </summary>
    /// <param name="message">Mensaje descriptivo</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta sin contenido</returns>
    public static ApiResponse<object> NoContent(
        string message = "Operación completada exitosamente",
        string? traceId = null)
    {
        return new ApiResponse<object>
        {
            Status = StatusCodes.Status204NoContent,
            Success = true,
            Message = message,
            Data = null,
            Errors = null,
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Crea una respuesta de creación exitosa (201)
    /// </summary>
    /// <typeparam name="T">Tipo de datos creado</typeparam>
    /// <param name="data">Datos del recurso creado</param>
    /// <param name="message">Mensaje descriptivo</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta de recurso creado</returns>
    public static ApiResponse<T> Created<T>(
        T data,
        string message = "Recurso creado exitosamente",
        string? traceId = null)
    {
        return new ApiResponse<T>
        {
            Status = StatusCodes.Status201Created,
            Success = true,
            Message = message,
            Data = data,
            Errors = null,
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Crea una respuesta de error interno del servidor
    /// </summary>
    /// <typeparam name="T">Tipo de datos esperado</typeparam>
    /// <param name="message">Mensaje de error</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta de error interno</returns>
    public static ApiResponse<T> InternalServerError<T>(
        string message = "Error interno del servidor",
        string? traceId = null)
    {
        return Error<T>(
            message,
            StatusCodes.Status500InternalServerError,
            new List<ApiError>
            {
                new ApiError
                {
                    Code = "INTERNAL_SERVER_ERROR",
                    Description = message
                }
            },
            traceId);
    }

    /// <summary>
    /// Crea una respuesta de acceso no autorizado
    /// </summary>
    /// <typeparam name="T">Tipo de datos esperado</typeparam>
    /// <param name="message">Mensaje de error</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta de acceso no autorizado</returns>
    public static ApiResponse<T> Unauthorized<T>(
        string message = "Acceso no autorizado",
        string? traceId = null)
    {
        return Error<T>(
            message,
            StatusCodes.Status401Unauthorized,
            new List<ApiError>
            {
                new ApiError
                {
                    Code = "UNAUTHORIZED",
                    Description = message
                }
            },
            traceId);
    }

    /// <summary>
    /// Crea una respuesta de acceso prohibido
    /// </summary>
    /// <typeparam name="T">Tipo de datos esperado</typeparam>
    /// <param name="message">Mensaje de error</param>
    /// <param name="traceId">ID de seguimiento</param>
    /// <returns>Respuesta de acceso prohibido</returns>
    public static ApiResponse<T> Forbidden<T>(
        string message = "Acceso prohibido",
        string? traceId = null)
    {
        return Error<T>(
            message,
            StatusCodes.Status403Forbidden,
            new List<ApiError>
            {
                new ApiError
                {
                    Code = "FORBIDDEN",
                    Description = message
                }
            },
            traceId);
    }
}