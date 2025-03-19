using System.Text.Json.Serialization;

namespace SportMeal.Domain.Entities
{
    public class Auth
    {
        /// <summary>
        /// Полное ФИО авторизованного сотрудника.
        /// </summary>
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Удален (уволен) ли сотрудник.
        /// </summary>
        [JsonPropertyName("isDelete")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// Должность сотрудника.
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; }
    }
}
