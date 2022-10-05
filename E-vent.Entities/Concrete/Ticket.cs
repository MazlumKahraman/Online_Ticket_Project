using E_vent.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace E_vent.Entities.Concrete
{
    public partial class Ticket : IEntity
    {
        public int Id { get; set; }
        public DateTime ActionTime { get; set; }
        public int UserId { get; set; }
        public int EventTicketId { get; set; }
        public bool IsActive { get; set; }

        public virtual EventTicket EventTicket { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
