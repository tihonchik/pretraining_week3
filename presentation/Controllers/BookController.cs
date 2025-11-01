using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace task4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService, IMapper mapper) : ControllerBase
{
    private IBookService _bookService => bookService;
    private IMapper _mapper => mapper;

    [HttpGet]
    public async Task<ActionResult<List<BookCreatedDto>>> GetAllBooksAsync([FromQuery] BookFilterDto filterDto)
    {
        BookModelFilter filterModel = _mapper.Map<BookModelFilter>(filterDto);
        List<BookModel> booksModel = await _bookService.GetAllBooksAsync(filterModel);
        List<BookCreatedDto> booksCreatedDto = _mapper.Map<List<BookCreatedDto>>(booksModel);
        return Ok(booksCreatedDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookCreatedDto>> GetBookByIdAsync(int id)
    {
        BookModel book = await _bookService.GetBookByIdAsync(id);
        BookCreatedDto bookCreated = _mapper.Map<BookCreatedDto>(book);
        return Ok(bookCreated);
    }


    [HttpPost]
    public async Task<ActionResult<BookCreatedDto>> InsertBookAsync([FromBody] BookCreatingDto bookCreatingDto)
    {
        BookModel bookModel = _mapper.Map<BookModel>(bookCreatingDto);
        bookModel = await _bookService.InsertBookAsync(bookModel);
        BookCreatedDto bookCreatedDto = _mapper.Map<BookCreatedDto>(bookModel);
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
        BookModel bookModel = _mapper.Map<BookModel>(updatedCreatedBookDto);
        await _bookService.UpdateBookAsync(bookModel);
        return Ok();
    }
}
