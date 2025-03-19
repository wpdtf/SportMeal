using Microsoft.AspNetCore.Mvc;
using SportMeal.Api.Domain.Interface;
using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Controllers;

/// <summary>
/// Контроллер для управления сотрудниками
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    /// <summary>
    /// Инициализирует новый экземпляр контроллера
    /// </summary>
    /// <param name="employeeRepository">Репозиторий для работы с сотрудниками</param>
    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    /// <summary>
    /// Получает список всех сотрудников
    /// </summary>
    /// <returns>Список сотрудников</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllEmployeesAsync();
        return Ok(employees);
    }

    /// <summary>
    /// Получает сотрудника по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <returns>Сотрудник</returns>
    /// <response code="200">Сотрудник найден</response>
    /// <response code="404">Сотрудник не найден</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    /// <summary>
    /// Создает нового сотрудника
    /// </summary>
    /// <param name="employee">Данные сотрудника</param>
    /// <returns>Созданный сотрудник</returns>
    /// <response code="201">Сотрудник успешно создан</response>
    /// <response code="400">Некорректные данные</response>
    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        var createdEmployee = await _employeeRepository.CreateEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
    }

    /// <summary>
    /// Обновляет данные сотрудника
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <param name="employee">Обновленные данные сотрудника</param>
    /// <returns>Результат операции</returns>
    /// <response code="204">Сотрудник успешно обновлен</response>
    /// <response code="400">Некорректные данные</response>
    /// <response code="404">Сотрудник не найден</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest();
        }

        await _employeeRepository.UpdateEmployeeAsync(employee);
        return NoContent();
    }

    /// <summary>
    /// Удаляет сотрудника
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <returns>Результат операции</returns>
    /// <response code="204">Сотрудник успешно удален</response>
    /// <response code="404">Сотрудник не найден</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _employeeRepository.DeleteEmployeeAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Получает заказы сотрудника
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <returns>Список заказов</returns>
    [HttpGet("{id}/orders")]
    public async Task<ActionResult<IEnumerable<Order>>> GetEmployeeOrders(int id)
    {
        var orders = await _employeeRepository.GetEmployeeOrdersAsync(id);
        return Ok(orders);
    }
} 