using System.Threading.Tasks;
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
    public async Task<ActionResult<List<AuthorCreatedDto>>> GetAllAuthors([FromQuery] AuthorFilterDto filter)
    {
        try
        {
            List<Author> authors = await _authorService.GetAllAuthorsAsync(filter);
            List<AuthorCreatedDto> authorsCreatedDto = _mapper.Map<List<AuthorCreatedDto>>(authors);
            return Ok(authorsCreatedDto);
        }
        catch
        {
            return NotFound("Authors not found");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorCreatedDto>> GetAuthorByIdAsync(int id)
    {
        try
        {
            Author author = await _authorService.GetAuthorByIdAsync(id);
            AuthorCreatedDto authorCreatedDto = _mapper.Map<AuthorCreatedDto>(author);
            return Ok(authorCreatedDto);
        }
        catch
        {
            return NotFound("Author not found");
        }
    }


    [HttpPost]
    public async Task<ActionResult<AuthorCreatedDto>> InsertAuthor([FromBody] AuthorCreatingDto authorCreatingDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Author author = _mapper.Map<Author>(authorCreatingDto);
            author = await _authorService.InsertAuthorAsync(author);
            AuthorCreatedDto authorCreatedDto = _mapper.Map<AuthorCreatedDto>(author);
            return Created(nameof(GetAuthorByIdAsync), authorCreatedDto);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthorByIdAsync(int id)
    {
        try
        {
            await _authorService.DeleteAuthorAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAuthorByIdAsync([FromBody] AuthorCreatedDto updatedAuthorCreatedDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Author updatedAuthor = _mapper.Map<Author>(updatedAuthorCreatedDto);
            await _authorService.UpdateAuthorAsync(updatedAuthor);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
