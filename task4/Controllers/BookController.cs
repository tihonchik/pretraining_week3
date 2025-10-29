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
        try
        {
            List<Book> books = await _bookService.GetAllBooksAsync(filter);
            List<BookCreatedDto> booksCreatedDto = _mapper.Map<List<BookCreatedDto>>(books);
            return Ok(booksCreatedDto);
        }
        catch
        {
            return NotFound("Books not found");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookCreatedDto>> GetBookByIdAsync(int id)
    {
        try
        {
            Book book = await _bookService.GetBookByIdAsync(id);
            BookCreatedDto bookCreated = _mapper.Map<BookCreatedDto>(book);
            return Ok(bookCreated);
        }
        catch
        {
            return NotFound("Book not found");
        }
    }


    [HttpPost]
    public async Task<ActionResult<BookCreatedDto>> InsertBookAsync([FromBody] BookCreatingDto bookCreatingDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Book book = _mapper.Map<Book>(bookCreatingDto);
            book = await _bookService.InsertBookAsync(book);
            BookCreatedDto bookCreatedDto = _mapper.Map<BookCreatedDto>(book);
            return Created(nameof(GetBookByIdAsync), bookCreatedDto);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBookById(int id)
    {
        try
        {
            await _bookService.DeleteBookAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBookByIdAsync([FromBody] BookCreatedDto updatedCreatedBookDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Book book = _mapper.Map<Book>(updatedCreatedBookDto);
            await _bookService.UpdateBookAsync(book);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
