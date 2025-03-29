using System.ComponentModel.DataAnnotations.Schema;

namespace SportMeal.Api.Domain.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int BeLike { get; set; }

    /// <summary>
    /// Заказы клиента
    /// </summary>
    [NotMapped]
    public ICollection<Product> Products { get; set; }
} 