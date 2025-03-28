using Microsoft.AspNetCore.Mvc;
using SportMeal.Api.Infrastructure.Repositories;
using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _repository;

    public CategoryController(ICategoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    /// <summary>
    /// Получает список всех категорий.
    /// </summary>
    /// <returns>Список категорий.</returns>
    public async Task<IActionResult> GetCategories([FromQuery] int? idClient)
    {
        var categories = await _repository.GetCategoriesAsync(idClient);
        return Ok(categories);
    }

    [HttpPost]
    /// <summary>
    /// Создает новую категорию.
    /// </summary>
    /// <param name="category">Категория для создания.</param>
    /// <returns>Созданная категория.</returns>
    public async Task<IActionResult> CreateCategory([FromBody] Category category)
    {
        var createdCategory = await _repository.CreateCategoriesAsync(category);
        return CreatedAtAction(nameof(GetCategories), new { id = createdCategory.Id }, createdCategory);
    }

    [HttpPut]
    /// <summary>
    /// Обновляет существующую категорию.
    /// </summary>
    /// <param name="category">Категория для обновления.</param>
    public async Task<IActionResult> UpdateCategory([FromBody] Category category)
    {
        await _repository.UpdateCategoriesAsync(category);
        return NoContent();
    }
} 