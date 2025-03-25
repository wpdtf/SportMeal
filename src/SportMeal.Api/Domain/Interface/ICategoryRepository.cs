using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Domain.Interface;

public interface ICategoryRepository
{
    /// <summary>
    /// Получает все категории.
    /// </summary>
    /// <returns>Список категорий.</returns>
    Task<IEnumerable<Category>> GetCategoriesAsync();

    /// <summary>
    /// Создает новую категорию.
    /// </summary>
    /// <param name="category">Категория для создания.</param>
    /// <returns>Созданная категория.</returns>
    Task<Category> CreateCategoriesAsync(Category category);

    /// <summary>
    /// Обновляет существующую категорию.
    /// </summary>
    /// <param name="category">Категория для обновления.</param>
    Task UpdateCategoriesAsync(Category category);

    /// <summary>
    /// Удаляет категорию по идентификатору.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории для удаления.</param>
    Task DeleteCategoriesAsync(int categoryId);
}
