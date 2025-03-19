using SportMeal.Domain.Declare;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SportMeal.Domain.Entities
{
    public class ReportForClientBooking : Report
    {
        [JsonPropertyName("bookingId")]
        [DisplayName("Ключ брования")]
        public int BookingId { get; set; }

        [JsonPropertyName("status")]
        [DisplayName("Статус бронирования")]
        [JsonConverter(typeof(JsonNumberEnumConverter<statusBooking>))]
        public statusBooking Status { get; set; }

        [JsonPropertyName("bookingTime")]
        [DisplayName("Время создания бронирования")]
        public int BookingTime { get; set; }

        [JsonPropertyName("bookingStart")]
        [DisplayName("Время начала поездки")]
        public DateTime BookingStart { get; set; }

        [JsonPropertyName("nameTariff")]
        [DisplayName("Наименование тарифа")]
        public string NameTariff { get; set; }

        [JsonPropertyName("countIncident")]
        [DisplayName("Количество инцидентов")]
        public int? CountIncident { get; set; }
    }
}
