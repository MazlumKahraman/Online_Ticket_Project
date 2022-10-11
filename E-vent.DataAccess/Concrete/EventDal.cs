using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;

namespace E_vent.DataAccess.Concrete
{
    public class EventDal : EntityRepositoryBase<Event>, IEventDal
    {
        public EventDal(EventOnlineTicketContext context) : base(context)
        {
        }
    }
}
