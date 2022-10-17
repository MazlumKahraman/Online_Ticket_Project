using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Concrete
{
    public class EventUserDal : EntityRepositoryBase<EventUser>, IEventUserDal
    {
        public EventUserDal(EventOnlineTicketContext context) : base(context)  
        {
        }

        public override List<EventUser> GetAll(Expression<Func<EventUser, bool>> filter = null)
        {
            return _context.EventUsers.Include(x=>x.Event).ThenInclude(x=>x.Category).Include(x=>x.Event).ThenInclude(x=>x.City).Include(x=>x.Event).ThenInclude(x=>x.User).ThenInclude(x=>x.Detail).Where(filter).ToList();
        }
    }
}
