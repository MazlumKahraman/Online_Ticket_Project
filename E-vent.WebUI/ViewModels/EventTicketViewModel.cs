namespace E_vent.WebUI.ViewModels
{
    public class EventTicketViewModel
    {
        public int Id { get; set; }
        public int Quato { get; set; }
        public int EventId { get; set; }
        public int EntegratorId { get; set; }
        public bool IsActive { get; set; }

        public EntegratorViewModel Entegrator { get; set; }
        public EventViewModel Event { get; set; } 
        public ICollection<TicketViewModel> Tickets { get; set; }
    }
}
