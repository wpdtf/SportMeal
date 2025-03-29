using System.ComponentModel;

namespace SportMeal.UI.Domain.Models;

public class Order
{
    [JsonPropertyName("id")]
    [DisplayName("ИдЗаказа")]
    public int Id { get; set; }

    [JsonPropertyName("clientId")]
    [DisplayName("ИдКлиента")]
    public int ClientId { get; set; }

    [JsonPropertyName("orderDate")]
    [DisplayName("ДатаЗаказа")]
    public DateTime OrderDate { get; set; }

    [JsonPropertyName("totalAmount")]
    [DisplayName("МаксимальнаяСумма")]
    public decimal TotalAmount { get; set; }

    [JsonPropertyName("status")]
    [DisplayName("СтатусЗаказа")]
    public OrderStatus Status { get; set; }
}

public enum OrderStatus
{
    Новый,
    ВОбработке,
    Завершен,
    Отменен
} 