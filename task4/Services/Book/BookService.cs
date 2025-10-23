
using Microsoft.AspNetCore.Http.HttpResults;

namespace task4;

class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public void DeleteBook(int Id)
    {
        try
        {
            Book? existingBook = _bookRepository.GetBookById(Id);
            if (existingBook is null) throw new Exception();

            _bookRepository.DeleteBook(existingBook);
        }
        catch
        {
            throw;
        }
    }

    public List<Book> GetAllBooks()
    {
        try
        {
            return _bookRepository.GetAllBooks();
        }
        catch
        {
            throw;
        }
    }

    public Book GetBookById(int Id)
    {
        try
        {
            Book? book = _bookRepository.GetBookById(Id);
            if (book is null) throw new Exception();

            return book;
        }
        catch
        {
            throw;
        }
    }

    public void InsertBook(Book book)
    {
        try
        {
            Book? existingBook = _bookRepository.GetBookById(book.Id);
            if (existingBook is not null) throw new Exception();
            _bookRepository.InsertBook(book);
        }
        catch
        {
            throw;
        }
    }

    public void UpdateBook(Book updatedBook)
    {
        try
        {
            Book? existingBook = _bookRepository.GetBookById(updatedBook.Id);
            if (existingBook is null) throw new Exception();
            _bookRepository.UpdateBook(updatedBook);
        }
        catch
        {
            throw;
        }
    }
}