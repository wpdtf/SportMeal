using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SportMeal.Api.Domain.Models;
using SportMeal.Api.Domain.Services;

namespace SportMeal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Аутентифицирует клиента
    /// </summary>
    /// <param name="authDTO">Данные для аутентификации</param>
    /// <returns>Клиент</returns>
    /// <response code="200">Аутентификация успешна</response>
    /// <response code="401">Неверные учетные данные</response>
    [HttpPost("auth")]
    public async Task<ActionResult<Client>> Authenticate(AuthDTO authDTO)
    {
        var user = await _authService.AuthenticateAsync(authDTO.Login, authDTO.Password);

        if (user == null)
        {
            return Unauthorized("Неверный логин или пароль");
        }

        return Ok(user);
    }
}