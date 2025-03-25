using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly DatabaseFacade _dbContext;

    public ClientRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext.Database;
    }

    public async Task<Client> GetClientByIdAsync(int clientId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияКлиента @ИдКлиента = {clientId}";
        return await Task.Run(() => _dbContext.SqlQuery<Client>(sql).AsEnumerable().FirstOrDefault());
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияВсехКлиентов";
        return await Task.Run(() => _dbContext.SqlQuery<Client>(sql));
    }

    public async Task<Client> CreateClientAsync(Client client)
    {
        FormattableString sql = @$"exec dbo.ПроцедураРегистрацииКлиента 
            @Логин = {client.User.Login},
            @ХешПароля = {client.User.PasswordHash},
            @Имя = {client.FirstName},
            @Фамилия = {client.LastName},
            @Телефон = {client.Phone},
            @Почта = {client.Email}";
        return await Task.Run(() => _dbContext.SqlQuery<Client>(sql).AsEnumerable().First());
    }

    public async Task UpdateClientAsync(Client client)
    {
        FormattableString sql = @$"exec dbo.ПроцедураОбновленияКлиента 
            @ИдКлиента = {client.Id},
            @Имя = {client.FirstName},
            @Фамилия = {client.LastName},
            @Телефон = {client.Phone},
            @Почта = {client.Email}";
        await _dbContext.ExecuteSqlAsync(sql);
    }
}
