using SecureAPIRestWithJwtTokens.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace SecureAPIRestWithJwtTokens.Middleware;

public class GlobalExceptionHandlerMiddleware(
    RequestDelegate next,
    IExceptionHandlerService exceptionHandlerService)
{
    private readonly RequestDelegate _next = next;
    private readonly IExceptionHandlerService _exceptionHandlerService = exceptionHandlerService;

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

        // Log the exception
        _exceptionHandlerService.LogException(exception, traceId, context);

        // Create response
        var response = _exceptionHandlerService.CreateErrorResponse(exception, traceId);

        // Set response
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.Status;

        var jsonResponse = JsonSerializer.Serialize(response, jsonOptions);
        await context.Response.WriteAsync(jsonResponse);
    }
}
