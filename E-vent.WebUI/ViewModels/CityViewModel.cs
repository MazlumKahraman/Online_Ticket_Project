using System.Text.Json.Serialization;

namespace E_vent.WebUI.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<EventViewModel> Events { get; set; }
    }
}
