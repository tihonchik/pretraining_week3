
using System.Threading.Tasks;
using AutoMapper;

namespace task4;

public class AuthorService(IAuthorRepository authorRepository, IMapper mapper) : IAuthorService
{
    public async Task DeleteAuthorAsync(int Id)
    {
        AuthorEntity? existingAuthor = await authorRepository.GetAuthorByIdAsync(Id);
        if (existingAuthor is null) throw new KeyNotFoundException();

        await authorRepository.DeleteAuthorAsync(existingAuthor);
    }

    public async Task<List<AuthorModel>> GetAllAuthorsAsync(AuthorModelFilter filterModel)
    {
        AuthorEntityFilter filterEntity = mapper.Map<AuthorEntityFilter>(filterModel);
        List<AuthorEntity> authorsEntity = await authorRepository.GetAllAuthorsAsync(filterEntity);
        List<AuthorModel> authorsModel = mapper.Map<List<AuthorModel>>(authorsEntity);
        return authorsModel;
    }

    public async Task<AuthorModel> GetAuthorByIdAsync(int Id)
    {
        AuthorEntity? authorEntity = await authorRepository.GetAuthorByIdAsync(Id);
        if (authorEntity is null) throw new KeyNotFoundException();
        AuthorModel authorModel = mapper.Map<AuthorModel>(authorEntity);

        return authorModel;
    }

    public async Task<AuthorModel> InsertAuthorAsync(AuthorModel authorModel)
    {
        AuthorEntity authorEntity = mapper.Map<AuthorEntity>(authorModel);
        authorEntity = await authorRepository.InsertAuthorAsync(authorEntity);
        authorModel = mapper.Map<AuthorModel>(authorEntity);
        return authorModel;
    }

    public async Task UpdateAuthorAsync(AuthorModel updatedAuthorModel)
    {
        AuthorEntity? existingAuthorEntity = await authorRepository.GetAuthorByIdAsync(updatedAuthorModel.Id);
        if (existingAuthorEntity is null) throw new KeyNotFoundException();
        AuthorEntity updatedAuthorEntity = mapper.Map<AuthorEntity>(updatedAuthorModel);
        await authorRepository.UpdateAuthorAsync(existingAuthorEntity, updatedAuthorEntity);
    }
}