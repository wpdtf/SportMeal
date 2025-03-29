using Microsoft.AspNetCore.Mvc;
using SportMeal.Api.Domain.Interface;
using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Controllers;

/// <summary>
/// Контроллер для управления товарами
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Инициализирует новый экземпляр контроллера
    /// </summary>
    /// <param name="productRepository">Репозиторий для работы с товарами</param>
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <summary>
    /// Получает список всех товаров
    /// </summary>
    /// <returns>Список товаров</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] int? idClient)
    {
        var products = await _productRepository.GetAllProductsAsync(idClient);
        return Ok(products);
    }

    /// <summary>
    /// Получает товар по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    /// <returns>Товар</returns>
    /// <response code="200">Товар найден</response>
    /// <response code="404">Товар не найден</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    /// <summary>
    /// Получает товары по категории
    /// </summary>
    /// <param name="categoryId">Идентификатор категории</param>
    /// <returns>Список товаров категории</returns>
    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId, [FromQuery] int? idClient)
    {
        var products = await _productRepository.GetProductsByCategoryAsync(categoryId, idClient);
        return Ok(products);
    }

    /// <summary>
    /// Создает новый товар
    /// </summary>
    /// <param name="product">Данные товара</param>
    /// <returns>Созданный товар</returns>
    /// <response code="201">Товар успешно создан</response>
    /// <response code="400">Некорректные данные</response>
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        var createdProduct = await _productRepository.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
    }

    /// <summary>
    /// Обновляет данные товара
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    /// <param name="product">Обновленные данные товара</param>
    /// <returns>Результат операции</returns>
    /// <response code="204">Товар успешно обновлен</response>
    /// <response code="400">Некорректные данные</response>
    /// <response code="404">Товар не найден</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        await _productRepository.UpdateProductAsync(product);
        return NoContent();
    }

    /// <summary>
    /// Удаляет товар
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    /// <returns>Результат операции</returns>
    /// <response code="204">Товар успешно удален</response>
    /// <response code="404">Товар не найден</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productRepository.DeleteProductAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Обновляет количество товара на складе
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    /// <param name="quantity">Новое количество</param>
    /// <returns>Результат операции</returns>
    /// <response code="204">Количество успешно обновлено</response>
    /// <response code="404">Товар не найден</response>
    [HttpPut("{id}/stock")]
    public async Task<IActionResult> UpdateStockQuantity(int id, [FromBody] int quantity)
    {
        await _productRepository.UpdateStockQuantityAsync(id, quantity);
        return NoContent();
    }
} 