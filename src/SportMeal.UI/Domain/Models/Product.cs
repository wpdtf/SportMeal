using System.ComponentModel.DataAnnotations.Schema;

namespace SportMeal.UI.Domain.Models;

/// <summary>
/// Модель товара
/// </summary>
public class Product
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор категории
    /// </summary>
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Количество товара на складе
    /// </summary>
    [JsonPropertyName("stockQuantity")]
    public int StockQuantity { get; set; }
    
    /// <summary>
    /// Связанная категория
    /// </summary>
    [NotMapped]
    public Category Category { get; set; }

    /// <summary>
    /// Позиции заказов, содержащие этот товар
    /// </summary>
    [NotMapped]
    public ICollection<Order> OrderItems { get; set; }
} 