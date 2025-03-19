using Microsoft.AspNetCore.Mvc;
using SportMeal.Api.Domain.Interface;
using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Controllers;

/// <summary>
/// Контроллер для работы с отчетами
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    /// <summary>
    /// Инициализирует новый экземпляр контроллера
    /// </summary>
    /// <param name="orderRepository">Репозиторий для работы с заказами</param>
    public ReportController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    /// <summary>
    /// Получает отчет по продажам за период
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список отчетов по продажам</returns>
    [HttpGet("sales")]
    public async Task<ActionResult<IEnumerable<SalesReport>>> GetSalesReport(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        var report = await _orderRepository.GetSalesReportAsync(startDate, endDate);
        return Ok(report);
    }

    /// <summary>
    /// Получает отчет по популярности товаров за период
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список отчетов по популярности товаров</returns>
    [HttpGet("popular-products")]
    public async Task<ActionResult<IEnumerable<ProductPopularityReport>>> GetPopularProductsReport(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        var report = await _orderRepository.GetPopularProductsReportAsync(startDate, endDate);
        return Ok(report);
    }

    /// <summary>
    /// Получает историю заказов клиента
    /// </summary>
    /// <param name="clientId">Идентификатор клиента</param>
    /// <returns>Список отчетов по истории заказов</returns>
    [HttpGet("client/{clientId}/history")]
    public async Task<ActionResult<IEnumerable<OrderHistoryReport>>> GetClientOrderHistory(int clientId)
    {
        var history = await _orderRepository.GetClientOrderHistoryAsync(clientId);
        return Ok(history);
    }
}
