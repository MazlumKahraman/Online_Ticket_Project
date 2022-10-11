using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;

namespace E_vent.DataAccess.Concrete
{
    public class EventUserDal : EntityRepositoryBase<EventUser>, IEventUserDal
    {
        public EventUserDal(EventOnlineTicketContext context) : base(context)  
        {
        }
    }
}
