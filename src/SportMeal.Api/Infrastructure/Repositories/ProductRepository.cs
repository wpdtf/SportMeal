using SportMeal.Api.Domain.Models;
using System.Net.Sockets;

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

    public async Task<IEnumerable<Product>> GetAllProductsAsync(int? idClient)
    {
        FormattableString sql;

        if (idClient == null)
        {
            sql = @$"exec dbo.ПроцедураПолученияВсехТоваров";
        }
        else
        {
            sql = @$"exec dbo.ПроцедураПолученияВсехТоваров @idClient = {idClient}";
        }

        return await Task.Run(() => _dbContext.SqlQuery<Product>(sql));
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId, int? idClient)
    {
        FormattableString sql;

        if (idClient == null)
        {
            sql = @$"exec dbo.ПроцедураПолученияТоваровПоКатегории @ИдКатегории = {categoryId}";
        }
        else
        {
            sql = @$"exec dbo.ПроцедураПолученияТоваровПоКатегории @ИдКатегории = {categoryId}, @idClient = {idClient}";
        }

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