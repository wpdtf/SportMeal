using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DatabaseFacade _dbContext;

    public OrderRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext.Database;
    }

    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияЗаказа @ИдЗаказа = {orderId}";
        return await Task.Run(() => _dbContext.SqlQuery<Order>(sql).AsEnumerable().FirstOrDefault());
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияВсехЗаказов";
        return await Task.Run(() => _dbContext.SqlQuery<Order>(sql));
    }

    public async Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияЗаказовКлиента @ИдКлиента = {clientId}";
        return await Task.Run(() => _dbContext.SqlQuery<Order>(sql));
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        FormattableString sql = @$"exec dbo.ПроцедураСозданияЗаказа 
            @ИдКлиента = {order.ClientId},
            @ИдСотрудника = {order.EmployeeId},
            @ДатаЗаказа = {order.OrderDate},
            @СуммаЗаказа = {order.TotalAmount},
            @Статус = {order.Status}";
        return await Task.Run(() => _dbContext.SqlQuery<Order>(sql).AsEnumerable().First());
    }

    public async Task UpdateOrderStatusAsync(int orderId, int status)
    {
        FormattableString sql = @$"exec dbo.ПроцедураОбновленияСтатусаЗаказа 
            @ИдЗаказа = {orderId}, 
            @Статус = {status}";
        await _dbContext.ExecuteSqlAsync(sql);
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияПозицийЗаказа @ИдЗаказа = {orderId}";
        return await Task.Run(() => _dbContext.SqlQuery<OrderItem>(sql));
    }

    public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
    {
        FormattableString sql = @$"exec dbo.ПроцедураДобавленияПозицииЗаказа 
            @ИдЗаказа = {orderItem.OrderId},
            @ИдТовара = {orderItem.ProductId},
            @Количество = {orderItem.Quantity},
            @ЦенаЗаЕдиницу = {orderItem.UnitPrice}";
        return await Task.Run(() => _dbContext.SqlQuery<OrderItem>(sql).AsEnumerable().First());
    }

    public async Task UpdateOrderItemAsync(OrderItem orderItem)
    {
        FormattableString sql = @$"exec dbo.ПроцедураОбновленияПозицииЗаказа 
            @ИдПозиции = {orderItem.Id},
            @Количество = {orderItem.Quantity},
            @ЦенаЗаЕдиницу = {orderItem.UnitPrice}";
        await _dbContext.ExecuteSqlAsync(sql);
    }

    public async Task DeleteOrderItemAsync(int orderItemId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураУдаленияПозицииЗаказа @ИдПозиции = {orderItemId}";
        await _dbContext.ExecuteSqlAsync(sql);
    }

    public async Task<IEnumerable<SalesReport>> GetSalesReportAsync(DateTime startDate, DateTime endDate)
    {
        FormattableString sql = @$"exec dbo.ПроцедураОтчетаПоПродажам 
            @ДатаНачала = {startDate}, 
            @ДатаКонца = {endDate}";
        return await Task.Run(() => _dbContext.SqlQuery<SalesReport>(sql));
    }

    public async Task<IEnumerable<ProductPopularityReport>> GetPopularProductsReportAsync(DateTime startDate, DateTime endDate)
    {
        FormattableString sql = @$"exec dbo.ПроцедураОтчетаПоПопулярностиТоваров 
            @ДатаНачала = {startDate}, 
            @ДатаКонца = {endDate}";
        return await Task.Run(() => _dbContext.SqlQuery<ProductPopularityReport>(sql));
    }
} 