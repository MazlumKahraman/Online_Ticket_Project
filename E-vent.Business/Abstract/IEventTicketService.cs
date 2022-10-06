using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Abstract
{
    public interface IEventTicketService
    {
        List<EventTicket> GetAll(Expression<Func<EventTicket, bool>> filter = null);
        EventTicket Get(Expression<Func<EventTicket, bool>> filter);
        void Add(EventTicket eventTicket);
        void Update(EventTicket eventTicket);
        void Delete(EventTicket eventTicket);
    }
}
