using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace task4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;
    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<List<AuthorCreatedDto>> GetAllAuthors()
    {
        try
        {
            List<Author> authors = _authorService.GetAllAuthors();
            List<AuthorCreatedDto> authorsCreatedDto = _mapper.Map<List<AuthorCreatedDto>>(authors);
            return Ok(authorsCreatedDto);
        }
        catch
        {
            return NotFound("Authors not found");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<AuthorCreatedDto> GetAuthorById(int id)
    {
        try
        {
            Author author = _authorService.GetAuthorById(id);
            AuthorCreatedDto authorCreatedDto = _mapper.Map<AuthorCreatedDto>(author);
            return Ok(authorCreatedDto);
        }
        catch
        {
            return NotFound("Author not found");
        }
    }


    [HttpPost]
    public ActionResult<AuthorCreatedDto> InsertAuthor([FromBody] AuthorCreatingDto authorCreatingDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Author author = _mapper.Map<Author>(authorCreatingDto);
            author = _authorService.InsertAuthor(author);
            AuthorCreatedDto authorCreatedDto = _mapper.Map<AuthorCreatedDto>(author);
            return Created(nameof(GetAuthorById), authorCreatedDto);
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
    public ActionResult UpdateAuthorById([FromBody] AuthorCreatedDto updatedAuthorCreatedDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Author updatedAuthor = _mapper.Map<Author>(updatedAuthorCreatedDto);
            _authorService.UpdateAuthor(updatedAuthor);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
