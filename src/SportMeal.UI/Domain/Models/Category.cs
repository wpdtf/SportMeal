using System.ComponentModel;

namespace SportMeal.UI.Domain.Models;

public class Category
{

    [JsonPropertyName("id")]
    [DisplayName("�����������")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    [DisplayName("���������������������")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    [DisplayName("�����������������")]
    public string Description { get; set; }

    [JsonPropertyName("beLike")]
    [Browsable(false)]
    public int BeLike { get; set; }
} 