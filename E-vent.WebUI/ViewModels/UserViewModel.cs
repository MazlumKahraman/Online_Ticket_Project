namespace E_vent.WebUI.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; } 
        public string MailAdress { get; set; } 
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public ICollection<EventUserViewModel> EventUsers { get; set; }
        public ICollection<EventViewModel> Events { get; set; }
        public ICollection<TicketViewModel> Tickets { get; set; }
    }
}
