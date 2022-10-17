using System.Text.Json.Serialization;

namespace E_vent.WebUI.ViewModels
{
    public class EventTicketViewModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int EntegratorId { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EntegratorViewModel Entegrator { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EventViewModel Event { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<TicketViewModel> Tickets { get; set; }
    }
}
