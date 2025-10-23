namespace task4;

public interface IAuthorService
{
    public List<Author> GetAllAuthors();

    public Author? GetAuthorById(int Id);

    public void InsertAuthor(Author author);

    public void UpdateAuthor(Author author);

    public void DeleteAuthor(int Id);
}