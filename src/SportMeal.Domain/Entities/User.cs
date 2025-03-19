using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SportMeal.Domain.Entities
{
    public class User
    {
        /// <summary>
        /// Логин сотрудника
        /// </summary>
        [JsonPropertyName("login")]
        [DisplayName("Логин сотрудника")]
        public string Login { get; set; }

        /// <summary>
        /// Дата начала действия логина
        /// </summary>
        [JsonPropertyName("dateStart")]
        [DisplayName("Дата начала действия")]
        public DateTime DateStart { get; set; }

        /// <summary>
        /// До какого числа работал\работает
        /// </summary>
        [JsonPropertyName("dateLast")]
        [DisplayName("Дата окончания действия")]
        public DateTime DateLast { get; set; }
    }
}
