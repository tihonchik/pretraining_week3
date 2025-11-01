using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace task4;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
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

        logger.LogError(exMessage);

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