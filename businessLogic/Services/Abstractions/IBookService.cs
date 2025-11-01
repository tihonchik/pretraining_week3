namespace task4;

public interface IBookService
{
    public Task<List<BookEntity>> GetAllBooksAsync(BookEntityFilter filter);

    public Task<BookEntity> GetBookByIdAsync(int Id);

    public Task<BookEntity> InsertBookAsync(BookEntity book);

    public Task UpdateBookAsync(BookEntity book);

    public Task DeleteBookAsync(int Id);

}