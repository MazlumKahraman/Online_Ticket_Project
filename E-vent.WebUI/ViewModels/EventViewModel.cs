namespace E_vent.WebUI.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BegginigTime { get; set; }
        public DateTime LastAttendance { get; set; }
        public string? Description { get; set; }
        public string Adress { get; set; } 
        public decimal? Price { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int StatusId { get; set; }
        public int Quato { get; set; }
        public bool WithTicket { get; set; }
        public bool IsActive { get; set; }

        public  CategoryViewModel Category { get; set; } 
        public CityViewModel City { get; set; } 
        public StatusViewModel Status { get; set; }
        public UserViewModel User { get; set; }
        public  ICollection<EventTicketViewModel> EventTickets { get; set; }
        public  ICollection<EventUserViewModel> EventUsers { get; set; }
    }
}
