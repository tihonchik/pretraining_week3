namespace task4;

public interface IAuthorRepository
{
    public Task<List<AuthorEntity>> GetAllAuthorsAsync(AuthorEntityFilter filter);

    public Task<AuthorEntity?> GetAuthorByIdAsync(int Id);

    public Task<AuthorEntity> InsertAuthorAsync(AuthorEntity author);

    public Task UpdateAuthorAsync(AuthorEntity existingAuthor, AuthorEntity updatedAuthor);

    public Task DeleteAuthorAsync(AuthorEntity author);
}