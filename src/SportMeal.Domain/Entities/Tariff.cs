using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SportMeal.Domain.Entities
{
    public class Tariff
    {
        [JsonPropertyName("tariffId")]
        [DisplayName("Ключ тарифа")]
        public int TariffId { get; set; }
        
        [JsonPropertyName("name")]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        [DisplayName("Цена")]
        public int Price { get; set; }

        [JsonPropertyName("description")]
        [DisplayName("Описание")]
        public string Description { get; set; }
    }
}
