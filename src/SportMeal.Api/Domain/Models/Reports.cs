namespace SportMeal.Api.Domain.Models;

/// <summary>
/// Модель отчета по продажам
/// </summary>
public class SalesReport
{
    /// <summary>
    /// Дата
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Количество заказов
    /// </summary>
    public int OrderCount { get; set; }

    /// <summary>
    /// Общая сумма продаж
    /// </summary>
    public decimal TotalSales { get; set; }

    /// <summary>
    /// Средняя стоимость заказа
    /// </summary>
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
    public int ProductId { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Общее количество проданных единиц
    /// </summary>
    public int TotalQuantitySold { get; set; }

    /// <summary>
    /// Общая выручка
    /// </summary>
    public decimal TotalRevenue { get; set; }
}

/// <summary>
/// Модель отчета по истории заказов клиента
/// </summary>
public class OrderHistoryReport
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public int OrderId { get; set; }

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
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Количество позиций в заказе
    /// </summary>
    public int ItemCount { get; set; }
} 