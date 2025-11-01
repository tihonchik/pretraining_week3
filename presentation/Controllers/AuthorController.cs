using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace task4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<AuthorCreatedDto>>> GetAllAuthors([FromQuery] AuthorFilterDto filterDto)
    {
        AuthorEntityFilter filter = mapper.Map<AuthorEntityFilter>(filterDto);
        List<AuthorEntity> authors = await authorService.GetAllAuthorsAsync(filter);
        List<AuthorCreatedDto> authorsCreatedDto = mapper.Map<List<AuthorCreatedDto>>(authors);
        return Ok(authorsCreatedDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorCreatedDto>> GetAuthorByIdAsync(int id)
    {
        AuthorEntity author = await authorService.GetAuthorByIdAsync(id);
        AuthorCreatedDto authorCreatedDto = mapper.Map<AuthorCreatedDto>(author);
        return Ok(authorCreatedDto);
    }


    [HttpPost]
    public async Task<ActionResult<AuthorCreatedDto>> InsertAuthor([FromBody] AuthorCreatingDto authorCreatingDto)
    {
        AuthorEntity author = mapper.Map<AuthorEntity>(authorCreatingDto);
        author = await authorService.InsertAuthorAsync(author);
        AuthorCreatedDto authorCreatedDto = mapper.Map<AuthorCreatedDto>(author);
        return Created(nameof(GetAuthorByIdAsync), authorCreatedDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthorByIdAsync(int id)
    {
        await authorService.DeleteAuthorAsync(id);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAuthorByIdAsync([FromBody] AuthorCreatedDto updatedAuthorCreatedDto)
    {
        AuthorEntity updatedAuthor = mapper.Map<AuthorEntity>(updatedAuthorCreatedDto);
        await authorService.UpdateAuthorAsync(updatedAuthor);
        return Ok();
    }
}
