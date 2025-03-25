using System.ComponentModel.DataAnnotations.Schema;

namespace SportMeal.Api.Domain.Models;

/// <summary>
/// Модель заказа
/// </summary>
public class Order
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Общая сумма заказа
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    public int Status { get; set; }
    
    /// <summary>
    /// Клиент, сделавший заказ
    /// </summary>
    [NotMapped]
    public Client Client { get; set; }

    /// <summary>
    /// Сотрудник, обрабатывающий заказ
    /// </summary>
    [NotMapped]
    public Employee Employee { get; set; }

    /// <summary>
    /// Позиции заказа
    /// </summary>
    [NotMapped]
    public ICollection<OrderItem> OrderItems { get; set; }
}