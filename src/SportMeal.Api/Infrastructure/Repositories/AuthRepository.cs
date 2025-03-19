using Microsoft.EntityFrameworkCore;
using SportMeal.Api.Domain.Interface;
using SportMeal.Api.Domain.Models;
using SportMeal.Api.Infrastructure.Data;

namespace SportMeal.Api.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly DatabaseFacade _dbContext;
    private readonly IClientRepository _clientRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public AuthRepository(
        DataBaseContext dbContext,
        IClientRepository clientRepository,
        IEmployeeRepository employeeRepository)
    {
        _dbContext = dbContext.Database;
        _clientRepository = clientRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<object> AuthenticateAsync(string login, string passwordHash)
    {
        FormattableString sql = @$"exec dbo.ПроцедураАвторизации @Логин = {login}, @ХешПароля = {passwordHash}";
        var result = await Task.Run(() => _dbContext.SqlQuery<AuthResult>(sql).AsEnumerable().FirstOrDefault());
        
        if (result == null)
            return null;

        return result.UserType switch
        {
            "Client" => await _clientRepository.GetClientByIdAsync(result.Id),
            "Employee" => await _employeeRepository.GetEmployeeByIdAsync(result.Id),
            _ => null
        };
    }
}