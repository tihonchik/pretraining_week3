using System.ComponentModel.DataAnnotations;

namespace task4;

public class BookCreatedDto()
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "PublishedYear is required")]
    public int PublishedYear { get; set; }

    [Required(ErrorMessage = "AuthorId is required")]
    public int AuthorId { get; set; }

}