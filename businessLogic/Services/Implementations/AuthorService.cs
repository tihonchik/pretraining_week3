
using System.Threading.Tasks;

namespace task4;

public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
{
    public async Task DeleteAuthorAsync(int Id)
    {
        AuthorEntity? existingAuthor = await authorRepository.GetAuthorByIdAsync(Id);
        if (existingAuthor is null) throw new KeyNotFoundException();

        await authorRepository.DeleteAuthorAsync(existingAuthor);
    }

    public async Task<List<AuthorEntity>> GetAllAuthorsAsync(AuthorEntityFilter filter)
    {
        return await authorRepository.GetAllAuthorsAsync(filter);
    }

    public async Task<AuthorEntity> GetAuthorByIdAsync(int Id)
    {
        AuthorEntity? author = await authorRepository.GetAuthorByIdAsync(Id);
        if (author is null) throw new KeyNotFoundException();

        return author;
    }

    public async Task<AuthorEntity> InsertAuthorAsync(AuthorEntity author)
    {
        author = await authorRepository.InsertAuthorAsync(author);
        return author;
    }

    public async Task UpdateAuthorAsync(AuthorEntity updatedAuthor)
    {
        AuthorEntity? existingAuthor = await authorRepository.GetAuthorByIdAsync(updatedAuthor.Id);
        if (existingAuthor is null) throw new KeyNotFoundException();
        await authorRepository.UpdateAuthorAsync(existingAuthor, updatedAuthor);
    }
}