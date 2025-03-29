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
    /// <returns>Список отчетов по продажам</returns>
    [HttpGet("sales")]
    public async Task<ActionResult<IEnumerable<SalesReport>>> GetSalesReport()
    {
        var report = await _orderRepository.GetSalesReportAsync();
        return Ok(report);
    }

    /// <summary>
    /// Получает отчет по популярности товаров за период
    /// </summary>
    /// <returns>Список отчетов по популярности товаров</returns>
    [HttpGet("popular-products")]
    public async Task<ActionResult<IEnumerable<ProductPopularityReport>>> GetPopularProductsReport()
    {
        var report = await _orderRepository.GetPopularProductsReportAsync();
        return Ok(report);
    }
}
