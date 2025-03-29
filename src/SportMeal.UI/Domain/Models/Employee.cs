using System.ComponentModel;

namespace SportMeal.UI.Domain.Models;

public class Employee
{
    [JsonPropertyName("id")]
    [DisplayName("������������")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    [Browsable(false)]
    public int UserId { get; set; }

    [JsonPropertyName("firstName")]
    [DisplayName("�������������")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    [DisplayName("�����������������")]
    public string LastName { get; set; }

    [JsonPropertyName("phone")]
    [DisplayName("�����������������")]
    public string Phone { get; set; }

    [JsonPropertyName("email")]
    [DisplayName("���������������")]
    public string Email { get; set; }

    [JsonPropertyName("position")]
    [DisplayName("���������")]
    public string Position { get; set; }

    [Browsable(false)]
    public User Users { get; set; }
} 