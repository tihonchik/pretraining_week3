namespace task4;

public interface IBookService
{
    public Task<List<Book>> GetAllBooksAsync(BookFilterDto filter);

    public Task<Book> GetBookByIdAsync(int Id);

    public Task<Book> InsertBookAsync(Book book);

    public Task UpdateBookAsync(Book book);

    public Task DeleteBookAsync(int Id);

    public Task<List<Book>> GetBooksPublishedAfterSomeYearAsync(int year);
}