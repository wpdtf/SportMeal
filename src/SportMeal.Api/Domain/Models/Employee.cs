using System.ComponentModel.DataAnnotations.Schema;

namespace SportMeal.Api.Domain.Models;

/// <summary>
/// Модель сотрудника
/// </summary>
public class Employee
{
    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Должность
    /// </summary>
    public string Position { get; set; }

    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Связанный пользователь
    /// </summary>
    [NotMapped]
    public User User { get; set; }

    public DateTime RegistrationDate { get; set; }
    [NotMapped]
    public ICollection<Order> Orders { get; set; }
} 