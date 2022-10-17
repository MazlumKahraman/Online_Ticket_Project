using E_vent.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace E_vent.Entities.Concrete
{
    public partial class User : IEntity
    {
        public User()
        {
            EventUsers = new HashSet<EventUser>();
            Events = new HashSet<Event>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string? MailAdress { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public int? DetailId { get; set; }
        public bool? IsActive { get; set; }

        public virtual UserDetail? Detail { get; set; }
        public virtual ICollection<EventUser>? EventUsers { get; set; }
        public virtual ICollection<Event>? Events { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}
