namespace task4;

public interface IAuthorService
{
    public Task<List<AuthorEntity>> GetAllAuthorsAsync(AuthorEntityFilter filter);

    public Task<AuthorEntity> GetAuthorByIdAsync(int Id);

    public Task<AuthorEntity> InsertAuthorAsync(AuthorEntity author);

    public Task UpdateAuthorAsync(AuthorEntity author);

    public Task DeleteAuthorAsync(int Id);

}