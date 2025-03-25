namespace SportMeal.UI.Domain.Models;

public class Order
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("clientId")]
    public int ClientId { get; set; }

    [JsonPropertyName("orderDate")]
    public DateTime OrderDate { get; set; }

    [JsonPropertyName("totalAmount")]
    public decimal TotalAmount { get; set; }

    [JsonPropertyName("status")]
    public OrderStatus Status { get; set; }

    public ICollection<Product> Items { get; set; }
}

public enum OrderStatus
{
    Новый,
    ВОбработке,
    Завершен,
    Отменен
} 