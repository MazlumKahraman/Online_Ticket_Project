using E_vent.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace E_vent.Entities.Concrete
{
    public partial class City : IEntity
    {
        public City()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
