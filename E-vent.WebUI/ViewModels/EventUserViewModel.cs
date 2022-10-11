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

        public EventViewModel Event { get; set; }
        public UserViewModel User { get; set; }
    }
}
