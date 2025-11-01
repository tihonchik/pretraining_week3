namespace task4;

public interface IBookService
{
    public Task<List<BookModel>> GetAllBooksAsync(BookModelFilter filter);

    public Task<BookModel> GetBookByIdAsync(int Id);

    public Task<BookModel> InsertBookAsync(BookModel book);

    public Task UpdateBookAsync(BookModel book);

    public Task DeleteBookAsync(int Id);

}