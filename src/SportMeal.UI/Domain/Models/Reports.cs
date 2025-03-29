using System.ComponentModel;

namespace SportMeal.UI.Domain.Models;

/// <summary>
/// Модель отчета по продажам
/// </summary>
public class SalesReport
{
    /// <summary>
    /// Дата
    /// </summary>
    [JsonPropertyName("date")]
    [DisplayName("Дата")]
    public DateTime Date { get; set; }

    /// <summary>
    /// Количество заказов
    /// </summary>
    [JsonPropertyName("orderCount")]
    [DisplayName("Количество заказов")]
    public int OrderCount { get; set; }

    /// <summary>
    /// Общая сумма продаж
    /// </summary>
    [JsonPropertyName("totalSales")]
    [DisplayName("Общая сумма продаж")]
    public decimal TotalSales { get; set; }

    /// <summary>
    /// Средняя стоимость заказа
    /// </summary>
    [JsonPropertyName("averageOrderValue")]
    [DisplayName("Средняя стоимость заказа")]
    public decimal AverageOrderValue { get; set; }
}

/// <summary>
/// Модель отчета по популярности товаров
/// </summary>
public class ProductPopularityReport
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    [JsonPropertyName("productId")]
    [DisplayName("Идентификатор товара")]
    public int ProductId { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    [JsonPropertyName("productName")]
    [DisplayName("Название товара")]
    public string ProductName { get; set; }

    /// <summary>
    /// Общее количество проданных единиц
    /// </summary>
    [JsonPropertyName("totalQuantitySold")]
    [DisplayName("Общее количество проданных единиц")]
    public int TotalQuantitySold { get; set; }

    /// <summary>
    /// Общая выручка
    /// </summary>
    [JsonPropertyName("totalRevenue")]
    [DisplayName("Общая выручка")]
    public decimal TotalRevenue { get; set; }
}
