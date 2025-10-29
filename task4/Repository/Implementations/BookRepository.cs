
using SQLitePCL;

namespace task4;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public void DeleteBook(Book book)
    {
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    public List<Book> GetAllBooks()
    {
        return _context.Books.ToList();
    }

    public Book? GetBookById(int Id)
    {
        return _context.Books.FirstOrDefault(x => x.Id == Id);
    }

    public Book InsertBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return book;
    }

    public void UpdateBook(Book existingBook, Book updatedBook)
    {
        _context.Books.Entry(existingBook).CurrentValues.SetValues(updatedBook);
        _context.SaveChanges();
    }
}