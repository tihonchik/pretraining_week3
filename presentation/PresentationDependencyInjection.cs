using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace task4;

public static class PresentationDependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingPresentationProfile));

        return services;
    }

    public static WebApplication AddPresentation(this WebApplication app)
    {

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}