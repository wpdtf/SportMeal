namespace SportMeal.Api.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public UserType UserType { get; set; }
    public bool IsActive { get; set; }
    
    public Client Client { get; set; }
    public Employee Employee { get; set; }
}

public enum UserType
{
    Client,
    Employee
} 