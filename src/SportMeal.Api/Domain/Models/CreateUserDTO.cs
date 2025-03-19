namespace SportMeal.Api.Domain.Models;

public class CreateUserDTO
{
    public string Login { get; set; }
    public string Password { get; set; }
    public int UserId { get; set; }
    public string Phone { get; set; }
    public DateTime DateLactActual { get; set; }
} 