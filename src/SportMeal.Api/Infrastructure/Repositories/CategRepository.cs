using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Infrastructure.Repositories;

public class CategRepository : ICategoryRepository
{
    private readonly DatabaseFacade _dbContext;

    public CategRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext.Database;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияВсехКатегорий";
        return await Task.Run(() => _dbContext.SqlQuery<Category>(sql).AsEnumerable());
    }

    public async Task<Category> CreateCategoriesAsync(Category category)
    {
        FormattableString sql = @$"exec dbo.ПроцедураСозданияКатегории 
            @Название = {category.Name},
            @Описание = {category.Description}";
        return await Task.Run(() => _dbContext.SqlQuery<Category>(sql).AsEnumerable().First());
    }

    public async Task UpdateCategoriesAsync(Category category)
    {
        FormattableString sql = @$"exec dbo.ПроцедураОбновленияКатегории 
            @ИдКатегории = {category.Id},
            @Название = {category.Name},
            @Описание = {category.Description}";
        await _dbContext.ExecuteSqlAsync(sql);
    }

    public async Task DeleteCategoriesAsync(int categoryId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураУдаленияКатегории @ИдКатегории = {categoryId}";
        await _dbContext.ExecuteSqlAsync(sql);
    }
} 