using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Concrete
{
    public class TicketManager : ITicketService
    {
        private ITicketDal _ticketDal;
        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public void Add(Ticket ticket)
        {
            //validate
            _ticketDal.Add(ticket);
        }

        public void Delete(Ticket ticket)
        {
            _ticketDal.Delete(ticket);
        }

        public Ticket Get(Expression<Func<Ticket, bool>> filter)
        {
            return _ticketDal.Get(filter);
        }

        public List<Ticket> GetAll(Expression<Func<Ticket, bool>> filter = null)
        {
            return _ticketDal.GetAll(filter);
        }

        public void Update(Ticket ticket)
        {
            _ticketDal.Update(ticket);
        }
    }
}
