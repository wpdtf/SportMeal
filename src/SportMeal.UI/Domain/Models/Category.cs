namespace SportMeal.UI.Domain.Models;

public class Category
{

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("beLike")]
    public int BeLike { get; set; }
} 