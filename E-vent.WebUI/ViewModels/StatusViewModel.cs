using System.Text.Json.Serialization;

namespace E_vent.WebUI.ViewModels
{
    public class StatusViewModel
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<EventViewModel> Events { get; set; }
    }
}
