using System.Text.Json.Serialization;

namespace E_vent.WebUI.ViewModels
{
    public class EventUserViewModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionTime { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EventViewModel Event { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UserViewModel User { get; set; }
    }
}
