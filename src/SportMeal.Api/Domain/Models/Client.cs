using System.ComponentModel.DataAnnotations.Schema;

namespace SportMeal.Api.Domain.Models;

/// <summary>
/// Модель клиента
/// </summary>
public class Client
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия клиента
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Email клиента
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; set; }
    
    /// <summary>
    /// Связанный пользователь
    /// </summary>
    [NotMapped]
    public User User { get; set; }

    /// <summary>
    /// Заказы клиента
    /// </summary>
    [NotMapped]
    public ICollection<Order> Orders { get; set; }
} 