
using System.Threading.Tasks;

namespace task4;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public async Task DeleteBookAsync(int Id)
    {
        BookEntity? book = await bookRepository.GetBookByIdAsync(Id);
        if (book is null) throw new KeyNotFoundException();
        await bookRepository.DeleteBookAsync(book);
    }

    public async Task<List<BookEntity>> GetAllBooksAsync(BookEntityFilter filter)
    {
        return await bookRepository.GetAllBooksAsync(filter);
    }

    public async Task<BookEntity> GetBookByIdAsync(int Id)
    {
        BookEntity? book = await bookRepository.GetBookByIdAsync(Id);
        if (book is null) throw new KeyNotFoundException();

        return book;
    }

    public async Task<BookEntity> InsertBookAsync(BookEntity book)
    {
        book = await bookRepository.InsertBookAsync(book);
        return book;
    }

    public async Task UpdateBookAsync(BookEntity updatedBook)
    {
        BookEntity? existingBook = await bookRepository.GetBookByIdAsync(updatedBook.Id);
        if (existingBook is null) throw new Exception();
        await bookRepository.UpdateBookAsync(existingBook, updatedBook);
    }
}