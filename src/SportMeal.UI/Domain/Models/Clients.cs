using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SportMeal.UI.Domain.Models;

public class Clients
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("phone")]
    public string Phone { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("registrationDate")]
    public DateTime RegistrationDate { get; set; }

    [JsonPropertyName("dateBirth")]
    public DateTime DateBirth { get; set; }

    [JsonPropertyName("height")]
    public decimal Height { get; set; }

    [JsonPropertyName("weight")]
    public decimal Weight { get; set; }

    [JsonPropertyName("goal")]
    public string Goal { get; set; }
} 