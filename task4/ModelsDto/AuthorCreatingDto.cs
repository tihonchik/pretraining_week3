using System.ComponentModel.DataAnnotations;

namespace task4;

public class AuthorCreatingDto()
{

    [Required(ErrorMessage = "Name is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 200")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "DateOfBirth is required")]
    public DateTime DateOfBirth { get; set; }
}