using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Domain.Interface;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(int employeeId);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int employeeId);
    Task<Employee> AuthenticateAsync(string login, string passwordHash);
    Task<IEnumerable<Order>> GetEmployeeOrdersAsync(int employeeId);
} 