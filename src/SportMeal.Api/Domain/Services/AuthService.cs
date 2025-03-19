using SportMeal.Api.Domain.Interface;
using SportMeal.Api.Domain.Models;

namespace SportMeal.Api.Domain.Services;

public class AuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<object> AuthenticateAsync(string login, string passwordHash)
    {
        return await _authRepository.AuthenticateAsync(login, passwordHash);
    }
} 