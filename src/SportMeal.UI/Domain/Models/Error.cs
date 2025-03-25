namespace SportMeal.UI.Domain.Models;

public class Error
{
    [JsonPropertyName("detail")]
    public string Detail { get; set; } = string.Empty;
} 