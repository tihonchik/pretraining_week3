using Microsoft.EntityFrameworkCore;

namespace task4;

public class LibraryContext : DbContext
{

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public LibraryContext(DbContextOptions options) : base(options)
    {

    }
}