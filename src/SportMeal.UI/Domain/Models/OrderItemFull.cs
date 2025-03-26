namespace SportMeal.UI.Domain.Models;

public class OrderItemFull : OrderItem
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }
}