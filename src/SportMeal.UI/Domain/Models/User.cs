using System.Text.Json.Serialization;

namespace SportMeal.UI.Domain.Models;

public class User
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; } = "";

    [JsonPropertyName("passwordHash")]
    public string PasswordHash { get; set; } = string.Empty;

    [JsonPropertyName("userType")]
    public UserType UserType { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("client")]
    public Clients? Client { get; set; }

    [JsonPropertyName("employee")]
    public Employee? Employee { get; set; }
}

public enum UserType
{
    [JsonPropertyName("client")]
    Client,
    
    [JsonPropertyName("employee")]
    Employee
} 