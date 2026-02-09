using SecureAPIRestWithJwtTokens.Exceptions;
using SecureAPIRestWithJwtTokens.Models.Responses;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SecureAPIRestWithJwtTokens.Middleware;

public interface IExceptionHandlerService
{
    void LogException(Exception exception, string traceId, HttpContext context);
    ApiResponse<object> CreateErrorResponse(Exception exception, string traceId);
}

public class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger) : IExceptionHandlerService
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger = logger;

    public void LogException(Exception exception, string traceId, HttpContext context)
    {
        var logData = new
        {
            TraceId = traceId,
            ExceptionType = exception.GetType().Name,
            context.Request.Path,
            context.Request.Method,
            QueryString = context.Request.QueryString.ToString(),
            UserAgent = context.Request.Headers.UserAgent.ToString()
        };

        switch (exception)
        {
            case ApiBusinessException:
                _logger.LogWarning(exception, "Error de regla de negocio: {LogData}", logData);
                break;
            case ValidationException:
                _logger.LogWarning(exception, "Error de validación: {LogData}", logData);
                break;
            case ArgumentException:
                _logger.LogWarning(exception, "Error de argumento: {LogData}", logData);
                break;
            default:
                _logger.LogError(exception, "Error interno del servidor: {LogData}", logData);
                break;
        }
    }

    public ApiResponse<object> CreateErrorResponse(Exception exception, string traceId)
    {
        return exception switch
        {
            SimpleNotFoundException ex => ApiResponseBuilder.NotFound<object>(
                $"{ex.EntidadName} no encontrado",
                traceId),
            
            ValidationException ex => ApiResponseBuilder.Error<object>(
                "Error de validación",
                (int)HttpStatusCode.UnprocessableEntity,
                new List<ApiError> { new() { Code = "VALIDATION_ERROR", Description = ex.Message, Field = "Parámetros" } },
                traceId),
            
            ArgumentException ex => ApiResponseBuilder.Error<object>(
                "Argumento inválido",
                (int)HttpStatusCode.BadRequest,
                new List<ApiError> { new() { Code = "INVALID_ARGUMENT", Description = ex.Message } },
                traceId),
            
            _ => ApiResponseBuilder.InternalServerError<object>(
                "Ha ocurrido un error inesperado. Por favor contacte al administrador.",
                traceId)
        };
    }

}