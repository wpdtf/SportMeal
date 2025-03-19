using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SportMeal.Domain.Entities
{
    public class Car
    {
        [JsonPropertyName("carId")]
        [DisplayName("Ключ автомобиля")] 
        public int CarId { get; set; }

        [JsonPropertyName("brand")]
        [DisplayName("Бренд")]
        public string Brand { get; set; }

        [JsonPropertyName("mark")]
        [DisplayName("Марка")]
        public string Mark { get; set; }

        [JsonPropertyName("yearStart")]
        [DisplayName("Год производитства")]
        public int YearStart { get; set; }

        [JsonPropertyName("color")]
        [DisplayName("Цвет")]
        public string Color { get; set; }

        [JsonPropertyName("carNumber")]
        [DisplayName("Номер автомобиля")]
        public string CarNumber { get; set; }

        [JsonPropertyName("vin")]
        [DisplayName("Вин номер автомобиля")]
        public string VIN { get; set; }

        [JsonPropertyName("active")]
        [DisplayName("Активен ли автомобиль")]
        public bool Active { get; set; }

        [JsonPropertyName("minimalExperience")]
        [DisplayName("Минимальный стаж автомобиля")]
        public int MinimalExperience { get; set; }

        [JsonPropertyName("class")]
        [DisplayName("Ключ класса автомобиля")]
        public int Class { get; set; }

        [JsonPropertyName("classTxt")]
        [DisplayName("Класс автомобиля")]
        public string ClassTxt { get; set; }
    }
}
