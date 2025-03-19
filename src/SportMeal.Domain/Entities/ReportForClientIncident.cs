using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SportMeal.Domain.Entities
{
    public class ReportForClientIncident : ReportForClientBooking
    {
        [JsonPropertyName("incidentId")]
        [DisplayName("Ключ инцидента")]
        public int IncidentId { get; set; }

        [JsonPropertyName("clientGuilty")]
        [DisplayName("Виноват клиент")]
        public bool ClientGuilty { get; set; }

        [JsonPropertyName("description")]
        [DisplayName("Описание инцидента")]
        public string Description { get; set; }

        [JsonPropertyName("nomerTicket")]
        [DisplayName("Номер обращения в ГАИ")]
        public string NomerTicket { get; set; }
    }
}
