
using System.Threading.Tasks;
using AutoMapper;

namespace task4;

public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
{
    public async Task DeleteBookAsync(int Id)
    {
        BookEntity? book = await bookRepository.GetBookByIdAsync(Id);
        if (book is null) throw new KeyNotFoundException();
        await bookRepository.DeleteBookAsync(book);
    }

    public async Task<List<BookModel>> GetAllBooksAsync(BookModelFilter filterModel)
    {
        BookEntityFilter filterEntity = mapper.Map<BookEntityFilter>(filterModel);
        List<BookEntity> booksEntity = await bookRepository.GetAllBooksAsync(filterEntity);
        List<BookModel> booksModel = mapper.Map<List<BookModel>>(booksEntity);
        return booksModel;
    }

    public async Task<BookModel> GetBookByIdAsync(int Id)
    {
        BookEntity? bookEntity = await bookRepository.GetBookByIdAsync(Id);
        if (bookEntity is null) throw new KeyNotFoundException();
        BookModel bookModel = mapper.Map<BookModel>(bookEntity);
        return bookModel;
    }

    public async Task<BookModel> InsertBookAsync(BookModel bookModel)
    {
        BookEntity bookEntity = mapper.Map<BookEntity>(bookModel);
        bookEntity = await bookRepository.InsertBookAsync(bookEntity);
        bookModel = mapper.Map<BookModel>(bookEntity);
        return bookModel;
    }

    public async Task UpdateBookAsync(BookModel updatedBookModel)
    {
        BookEntity? existingBookEntity = await bookRepository.GetBookByIdAsync(updatedBookModel.Id);
        if (existingBookEntity is null) throw new Exception();
        BookEntity updatedBookEntity = mapper.Map<BookEntity>(updatedBookModel);
        await bookRepository.UpdateBookAsync(existingBookEntity, updatedBookEntity);
    }
}