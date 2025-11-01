using System.ComponentModel.DataAnnotations;

namespace task4;

public class AuthorEntity()
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public ICollection<BookEntity> Books { get; set; } = null!;
}