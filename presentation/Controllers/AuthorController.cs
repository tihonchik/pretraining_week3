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
        AuthorModelFilter filterModel = mapper.Map<AuthorModelFilter>(filterDto);
        List<AuthorModel> authorsModel = await authorService.GetAllAuthorsAsync(filterModel);
        List<AuthorCreatedDto> authorsCreatedDto = mapper.Map<List<AuthorCreatedDto>>(authorsModel);
        return Ok(authorsCreatedDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorCreatedDto>> GetAuthorByIdAsync(int id)
    {
        AuthorModel authorModel = await authorService.GetAuthorByIdAsync(id);
        AuthorCreatedDto authorCreatedDto = mapper.Map<AuthorCreatedDto>(authorModel);
        return Ok(authorCreatedDto);
    }


    [HttpPost]
    public async Task<ActionResult<AuthorCreatedDto>> InsertAuthor([FromBody] AuthorCreatingDto authorCreatingDto)
    {
        AuthorModel authorModel = mapper.Map<AuthorModel>(authorCreatingDto);
        authorModel = await authorService.InsertAuthorAsync(authorModel);
        AuthorCreatedDto authorCreatedDto = mapper.Map<AuthorCreatedDto>(authorModel);
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
        AuthorModel updatedAuthorModel = mapper.Map<AuthorModel>(updatedAuthorCreatedDto);
        await authorService.UpdateAuthorAsync(updatedAuthorModel);
        return Ok();
    }
}
