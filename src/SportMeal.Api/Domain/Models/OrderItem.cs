using System.ComponentModel.DataAnnotations.Schema;

namespace SportMeal.Api.Domain.Models;

/// <summary>
/// Модель позиции заказа
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Идентификатор позиции
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Количество товара
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Цена за единицу товара
    /// </summary>
    public decimal UnitPrice { get; set; }
    
    /// <summary>
    /// Связанный заказ
    /// </summary>
    [NotMapped]
    public Order Order { get; set; }

    /// <summary>
    /// Связанный товар
    /// </summary>
    [NotMapped]
    public Product Product { get; set; }
} 