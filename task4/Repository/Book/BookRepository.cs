
namespace task4;

public class BookRepository : IBookRepository
{
    static List<Book> books = new List<Book>();
    public void DeleteBook(Book book)
    {
        books.Remove(book);
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }

    public Book? GetBookById(int Id)
    {
        return books.FirstOrDefault(x => x.Id == Id);
    }

    public void InsertBook(Book book)
    {
        books.Add(book);
    }

    public void UpdateBook(Book book)
    {
        books = books.Select(x => x.Id == book.Id ? book : x).ToList();
    }
}