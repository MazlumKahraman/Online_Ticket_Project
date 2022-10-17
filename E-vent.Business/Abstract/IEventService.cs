using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Abstract
{
    public interface IEventService
    {
        List<Event> GetAll(Expression<Func<Event, bool>> filter = null);
        List<Event> GetAll(Expression<Func<Event, bool>> filter = null, bool navigate = false);

        Event Get(Expression<Func<Event, bool>> filter);
        Event Get(Expression<Func<Event, bool>> filter, bool navigate = false);

        void Add(Event @event);
        void Update(Event @event);  
        void Delete(Event @event);
    }
}
