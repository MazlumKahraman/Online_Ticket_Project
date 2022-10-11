using E_vent.Entities.Abstract;

namespace E_vent.Entities.Concrete
{
    public partial class Status : IEntity
    {
        public Status()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
