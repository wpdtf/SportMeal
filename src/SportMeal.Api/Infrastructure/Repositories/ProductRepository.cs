using Microsoft.EntityFrameworkCore;
using SportMeal.Api.Domain.Interface;
using SportMeal.Api.Domain.Models;
using SportMeal.Api.Infrastructure.Data;
using System.Text.Json;

namespace SportMeal.Api.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DatabaseFacade _dbContext;

    public ProductRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext.Database;
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияТовара @ИдТовара = {productId}";
        return await Task.Run(() => _dbContext.SqlQuery<Product>(sql).AsEnumerable().FirstOrDefault());
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияВсехТоваров";
        return await Task.Run(() => _dbContext.SqlQuery<Product>(sql));
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияТоваровПоКатегории @ИдКатегории = {categoryId}";
        return await Task.Run(() => _dbContext.SqlQuery<Product>(sql));
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        FormattableString sql = @$"exec dbo.ПроцедураСозданияТовара 
            @ИдКатегории = {product.CategoryId},
            @НазваниеТовара = {product.Name},
            @Описание = {product.Description},
            @Цена = {product.Price},
            @КоличествоНаСкладе = {product.StockQuantity}";
        return await Task.Run(() => _dbContext.SqlQuery<Product>(sql).AsEnumerable().First());
    }

    public async Task UpdateProductAsync(Product product)
    {
        FormattableString sql = @$"exec dbo.ПроцедураОбновленияТовара 
            @ИдТовара = {product.Id},
            @ИдКатегории = {product.CategoryId},
            @НазваниеТовара = {product.Name},
            @Описание = {product.Description},
            @Цена = {product.Price},
            @КоличествоНаСкладе = {product.StockQuantity}";
        await _dbContext.ExecuteSqlAsync(sql);
    }

    public async Task DeleteProductAsync(int productId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураУдаленияТовара @ИдТовара = {productId}";
        await _dbContext.ExecuteSqlAsync(sql);
    }

    public async Task UpdateStockQuantityAsync(int productId, int quantity)
    {
        FormattableString sql = @$"exec dbo.ПроцедураОбновленияКоличестваТовара 
            @ИдТовара = {productId}, 
            @Количество = {quantity}";
        await _dbContext.ExecuteSqlAsync(sql);
    }
} 