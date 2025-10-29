namespace task4;

public interface IBookRepository
{
    public List<Book> GetAllBooks();

    public Book? GetBookById(int Id);

    public Book InsertBook(Book book);

    public void UpdateBook(Book existingBook, Book updatedBook);

    public void DeleteBook(Book book);
}