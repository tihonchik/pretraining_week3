
using Microsoft.AspNetCore.Http.HttpResults;

namespace task4;

class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public void DeleteAuthor(int Id)
    {
        try
        {
            Author? existingAuthor = _authorRepository.GetAuthorById(Id);
            if (existingAuthor is null) throw new Exception();

            _authorRepository.DeleteAuthor(existingAuthor);
        }
        catch
        {
            throw;
        }
    }

    public List<Author> GetAllAuthors()
    {
        try
        {
            return _authorRepository.GetAllAuthors();
        }
        catch
        {
            throw;
        }
    }

    public Author GetAuthorById(int Id)
    {
        try
        {
            Author? author = _authorRepository.GetAuthorById(Id);
            if (author is null) throw new Exception();

            return author;
        }
        catch
        {
            throw;
        }
    }

    public Author InsertAuthor(Author author)
    {
        try
        {
            Author? existingAuthor = _authorRepository.GetAuthorById(author.Id);
            if (existingAuthor is not null) throw new Exception();
            author = _authorRepository.InsertAuthor(author);
            return author;
        }
        catch
        {
            throw;
        }
    }

    public void UpdateAuthor(Author updatedAuthor)
    {
        try
        {
            Author? existingAuthor = _authorRepository.GetAuthorById(updatedAuthor.Id);
            if (existingAuthor is null) throw new Exception();
            _authorRepository.UpdateAuthor(existingAuthor, updatedAuthor);
        }
        catch
        {
            throw;
        }
    }
}