namespace task4;

public interface IBookService
{
    public List<Book> GetAllBooks();

    public Book GetBookById(int Id);

    public Book InsertBook(Book book);

    public void UpdateBook(Book book);

    public void DeleteBook(int Id);
}