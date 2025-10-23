namespace task4;

public interface IAuthorRepository
{
    public List<Author> GetAllAuthors();

    public Author? GetAuthorById(int Id);

    public void InsertAuthor(Author author);

    public void UpdateAuthor(Author author);

    public void DeleteAuthor(Author author);
}