using System.ComponentModel.DataAnnotations;

namespace task4;

public class BookEntity()
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int PublishedYear { get; set; }

    public int AuthorId { get; set; }

    public AuthorEntity Author { get; set; } = null!;

}