using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Concrete
{
    public class EventDal : EntityRepositoryBase<Event>, IEventDal
    {
        public EventDal(EventOnlineTicketContext context) : base(context)
        {
        }

        public List<Event> GetAll(Expression<Func<Event, bool>> filter = null, bool navigate=false)
        {
            return (navigate)
                ? _context.Events.Where(filter).Include(e => e.Category).Include(e => e.City).Include(e => e.User).ThenInclude(e=>e.Detail).ToList()
                : base.GetAll(filter);
        }
        public Event Get(Expression<Func<Event, bool>> filter, bool navigate=false)
        {
            return (navigate)
                ? _context.Events.Where(filter).Include(e => e.Category).Include(e => e.City).Include(e => e.User).ThenInclude(e=>e.Detail).SingleOrDefault()
                : base.Get(filter);
        }
    }
}
