using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Domain.Interface;

/// <summary>
/// Интерфейс для работы с клиентами
/// </summary>
public interface IClientRepository
{
    /// <summary>
    /// Получает клиента по идентификатору
    /// </summary>
    /// <param name="clientId">Идентификатор клиента</param>
    /// <returns>Клиент или null, если не найден</returns>
    Task<Client> GetClientByIdAsync(int clientId);

    /// <summary>
    /// Получает всех клиентов
    /// </summary>
    /// <returns>Список всех клиентов</returns>
    Task<IEnumerable<Client>> GetAllClientsAsync();

    /// <summary>
    /// Создает нового клиента
    /// </summary>
    /// <param name="client">Данные клиента</param>
    /// <returns>Созданный клиент</returns>
    Task<Client> CreateClientAsync(Client client);

    /// <summary>
    /// Обновляет данные клиента
    /// </summary>
    /// <param name="client">Обновленные данные клиента</param>
    Task UpdateClientAsync(Client client);

    /// <summary>
    /// Удаляет клиента
    /// </summary>
    /// <param name="clientId">Идентификатор клиента</param>
    Task DeleteClientAsync(int clientId);

    /// <summary>
    /// Аутентифицирует клиента
    /// </summary>
    /// <param name="login">Логин</param>
    /// <param name="passwordHash">Хеш пароля</param>
    /// <returns>Клиент или null, если аутентификация не удалась</returns>
    Task<Client> AuthenticateAsync(string login, string passwordHash);

    /// <summary>
    /// Получает заказы клиента
    /// </summary>
    /// <param name="clientId">Идентификатор клиента</param>
    /// <returns>Список заказов клиента</returns>
    Task<IEnumerable<Order>> GetClientOrdersAsync(int clientId);
}
