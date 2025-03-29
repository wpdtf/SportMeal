using System.ComponentModel;

namespace SportMeal.UI.Domain.Models;

public class Employee
{
    [JsonPropertyName("id")]
    [DisplayName("ИдСотрудника")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    [Browsable(false)]
    public int UserId { get; set; }

    [JsonPropertyName("firstName")]
    [DisplayName("ИмяСотрудника")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    [DisplayName("ФамилияСотрудника")]
    public string LastName { get; set; }

    [JsonPropertyName("phone")]
    [DisplayName("ТелефонСотрудника")]
    public string Phone { get; set; }

    [JsonPropertyName("email")]
    [DisplayName("ПочтаСотрудника")]
    public string Email { get; set; }

    [JsonPropertyName("position")]
    [DisplayName("Должность")]
    public string Position { get; set; }

    [Browsable(false)]
    public User Users { get; set; }
} 