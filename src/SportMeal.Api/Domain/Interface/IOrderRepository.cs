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
    /// Получает заказы сотрудника
    /// </summary>
    /// <param name="employeeId">Идентификатор сотрудника</param>
    /// <returns>Список заказов сотрудника</returns>
    Task<IEnumerable<Order>> GetOrdersByEmployeeIdAsync(int employeeId);

    /// <summary>
    /// Создает новый заказ
    /// </summary>
    /// <param name="order">Данные заказа</param>
    /// <returns>Созданный заказ</returns>
    Task<Order> CreateOrderAsync(Order order);

    /// <summary>
    /// Обновляет статус заказа
    /// </summary>
    /// <param name="orderId">Идентификатор заказа</param>
    /// <param name="status">Новый статус</param>
    Task UpdateOrderStatusAsync(int orderId, OrderStatus status);

    /// <summary>
    /// Получает позиции заказа
    /// </summary>
    /// <param name="orderId">Идентификатор заказа</param>
    /// <returns>Список позиций заказа</returns>
    Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId);

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
    /// Получает историю заказов клиента
    /// </summary>
    /// <param name="clientId">Идентификатор клиента</param>
    /// <returns>Список отчетов по истории заказов</returns>
    Task<IEnumerable<OrderHistoryReport>> GetClientOrderHistoryAsync(int clientId);
} 