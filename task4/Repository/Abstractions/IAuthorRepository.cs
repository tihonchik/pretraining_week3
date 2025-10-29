namespace task4;

public interface IAuthorRepository
{
    public Task<List<Author>> GetAllAuthorsAsync(AuthorFilterDto filter);

    public Task<Author?> GetAuthorByIdAsync(int Id);

    public Task<Author> InsertAuthorAsync(Author author);

    public Task UpdateAuthorAsync(Author existingAuthor, Author updatedAuthor);

    public Task DeleteAuthorAsync(Author author);
}