namespace task4;

public interface IBookRepository
{
    public Task<List<Book>> GetAllBooksAsync(BookFilterDto filter);

    public Task<Book?> GetBookByIdAsync(int Id);

    public Task<Book> InsertBookAsync(Book book);

    public Task UpdateBookAsync(Book existingBook, Book updatedBook);

    public Task DeleteBookAsync(Book book);
}