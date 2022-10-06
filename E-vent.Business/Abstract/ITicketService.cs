using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Abstract
{
    public interface ITicketService
    {
        List<Ticket> GetAll(Expression<Func<Ticket, bool>> filter = null);
        Ticket Get(Expression<Func<Ticket, bool>> filter);
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);

    }
}
