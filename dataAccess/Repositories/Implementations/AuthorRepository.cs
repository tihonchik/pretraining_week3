
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace task4;

public class AuthorRepository(LibraryContext context) : IAuthorRepository
{
    public async Task DeleteAuthorAsync(AuthorEntity author)
    {
        context.Authors.Remove(author);
        await context.SaveChangesAsync();
    }

    public async Task<List<AuthorEntity>> GetAllAuthorsAsync(AuthorEntityFilter filter)
    {
        IQueryable<AuthorEntity> query = context.Authors;

        if (filter.MinCountBook.HasValue)
            query = query.Where(x => x.Books.Count == filter.MinCountBook);
        if (!String.IsNullOrWhiteSpace(filter.NameStartWith))
            query = query.Where(x => x.Name.StartsWith(filter.NameStartWith));

        return await query.ToListAsync();
    }

    public async Task<AuthorEntity?> GetAuthorByIdAsync(int Id)
    {
        return await context.Authors.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<AuthorEntity> InsertAuthorAsync(AuthorEntity author)
    {
        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task UpdateAuthorAsync(AuthorEntity existingAuthor, AuthorEntity updatedAuthor)
    {
        context.Authors.Entry(existingAuthor).CurrentValues.SetValues(updatedAuthor);
        await context.SaveChangesAsync();
    }
}