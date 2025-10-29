
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace task4;

class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task DeleteBookAsync(int Id)
    {
        try
        {
            Book? existingBook = await _bookRepository.GetBookByIdAsync(Id);
            if (existingBook is null) throw new Exception();

            await _bookRepository.DeleteBookAsync(existingBook);
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Book>> GetAllBooksAsync(BookFilterDto filter)
    {
        try
        {
            return await _bookRepository.GetAllBooksAsync(filter);
        }
        catch
        {
            throw;
        }
    }

    public async Task<Book> GetBookByIdAsync(int Id)
    {
        try
        {
            Book? book = await _bookRepository.GetBookByIdAsync(Id);
            if (book is null) throw new Exception();

            return book;
        }
        catch
        {
            throw;
        }
    }

    public Task<List<Book>> GetBooksPublishedAfterSomeYearAsync(int year)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> InsertBookAsync(Book book)
    {
        try
        {
            book = await _bookRepository.InsertBookAsync(book);
            return book;
        }
        catch
        {
            throw;
        }
    }

    public async Task UpdateBookAsync(Book updatedBook)
    {
        try
        {
            Book? existingBook = await _bookRepository.GetBookByIdAsync(updatedBook.Id);
            if (existingBook is null) throw new Exception();
            await _bookRepository.UpdateBookAsync(existingBook, updatedBook);
        }
        catch
        {
            throw;
        }
    }
}