
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace task4;

class AuthorService(IAuthorRepository authorRepository) : IAuthorService
{
    private IAuthorRepository _authorRepository = authorRepository;

    public async Task DeleteAuthorAsync(int Id)
    {
        Author? existingAuthor = await _authorRepository.GetAuthorByIdAsync(Id);
        if (existingAuthor is null) throw new KeyNotFoundException();

        await _authorRepository.DeleteAuthorAsync(existingAuthor);
    }

    public async Task<List<Author>> GetAllAuthorsAsync(AuthorFilterDto filter)
    {
        return await _authorRepository.GetAllAuthorsAsync(filter);
    }

    public async Task<Author> GetAuthorByIdAsync(int Id)
    {
        Author? author = await _authorRepository.GetAuthorByIdAsync(Id);
        if (author is null) throw new KeyNotFoundException();

        return author;
    }

    public async Task<Author> InsertAuthorAsync(Author author)
    {
        author = await _authorRepository.InsertAuthorAsync(author);
        return author;
    }

    public async Task UpdateAuthorAsync(Author updatedAuthor)
    {
        Author? existingAuthor = await _authorRepository.GetAuthorByIdAsync(updatedAuthor.Id);
        if (existingAuthor is null) throw new KeyNotFoundException();
        await _authorRepository.UpdateAuthorAsync(existingAuthor, updatedAuthor);
    }
}