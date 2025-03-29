using SportMeal.Api.Domain.DTO;
using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Domain.Interface;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(int employeeId);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task UpdateUserInfo(UpdateEmployeeDTO employee);
    Task<string> GetLoginAsync(int employeeId);
} 