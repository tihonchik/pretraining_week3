
using System.Threading.Tasks;

namespace task4;

public class BookService(IBookRepository bookRepository) : IBookService
{
    private IBookRepository _bookRepository => bookRepository;

    public async Task DeleteBookAsync(int Id)
    {
        Book? book = await _bookRepository.GetBookByIdAsync(Id);
        if (book is null) throw new KeyNotFoundException();
        await _bookRepository.DeleteBookAsync(book);
    }

    public async Task<List<Book>> GetAllBooksAsync(BookFilterDto filter)
    {
        return await _bookRepository.GetAllBooksAsync(filter);
    }

    public async Task<Book> GetBookByIdAsync(int Id)
    {
        Book? book = await _bookRepository.GetBookByIdAsync(Id);
        if (book is null) throw new KeyNotFoundException();

        return book;
    }

    public async Task<Book> InsertBookAsync(Book book)
    {
        book = await _bookRepository.InsertBookAsync(book);
        return book;
    }

    public async Task UpdateBookAsync(Book updatedBook)
    {
        Book? existingBook = await _bookRepository.GetBookByIdAsync(updatedBook.Id);
        if (existingBook is null) throw new Exception();
        await _bookRepository.UpdateBookAsync(existingBook, updatedBook);
    }
}