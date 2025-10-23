namespace task4;

public interface IBookRepository
{
    public List<Book> GetAllBooks();

    public Book? GetBookById(int Id);

    public void InsertBook(Book book);

    public void UpdateBook(Book book);

    public void DeleteBook(Book book);
}