
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace task4;

public class BookRepository(LibraryContext context) : IBookRepository
{
    private LibraryContext _context => context;

    public async Task DeleteBookAsync(Book book)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAllBooksAsync(BookFilterDto filter)
    {
        IQueryable<Book> query = _context.Books;

        if (filter.PublishedAfterYear.HasValue)
            query = query.Where(x => x.PublishedYear > filter.PublishedAfterYear);

        return await query.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int Id)
    {
        return await _context.Books.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public Task<List<Book>> GetBooksPublishedAfterSomeYearAsync(int year)
    {
        return _context.Books.Where(x => x.PublishedYear > year).ToListAsync();
    }

    public async Task<Book> InsertBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task UpdateBookAsync(Book existingBook, Book updatedBook)
    {
        _context.Books.Entry(existingBook).CurrentValues.SetValues(updatedBook);
        await _context.SaveChangesAsync();
    }
}