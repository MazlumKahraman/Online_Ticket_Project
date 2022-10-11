using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace E_vent.DataAccess.Concrete
{
    public class TicketDal : EntityRepositoryBase<Ticket>, ITicketDal
    {
        public TicketDal(EventOnlineTicketContext context) : base(context)
        {
        }
    }
}
