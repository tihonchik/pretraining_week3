
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace task4;

public class BookRepository(LibraryContext context) : IBookRepository
{
    public async Task DeleteBookAsync(BookEntity book)
    {
        context.Books.Remove(book);
        await context.SaveChangesAsync();
    }

    public async Task<List<BookEntity>> GetAllBooksAsync(BookEntityFilter filter)
    {
        IQueryable<BookEntity> query = context.Books;

        if (filter.PublishedAfterYear.HasValue)
            query = query.Where(x => x.PublishedYear > filter.PublishedAfterYear);

        return await query.ToListAsync();
    }

    public async Task<BookEntity?> GetBookByIdAsync(int Id)
    {
        return await context.Books.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public Task<List<BookEntity>> GetBooksPublishedAfterSomeYearAsync(int year)
    {
        return context.Books.Where(x => x.PublishedYear > year).ToListAsync();
    }

    public async Task<BookEntity> InsertBookAsync(BookEntity book)
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }

    public async Task UpdateBookAsync(BookEntity existingBook, BookEntity updatedBook)
    {
        context.Books.Entry(existingBook).CurrentValues.SetValues(updatedBook);
        await context.SaveChangesAsync();
    }
}