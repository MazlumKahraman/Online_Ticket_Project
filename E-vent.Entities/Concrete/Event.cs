using E_vent.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace E_vent.Entities.Concrete
{
    public partial class Event : IEntity
    {
        public Event()
        {
            EventTickets = new HashSet<EventTicket>();
            EventUsers = new HashSet<EventUser>();
        }

        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        public DateTime? BegginigTime { get; set; }
        public DateTime? LastAttendance { get; set; }
        public string? Description { get; set; }
        public string? Adress { get; set; } = null!;
        public decimal? Price { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public int? CityId { get; set; }
        public int? StatusId { get; set; }
        public int? Quato { get; set; }
        public bool? WithTicket { get; set; }
        public bool? IsActive { get; set; }

        public virtual Category? Category { get; set; } = null!;
        public virtual City? City { get; set; } = null!;
        public virtual Status? Status { get; set; } = null!;
        public virtual User? User { get; set; } = null!;
        public virtual ICollection<EventTicket>? EventTickets { get; set; }
        public virtual ICollection<EventUser>? EventUsers { get; set; }
    }
}
