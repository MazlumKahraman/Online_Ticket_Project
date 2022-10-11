namespace E_vent.WebUI.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public DateTime ActionTime { get; set; }
        public int UserId { get; set; }
        public int EventTicketId { get; set; }
        public bool IsActive { get; set; }

        public EventTicketViewModel EventTicket { get; set; }
        public UserViewModel User { get; set; }
    }
}
