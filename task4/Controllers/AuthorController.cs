using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        List<Author> authors = await _authorService.GetAllAuthorsAsync(filter);
        List<AuthorCreatedDto> authorsCreatedDto = _mapper.Map<List<AuthorCreatedDto>>(authors);
        return Ok(authorsCreatedDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorCreatedDto>> GetAuthorByIdAsync(int id)
    {
        Author author = await _authorService.GetAuthorByIdAsync(id);
        AuthorCreatedDto authorCreatedDto = _mapper.Map<AuthorCreatedDto>(author);
        return Ok(authorCreatedDto);
    }


    [HttpPost]
    public async Task<ActionResult<AuthorCreatedDto>> InsertAuthor([FromBody] AuthorCreatingDto authorCreatingDto)
    {
        Author author = _mapper.Map<Author>(authorCreatingDto);
        author = await _authorService.InsertAuthorAsync(author);
        AuthorCreatedDto authorCreatedDto = _mapper.Map<AuthorCreatedDto>(author);
        return Created(nameof(GetAuthorByIdAsync), authorCreatedDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthorByIdAsync(int id)
    {
        await _authorService.DeleteAuthorAsync(id);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAuthorByIdAsync([FromBody] AuthorCreatedDto updatedAuthorCreatedDto)
    {
        Author updatedAuthor = _mapper.Map<Author>(updatedAuthorCreatedDto);
        await _authorService.UpdateAuthorAsync(updatedAuthor);
        return Ok();
    }
}
