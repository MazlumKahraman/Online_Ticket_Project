using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;

namespace E_vent.WebUI.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        public List<EventViewModel> Events { get; set; }
    }
}
