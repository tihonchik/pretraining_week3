using System.Text.Json;

namespace task4;

public class ErrorDto()
{
    public int StatusCode { get; set; }

    public string Message { get; set; } = null!;

}