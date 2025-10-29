namespace task4;

public interface IAuthorRepository
{
    public List<Author> GetAllAuthors();

    public Author? GetAuthorById(int Id);

    public Author InsertAuthor(Author author);

    public void UpdateAuthor(Author existingAuthor, Author updatedAuthor);

    public void DeleteAuthor(Author author);
}