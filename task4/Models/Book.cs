using System.ComponentModel.DataAnnotations;

namespace task4;

public class Book()
{
    [Required(ErrorMessage = "Id is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "PublishedYear is required")]
    public int PublishedYear { get; set; }

    [Required(ErrorMessage = "AuthorId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "AuthorId must be greater than 0")]
    public int AuthorId { get; set; }

}