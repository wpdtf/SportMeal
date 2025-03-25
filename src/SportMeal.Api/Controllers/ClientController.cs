using Microsoft.AspNetCore.Mvc;
using SportMeal.Api.Domain.Interface;
using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Controllers;

/// <summary>
/// Контроллер для управления клиентами
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepository;

    /// <summary>
    /// Инициализирует новый экземпляр контроллера
    /// </summary>
    /// <param name="clientRepository">Репозиторий для работы с клиентами</param>
    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    /// <summary>
    /// Получает список всех клиентов
    /// </summary>
    /// <returns>Список клиентов</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
    {
        var clients = await _clientRepository.GetAllClientsAsync();
        return Ok(clients);
    }

    /// <summary>
    /// Получает клиента по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор клиента</param>
    /// <returns>Клиент</returns>
    /// <response code="200">Клиент найден</response>
    /// <response code="404">Клиент не найден</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(int id)
    {
        var client = await _clientRepository.GetClientByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    /// <summary>
    /// Создает нового клиента
    /// </summary>
    /// <param name="client">Данные клиента</param>
    /// <returns>Созданный клиент</returns>
    /// <response code="201">Клиент успешно создан</response>
    /// <response code="400">Некорректные данные</response>
    [HttpPost]
    public async Task<ActionResult<Client>> CreateClient(Client client)
    {
        var createdClient = await _clientRepository.CreateClientAsync(client);
        return CreatedAtAction(nameof(GetClient), new { id = createdClient.Id }, createdClient);
    }

    /// <summary>
    /// Обновляет данные клиента
    /// </summary>
    /// <param name="id">Идентификатор клиента</param>
    /// <param name="client">Обновленные данные клиента</param>
    /// <returns>Результат операции</returns>
    /// <response code="204">Клиент успешно обновлен</response>
    /// <response code="400">Некорректные данные</response>
    /// <response code="404">Клиент не найден</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(int id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }

        await _clientRepository.UpdateClientAsync(client);
        return NoContent();
    }
}
