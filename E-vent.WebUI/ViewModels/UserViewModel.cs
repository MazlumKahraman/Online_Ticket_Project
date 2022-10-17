using System.Text.Json.Serialization;

namespace E_vent.WebUI.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string MailAdress { get; set; }
        public string Password { get; set; }
        public int? DetailId { get; set; }
        public bool IsActive { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UserDetailViewModel? Detail { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<EventUserViewModel> EventUsers { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<EventViewModel> Events { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<TicketViewModel> Tickets { get; set; }
    }
}
