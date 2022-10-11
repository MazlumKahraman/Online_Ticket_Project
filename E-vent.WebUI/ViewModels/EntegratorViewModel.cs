namespace E_vent.WebUI.ViewModels
{
    public class EntegratorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DomainName { get; set; }
        public string MailAdress { get; set; }
        public string Password { get; set; } 
        public string SecretKey { get; set; } 
        public bool IsActive { get; set; }

        public  ICollection<EventTicketViewModel> EventTickets { get; set; }
    }
}
