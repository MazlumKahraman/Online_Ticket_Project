using E_vent.Entities.Abstract;

namespace E_vent.Entities.Concrete
{
    public partial class EventTicket : IEntity
    {
        public EventTicket()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int Quato { get; set; }
        public int EventId { get; set; }
        public int EntegratorId { get; set; }
        public bool IsActive { get; set; }

        public virtual Entegrator Entegrator { get; set; } = null!;
        public virtual Event Event { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
