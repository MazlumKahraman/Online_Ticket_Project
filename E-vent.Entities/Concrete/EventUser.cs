using E_vent.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace E_vent.Entities.Concrete
{
    public partial class EventUser : IEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionTime { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsActive { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
