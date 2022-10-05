using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public Ticket Get(Expression<Func<Ticket, bool>> filter)
        {
            return _ticketDal.Get(filter);
        }

        public List<Ticket> GetAll(Expression<Func<Ticket, bool>> filter = null)
        {
            return _ticketDal.GetAll(filter);
        }
    }
}
