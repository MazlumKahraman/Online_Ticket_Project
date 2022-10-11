using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Concrete
{
    public class EventManager : IEventService
    {
        private IEventDal _eventDal;
        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public void Add(Event @event)
        {
            //validate
            _eventDal.Add(@event);
        }

        public void Delete(Event @event)
        {
            try
            {
                _eventDal.Delete(@event);
            }
            catch
            {
                throw new Exception("Deleting Failed!");
            }
        }

        public Event Get(Expression<Func<Event, bool>> filter)
        {
            return _eventDal.Get(filter);
        }

        public List<Event> GetAll(Expression<Func<Event, bool>> filter = null)
        {
            return _eventDal.GetAll(filter);
        }

        public void Update(Event @event)
        {
            _eventDal.Update(@event);
        }
    }
}