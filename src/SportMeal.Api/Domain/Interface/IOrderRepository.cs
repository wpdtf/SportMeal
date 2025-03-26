using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Domain.Interface;

/// <summary>
/// Интерфейс для работы с заказами
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Получает заказ по идентификатору
    /// </summary>
    /// <param name="orderId">Идентификатор заказа</param>
    /// <returns>Заказ или null, если не найден</returns>
    Task<Order> GetOrderByIdAsync(int orderId);

    /// <summary>
    /// Получает все заказы
    /// </summary>
    /// <returns>Список всех заказов</returns>
    Task<IEnumerable<Order>> GetAllOrdersAsync();

    /// <summary>
    /// Получает заказы клиента
    /// </summary>
    /// <param name="clientId">Идентификатор клиента</param>
    /// <returns>Список заказов клиента</returns>
    Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId);

    /// <summary>
    /// Создает новый заказ
    /// </summary>
    /// <param name="order">Данные заказа</param>
    /// <returns>Созданный заказ</returns>
    Task<Order> CreateOrderAsync(Order order);

    /// <summary>
    /// Получает позиции заказа
    /// </summary>
    /// <param name="orderId">Идентификатор заказа</param>
    /// <returns>Список позиций заказа</returns>
    Task<IEnumerable<OrderItemFull>> GetOrderItemsAsync(int orderId);

    /// <summary>
    /// Добавляет позицию в заказ
    /// </summary>
    /// <param name="orderItem">Данные позиции</param>
    /// <returns>Созданная позиция</returns>
    Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);

    /// <summary>
    /// Обновляет позицию заказа
    /// </summary>
    /// <param name="orderItem">Обновленные данные позиции</param>
    Task UpdateOrderItemAsync(OrderItem orderItem);

    /// <summary>
    /// Удаляет позицию из заказа
    /// </summary>
    /// <param name="orderItemId">Идентификатор позиции</param>
    Task DeleteOrderItemAsync(int orderItemId);

    /// <summary>
    /// Получает отчет по продажам за период
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список отчетов по продажам</returns>
    Task<IEnumerable<SalesReport>> GetSalesReportAsync(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Получает отчет по популярности товаров за период
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список отчетов по популярности товаров</returns>
    Task<IEnumerable<ProductPopularityReport>> GetPopularProductsReportAsync(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Обновление статуса заказа
    /// </summary>
    /// <param name="orderId">Какой заказ</param>
    /// <param name="status">Какой статус</param>
    Task UpdateOrderStatusAsync(int orderId, int status);
} 