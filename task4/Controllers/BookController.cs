using Microsoft.AspNetCore.Mvc;

namespace task4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public ActionResult<List<Book>> GetAllBooks()
    {
        try
        {
            return Ok(_bookService.GetAllBooks());
        }
        catch
        {
            return NotFound("Books not found");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        try
        {
            return Ok(_bookService.GetBookById(id));
        }
        catch
        {
            return NotFound("Book not found");
        }
    }


    [HttpPost]
    public ActionResult InsertBook([FromBody] Book book)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _bookService.InsertBook(book);
            return Created();
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
    public ActionResult UpdateBookById([FromBody] Book updatedBook)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _bookService.UpdateBook(updatedBook);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
