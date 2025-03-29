using SportMeal.Api.Domain.Models;
using System.Net.Sockets;

namespace SportMeal.Api.Domain.Interface;

/// <summary>
/// Интерфейс для работы с товарами
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Получает товар по идентификатору
    /// </summary>
    /// <param name="productId">Идентификатор товара</param>
    /// <returns>Товар или null, если не найден</returns>
    Task<Product> GetProductByIdAsync(int productId);

    /// <summary>
    /// Получает все товары
    /// </summary>
    /// <returns>Список всех товаров</returns>
    Task<IEnumerable<Product>> GetAllProductsAsync(int? idClient);

    /// <summary>
    /// Получает товары по категории
    /// </summary>
    /// <param name="categoryId">Идентификатор категории</param>
    /// <returns>Список товаров категории</returns>
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId, int? idClient);

    /// <summary>
    /// Создает новый товар
    /// </summary>
    /// <param name="product">Данные товара</param>
    /// <returns>Созданный товар</returns>
    Task<Product> CreateProductAsync(Product product);

    /// <summary>
    /// Обновляет данные товара
    /// </summary>
    /// <param name="product">Обновленные данные товара</param>
    Task UpdateProductAsync(Product product);

    /// <summary>
    /// Удаляет товар
    /// </summary>
    /// <param name="productId">Идентификатор товара</param>
    Task DeleteProductAsync(int productId);

    /// <summary>
    /// Обновляет количество товара на складе
    /// </summary>
    /// <param name="productId">Идентификатор товара</param>
    /// <param name="quantity">Новое количество</param>
    Task UpdateStockQuantityAsync(int productId, int quantity);
} 