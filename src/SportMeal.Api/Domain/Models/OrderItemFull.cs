using System.ComponentModel.DataAnnotations.Schema;

namespace SportMeal.Api.Domain.Models;

/// <summary>
/// Модель позиции заказа
/// </summary>
public class OrderItemFull : OrderItem
{
    /// <summary>
    /// Наименование продукта
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Наименование категории
    /// </summary>
    public string Category { get; set; }
} 