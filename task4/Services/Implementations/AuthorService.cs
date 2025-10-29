
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace task4;

class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task DeleteAuthorAsync(int Id)
    {
        try
        {
            Author? existingAuthor = await _authorRepository.GetAuthorByIdAsync(Id);
            if (existingAuthor is null) throw new Exception();

            await _authorRepository.DeleteAuthorAsync(existingAuthor);
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Author>> GetAllAuthorsAsync(AuthorFilterDto filter)
    {
        try
        {
            return await _authorRepository.GetAllAuthorsAsync(filter);
        }
        catch
        {
            throw;
        }
    }

    public async Task<Author> GetAuthorByIdAsync(int Id)
    {
        try
        {
            Author? author = await _authorRepository.GetAuthorByIdAsync(Id);
            if (author is null) throw new Exception();

            return author;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Author> InsertAuthorAsync(Author author)
    {
        try
        {
            author = await _authorRepository.InsertAuthorAsync(author);
            return author;
        }
        catch
        {
            throw;
        }
    }

    public async Task UpdateAuthorAsync(Author updatedAuthor)
    {
        try
        {
            Author? existingAuthor = await _authorRepository.GetAuthorByIdAsync(updatedAuthor.Id);
            if (existingAuthor is null) throw new Exception();
            await _authorRepository.UpdateAuthorAsync(existingAuthor, updatedAuthor);
        }
        catch
        {
            throw;
        }
    }
}