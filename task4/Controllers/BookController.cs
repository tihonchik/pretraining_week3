using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace task4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<List<BookCreatedDto>> GetAllBooks()
    {
        try
        {
            List<Book> books = _bookService.GetAllBooks();
            List<BookCreatedDto> booksCreatedDto = _mapper.Map<List<BookCreatedDto>>(books);
            return Ok(booksCreatedDto);
        }
        catch
        {
            return NotFound("Books not found");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<BookCreatedDto> GetBookById(int id)
    {
        try
        {
            Book book = _bookService.GetBookById(id);
            BookCreatedDto bookCreated = _mapper.Map<BookCreatedDto>(book);
            return Ok(bookCreated);
        }
        catch
        {
            return NotFound("Book not found");
        }
    }


    [HttpPost]
    public ActionResult<BookCreatedDto> InsertBook([FromBody] BookCreatingDto bookCreatingDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Book book = _mapper.Map<Book>(bookCreatingDto);
            book = _bookService.InsertBook(book);
            BookCreatedDto bookCreatedDto = _mapper.Map<BookCreatedDto>(book);
            return Created(nameof(GetBookById), bookCreatedDto);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteBookById(int id)
    {
        try
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public ActionResult UpdateBookById([FromBody] BookCreatedDto updatedCreatedBookDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Book book = _mapper.Map<Book>(updatedCreatedBookDto);
            _bookService.UpdateBook(book);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
