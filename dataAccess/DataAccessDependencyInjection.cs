using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace task4;

public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<LibraryContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}