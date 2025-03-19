using System.ComponentModel.DataAnnotations;

namespace SportMeal.Api.Domain.Models;

public class AuthResult
{
    public string UserType { get; set; }
    public int Id { get; set; }
}