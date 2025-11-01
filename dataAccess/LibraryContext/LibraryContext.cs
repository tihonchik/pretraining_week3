using Microsoft.EntityFrameworkCore;

namespace task4;

public class LibraryContext : DbContext
{

    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }

    public LibraryContext(DbContextOptions options) : base(options)
    {

    }
}