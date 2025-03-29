using System.ComponentModel;
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
    [DisplayName("Идентификатор товара")]
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор категории
    /// </summary>
    [JsonPropertyName("categoryId")]
    [DisplayName("Идентификатор категории")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    [JsonPropertyName("name")]
    [DisplayName("Название товара")]
    public string Name { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    [JsonPropertyName("description")]
    [DisplayName("Описание товара")]
    public string Description { get; set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    [JsonPropertyName("price")]
    [DisplayName("Цена товара")]
    public decimal Price { get; set; }

    /// <summary>
    /// Количество товара на складе
    /// </summary>
    [JsonPropertyName("stockQuantity")]
    [DisplayName("Количество товара на складе")]
    public int StockQuantity { get; set; }

    [JsonPropertyName("beLike")]
    [Browsable(false)]
    public int BeLike { get; set; }
} 