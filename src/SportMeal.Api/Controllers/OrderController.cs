using Microsoft.AspNetCore.Mvc;
using SportMeal.Api.Domain.Interface;
using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Controllers;

/// <summary>
/// Контроллер для управления заказами
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    /// <summary>
    /// Инициализирует новый экземпляр контроллера
    /// </summary>
    /// <param name="orderRepository">Репозиторий для работы с заказами</param>
    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    /// <summary>
    /// Получает список всех заказов
    /// </summary>
    /// <returns>Список заказов</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
    {
        var orders = await _orderRepository.GetAllOrdersAsync();
        return Ok(orders);
    }

    /// <summary>
    /// Получает заказ по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns>Заказ</returns>
    /// <response code="200">Заказ найден</response>
    /// <response code="404">Заказ не найден</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    /// <summary>
    /// Получает заказы клиента
    /// </summary>
    /// <param name="clientId">Идентификатор клиента</param>
    /// <returns>Список заказов клиента</returns>
    [HttpGet("client/{clientId}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetClientOrders(int clientId)
    {
        var orders = await _orderRepository.GetOrdersByClientIdAsync(clientId);
        return Ok(orders);
    }

    /// <summary>
    /// Создает новый заказ
    /// </summary>
    /// <param name="order">Данные заказа</param>
    /// <returns>Созданный заказ</returns>
    /// <response code="201">Заказ успешно создан</response>
    /// <response code="400">Некорректные данные</response>
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        var createdOrder = await _orderRepository.CreateOrderAsync(order);
        return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
    }

    /// <summary>
    /// обновляет статус заказа
    /// </summary>
    /// <param name="id">Идентификатор позиции</param>
    /// <param name="status">Новый статус заказа</param>
    /// <returns>Результат операции</returns>
    /// <response code="204">Позиция успешно удалена</response>
    /// <response code="404">Позиция не найдена</response>
    [HttpPut("status/{id}")]
    public async Task<IActionResult> UpdateOrderStatusAsync([FromQuery] int id, int status)
    {
        await _orderRepository.UpdateOrderStatusAsync(id, status);
        return NoContent();
    }

    /// <summary>
    /// Получает позиции заказа
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns>Список позиций заказа</returns>
    [HttpGet("{id}/items")]
    public async Task<ActionResult<IEnumerable<OrderItemFull>>> GetOrderItems(int id)
    {
        var items = await _orderRepository.GetOrderItemsAsync(id);
        return Ok(items);
    }

    /// <summary>
    /// Добавляет позицию в заказ
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <param name="item">Данные позиции</param>
    /// <returns>Созданная позиция</returns>
    /// <response code="201">Позиция успешно добавлена</response>
    /// <response code="400">Некорректные данные</response>
    [HttpPost("{id}/items")]
    public async Task<ActionResult<OrderItem>> AddOrderItem(int id, OrderItem item)
    {
        if (id != item.OrderId)
        {
            return BadRequest();
        }

        var createdItem = await _orderRepository.AddOrderItemAsync(item);
        return CreatedAtAction(nameof(GetOrderItems), new { id = createdItem.OrderId }, createdItem);
    }

    /// <summary>
    /// Обновляет позицию заказа
    /// </summary>
    /// <param name="id">Идентификатор позиции</param>
    /// <param name="item">Обновленные данные позиции</param>
    /// <returns>Результат операции</returns>
    /// <response code="204">Позиция успешно обновлена</response>
    /// <response code="400">Некорректные данные</response>
    /// <response code="404">Позиция не найдена</response>
    [HttpPut("items/{id}")]
    public async Task<IActionResult> UpdateOrderItem(int id, OrderItem item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        await _orderRepository.UpdateOrderItemAsync(item);
        return NoContent();
    }

    /// <summary>
    /// Удаляет позицию из заказа
    /// </summary>
    /// <param name="id">Идентификатор позиции</param>
    /// <returns>Результат операции</returns>
    /// <response code="204">Позиция успешно удалена</response>
    /// <response code="404">Позиция не найдена</response>
    [HttpDelete("items/{id}")]
    public async Task<IActionResult> DeleteOrderItem(int id)
    {
        await _orderRepository.DeleteOrderItemAsync(id);
        return NoContent();
    }
} 