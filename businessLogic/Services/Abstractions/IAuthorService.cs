namespace task4;

public interface IAuthorService
{
    public Task<List<AuthorModel>> GetAllAuthorsAsync(AuthorModelFilter filter);

    public Task<AuthorModel> GetAuthorByIdAsync(int Id);

    public Task<AuthorModel> InsertAuthorAsync(AuthorModel author);

    public Task UpdateAuthorAsync(AuthorModel author);

    public Task DeleteAuthorAsync(int Id);

}