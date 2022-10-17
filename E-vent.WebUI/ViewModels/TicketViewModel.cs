using System.Text.Json.Serialization;

namespace E_vent.WebUI.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public DateTime ActionTime { get; set; }
        public int UserId { get; set; }
        public int EventTicketId { get; set; }
        public bool IsActive { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EventTicketViewModel EventTicket { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UserViewModel User { get; set; }
    }
}
