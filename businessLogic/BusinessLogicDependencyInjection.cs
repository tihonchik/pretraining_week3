using Microsoft.Extensions.DependencyInjection;

namespace task4;

public static class BusinessLogicDependencyInjection
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {

        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();

        return services;
    }
}