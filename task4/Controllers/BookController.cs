using System.Threading.Tasks;
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
    public async Task<ActionResult<List<BookCreatedDto>>> GetAllBooksAsync([FromQuery] BookFilterDto filter)
    {
        List<Book> books = await _bookService.GetAllBooksAsync(filter);
        List<BookCreatedDto> booksCreatedDto = _mapper.Map<List<BookCreatedDto>>(books);
        return Ok(booksCreatedDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookCreatedDto>> GetBookByIdAsync(int id)
    {
        Book book = await _bookService.GetBookByIdAsync(id);
        BookCreatedDto bookCreated = _mapper.Map<BookCreatedDto>(book);
        return Ok(bookCreated);
    }


    [HttpPost]
    public async Task<ActionResult<BookCreatedDto>> InsertBookAsync([FromBody] BookCreatingDto bookCreatingDto)
    {
        Book book = _mapper.Map<Book>(bookCreatingDto);
        book = await _bookService.InsertBookAsync(book);
        BookCreatedDto bookCreatedDto = _mapper.Map<BookCreatedDto>(book);
        return Created(nameof(GetBookByIdAsync), bookCreatedDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBookById(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBookByIdAsync([FromBody] BookCreatedDto updatedCreatedBookDto)
    {
        Book book = _mapper.Map<Book>(updatedCreatedBookDto);
        await _bookService.UpdateBookAsync(book);
        return Ok();
    }
}
