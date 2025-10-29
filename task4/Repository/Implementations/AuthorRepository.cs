
using Microsoft.EntityFrameworkCore;

namespace task4;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryContext _context;

    public AuthorRepository(LibraryContext context)
    {
        _context = context;
    }

    public void DeleteAuthor(Author author)
    {
        _context.Authors.Remove(author);
        _context.SaveChanges();
    }

    public List<Author> GetAllAuthors()
    {
        return _context.Authors.ToList();
    }

    public Author? GetAuthorById(int Id)
    {
        return _context.Authors.FirstOrDefault(x => x.Id == Id);
    }

    public Author InsertAuthor(Author author)
    {
        _context.Authors.Add(author);
        _context.SaveChanges();
        return author;
    }

    public void UpdateAuthor(Author existingAuthor, Author updatedAuthor)
    {
        _context.Authors.Entry(existingAuthor).CurrentValues.SetValues(updatedAuthor);
        _context.SaveChanges();
    }
}