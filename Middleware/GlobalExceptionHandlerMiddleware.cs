using SecureAPIRestWithJwtTokens.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace SecureAPIRestWithJwtTokens.Middleware;

public class GlobalExceptionHandlerMiddleware(
    RequestDelegate next,
    ILogger<GlobalExceptionHandlerMiddleware> logger,
    IServiceProvider serviceProvider)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger = logger;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    private readonly JsonSerializerOptions jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var traceId = context.TraceIdentifier;

        // **DESACTIVAR CACHE EN ERRORES**
        context.Response.Headers.CacheControl = "no-cache, no-store, must-revalidate";
        context.Response.Headers.Pragma = "no-cache";
        context.Response.Headers.Expires = "0";

        // Get the exception handler service from DI
        using var scope = _serviceProvider.CreateScope();
        var exceptionHandlerService = scope.ServiceProvider.GetRequiredService<IExceptionHandlerService>();
        
        // Log the exception
        exceptionHandlerService.LogException(exception, traceId, context);

        // Create response
        var response = exceptionHandlerService.CreateErrorResponse(exception, traceId);

        // Set response
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.Status;

        var jsonResponse = JsonSerializer.Serialize(response, jsonOptions);
        await context.Response.WriteAsync(jsonResponse);
    }

    private static HttpStatusCode GetStatusCode(Exception exception) =>
        exception switch
        {
            SimpleNotFoundException => HttpStatusCode.NotFound,
            FechaInvalidaException => HttpStatusCode.BadRequest,
            ValidationException => HttpStatusCode.UnprocessableEntity,
            ArgumentException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };
}
