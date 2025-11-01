namespace task4;

public interface IBookRepository
{
    public Task<List<BookEntity>> GetAllBooksAsync(BookEntityFilter filter);

    public Task<BookEntity?> GetBookByIdAsync(int Id);

    public Task<BookEntity> InsertBookAsync(BookEntity book);

    public Task UpdateBookAsync(BookEntity existingBook, BookEntity updatedBook);

    public Task DeleteBookAsync(BookEntity book);
}