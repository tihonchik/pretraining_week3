using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace task4;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (KeyNotFoundException ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.NotFound, "Resource not found");
        }
        catch (DbUpdateException ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.BadRequest, "The specified entity does not exist");
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public async Task HandleExceptionAsync(HttpContext context, string exMessage, HttpStatusCode httpStatusCode, string message)
    {

        _logger.LogError(exMessage);

        HttpResponse response = context.Response;

        response.ContentType = "application/json";
        response.StatusCode = (int)httpStatusCode;

        ErrorDto errorDto = new()
        {
            Message = message,
            StatusCode = (int)httpStatusCode
        };

        await response.WriteAsJsonAsync(errorDto);
    }
}