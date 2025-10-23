using Microsoft.AspNetCore.Mvc;

namespace task4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public ActionResult<List<Author>> GetAllAuthors()
    {
        try
        {
            return Ok(_authorService.GetAllAuthors());
        }
        catch
        {
            return NotFound("Authors not found");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Author> GetAuthorById(int id)
    {
        try
        {
            return Ok(_authorService.GetAuthorById(id));
        }
        catch
        {
            return NotFound("Author not found");
        }
    }


    [HttpPost]
    public ActionResult InsertAuthor([FromBody] Author author)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _authorService.InsertAuthor(author);
            return Created();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAuthorById(int id)
    {
        try
        {
            _authorService.DeleteAuthor(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public ActionResult UpdateAuthorById([FromBody] Author updatedAuthor)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _authorService.UpdateAuthor(updatedAuthor);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
