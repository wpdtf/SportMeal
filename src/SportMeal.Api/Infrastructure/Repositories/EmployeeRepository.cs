using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DatabaseFacade _dbContext;

    public EmployeeRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext.Database;
    }

    public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияСотрудника @ИдСотрудника = {employeeId}";
        return await Task.Run(() => _dbContext.SqlQuery<Employee>(sql).AsEnumerable().FirstOrDefault());
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        FormattableString sql = @$"exec dbo.ПроцедураПолученияВсехСотрудников";
        return await Task.Run(() => _dbContext.SqlQuery<Employee>(sql));
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        FormattableString sql = @$"exec dbo.ПроцедураРегистрацииСотрудника 
            @Логин = {employee.User.Login},
            @ХешПароля = {employee.User.PasswordHash},
            @Имя = {employee.FirstName},
            @Фамилия = {employee.LastName},
            @Телефон = {employee.Phone},
            @Почта = {employee.Email},
            @Должность = {employee.Position}";
        return await Task.Run(() => _dbContext.SqlQuery<Employee>(sql).AsEnumerable().First());
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        FormattableString sql = @$"exec dbo.ПроцедураОбновленияСотрудника 
            @ИдСотрудника = {employee.Id},
            @Имя = {employee.FirstName},
            @Фамилия = {employee.LastName},
            @Телефон = {employee.Phone},
            @Почта = {employee.Email},
            @Должность = {employee.Position}";
        await _dbContext.ExecuteSqlAsync(sql);
    }
} 