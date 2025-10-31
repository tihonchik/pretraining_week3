using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace task4;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private RequestDelegate _next => next;
    private ILogger<ExceptionHandlingMiddleware> _logger => logger;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            var (statusCode, message) = ex switch
            {
                KeyNotFoundException => (HttpStatusCode.NotFound, "Resource not found"),
                DbUpdateException => (HttpStatusCode.BadRequest, "The specified entity does not exist"),
                _ => (HttpStatusCode.InternalServerError, "Internal Server Error")
            };

            await HandleExceptionAsync(httpContext, ex.Message, statusCode, message);
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