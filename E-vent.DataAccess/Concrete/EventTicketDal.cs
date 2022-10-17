using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Concrete
{
    public class EventTicketDal : EntityRepositoryBase<EventTicket>, IEventTicketDal
    {
        public EventTicketDal(EventOnlineTicketContext context) : base(context)    
        {
        }
        public override List<EventTicket> GetAll(Expression<Func<EventTicket, bool>> filter = null)
        {
            return _context.EventTickets.Include(e=>e.Entegrator).Where(filter).ToList();
        }
        public override EventTicket Get(Expression<Func<EventTicket, bool>> filter)
        {
            return _context.EventTickets.Include(e => e.Entegrator).Where(filter).SingleOrDefault();
        }
    }
}
