using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Domain.Interface;

public interface IAuthRepository
{
    Task<object> AuthenticateAsync(string login, string passwordHash);
} 