
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace task4;

public class AuthorRepository(LibraryContext context) : IAuthorRepository
{
    private LibraryContext _context => context;

    public async Task DeleteAuthorAsync(Author author)
    {
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Author>> GetAllAuthorsAsync(AuthorFilterDto filter)
    {
        IQueryable<Author> query = _context.Authors;

        if (filter.MinCountBook.HasValue)
            query = query.Where(x => x.Books.Count == filter.MinCountBook);
        if (!String.IsNullOrWhiteSpace(filter.NameStartWith))
            query = query.Where(x => x.Name.StartsWith(filter.NameStartWith));

        return await query.ToListAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(int Id)
    {
        return await _context.Authors.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<Author> InsertAuthorAsync(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return author;
    }

    public async Task UpdateAuthorAsync(Author existingAuthor, Author updatedAuthor)
    {
        _context.Authors.Entry(existingAuthor).CurrentValues.SetValues(updatedAuthor);
        await _context.SaveChangesAsync();
    }
}