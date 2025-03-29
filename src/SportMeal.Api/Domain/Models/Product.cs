using System.ComponentModel.DataAnnotations.Schema;

namespace SportMeal.Api.Domain.Models;

/// <summary>
/// Модель товара
/// </summary>
public class Product
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор категории
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Количество товара на складе
    /// </summary>
    public int StockQuantity { get; set; }

    public int BeLike { get; set; }

    /// <summary>
    /// Связанная категория
    /// </summary>
    [NotMapped]
    public Category Category { get; set; }

    /// <summary>
    /// Позиции заказов, содержащие этот товар
    /// </summary>
    [NotMapped]
    public ICollection<OrderItem> OrderItems { get; set; }
} 