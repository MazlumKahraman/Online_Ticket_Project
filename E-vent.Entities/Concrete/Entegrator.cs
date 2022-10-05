using E_vent.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace E_vent.Entities.Concrete
{
    public partial class Entegrator : IEntity
    {
        public Entegrator()
        {
            EventTickets = new HashSet<EventTicket>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string DomainName { get; set; } = null!;
        public string MailAdress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string SecretKey { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<EventTicket> EventTickets { get; set; }
    }
}
