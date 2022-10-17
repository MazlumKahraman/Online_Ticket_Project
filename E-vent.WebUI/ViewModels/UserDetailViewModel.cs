using System.Text.Json.Serialization;

namespace E_vent.WebUI.ViewModels
{
    public class UserDetailViewModel
    {
        public int DetailId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<UserViewModel> Users { get; set; }
    }
}
