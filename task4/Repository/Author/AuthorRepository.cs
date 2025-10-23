
namespace task4;

public class AuthorRepository : IAuthorRepository
{
    static List<Author> authors = new List<Author>();
    public void DeleteAuthor(Author author)
    {
        authors.Remove(author);
    }

    public List<Author> GetAllAuthors()
    {
        return authors;
    }

    public Author? GetAuthorById(int Id)
    {
        return authors.FirstOrDefault(x => x.Id == Id);
    }

    public void InsertAuthor(Author author)
    {
        authors.Add(author);
    }

    public void UpdateAuthor(Author author)
    {
        authors = authors.Select(x => x.Id == author.Id ? author : x).ToList();
    }
}