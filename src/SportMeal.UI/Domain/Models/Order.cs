using System.ComponentModel;

namespace SportMeal.UI.Domain.Models;

public class Order
{
    [JsonPropertyName("id")]
    [DisplayName("��������")]
    public int Id { get; set; }

    [JsonPropertyName("clientId")]
    [DisplayName("���������")]
    public int ClientId { get; set; }

    [JsonPropertyName("orderDate")]
    [DisplayName("����������")]
    public DateTime OrderDate { get; set; }

    [JsonPropertyName("totalAmount")]
    [DisplayName("�����������������")]
    public decimal TotalAmount { get; set; }

    [JsonPropertyName("status")]
    [DisplayName("������������")]
    public OrderStatus Status { get; set; }
}

public enum OrderStatus
{
    �����,
    ����������,
    ��������,
    �������
} 