namespace task4;

public interface IAuthorService
{
    public Task<List<Author>> GetAllAuthorsAsync(AuthorFilterDto filter);

    public Task<Author> GetAuthorByIdAsync(int Id);

    public Task<Author> InsertAuthorAsync(Author author);

    public Task UpdateAuthorAsync(Author author);

    public Task DeleteAuthorAsync(int Id);

}