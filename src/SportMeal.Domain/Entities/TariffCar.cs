using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SportMeal.Domain.Entities
{
    public class TariffCar
    {
        [JsonPropertyName("CarId")]
        [DisplayName("Ключ автомобиля")]
        public int CarId { get; set; }

        [JsonPropertyName("TariffId")]
        [DisplayName("Ключ тарифа")]
        public int TariffId { get; set; }
    }
}
