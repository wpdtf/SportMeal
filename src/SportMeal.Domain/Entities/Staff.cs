using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SportMeal.Domain.Entities
{
    public class Staff
    {
        [JsonPropertyName("userId")]
        [DisplayName("Ключ сотрудника")]
        public int UserId { get; set; }

        [JsonPropertyName("last_name")]
        [DisplayName("Фамилия")]
        public string Last_name { get; set; }

        [JsonPropertyName("first_name")]
        [DisplayName("Имя")]
        public string First_name { get; set; }

        [JsonPropertyName("middle_name")]
        [DisplayName("Отчество")]
        public string Middle_name { get; set; }

        [JsonPropertyName("phone")]
        [DisplayName("Телефон")]
        public string Phone { get; set; }

        [JsonPropertyName("birthdate")]
        [DisplayName("Дата рождения")]
        public DateTime Birthdate { get; set; }

        [JsonPropertyName("dismissed")]
        [DisplayName("Уволен?")]
        public bool Dismissed { get; set; }

        [JsonPropertyName("position")]
        [DisplayName("Ключ должности")]
        public short Position { get; set; }

        [JsonPropertyName("positionTxt")]
        [DisplayName("Должность сотрудника")]
        public string PositionTxt { get; set; }
    }
}
