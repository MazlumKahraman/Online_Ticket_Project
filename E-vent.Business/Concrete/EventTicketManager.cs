using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Concrete
{
    public class EventTicketManager : IEventTicketService
    {
        private IEventTicketDal _eventTicketDal;

        public EventTicketManager(IEventTicketDal eventTicketDal)
        {
            _eventTicketDal = eventTicketDal;
        }

        public void Add(EventTicket eventTicket)
        {
            _eventTicketDal.Add(eventTicket);
        }

        public void Delete(EventTicket eventTicket)
        {
            try
            {
                _eventTicketDal.Delete(eventTicket);
            }
            catch
            {
                throw new Exception("Deleting Failed!");
            }
        }

        public EventTicket Get(Expression<Func<EventTicket, bool>> filter)
        {
            return _eventTicketDal.Get(filter); 
        }

        public List<EventTicket> GetAll(Expression<Func<EventTicket, bool>> filter = null)
        {
            return _eventTicketDal.GetAll(filter);
        }

        public void Update(EventTicket eventTicket)
        {
            _eventTicketDal.Update(eventTicket);
        }
    }
}
