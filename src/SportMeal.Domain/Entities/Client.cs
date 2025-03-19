using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SportMeal.Domain.Entities
{
    public class Client
    {

        [JsonPropertyName("clientId")]
        [DisplayName("Ключ клиента")]
        public int ClientId { get; set; }

        [JsonPropertyName("last_name")]
        [DisplayName("Фамилия клиента")]
        public string Last_name { get; set; }

        [JsonPropertyName("first_name")]
        [DisplayName("Имя клиента")]
        public string First_name { get; set; }

        [JsonPropertyName("middle_name")]
        [DisplayName("Отчество клиента")]
        public string Middle_name { get; set; }

        [JsonPropertyName("birthdate")]
        [DisplayName("Дата рождения")]
        public DateTime Birthdate { get; set; }

        [JsonPropertyName("phone")]
        [DisplayName("Номер телефона клиента")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        [DisplayName("Почта клиента")]
        public string Email { get; set; }

        [JsonPropertyName("passport")]
        [DisplayName("Паспорт клиента")]
        public string Passport { get; set; }

        [JsonPropertyName("driverLicense")]
        [DisplayName("Номер водительского")]
        public string DriverLicense { get; set; }

        [JsonPropertyName("dateStartDriving")]
        [DisplayName("Дата начала вождения")]
        public DateTime DateStartDriving { get; set; }

        [JsonPropertyName("blocked")]
        [DisplayName("Заблокирован")]
        public bool Blocked { get; set; }

        [JsonPropertyName("experience")]
        [DisplayName("Стаж")]
        public int? Experience { get; set; }
    }
}
