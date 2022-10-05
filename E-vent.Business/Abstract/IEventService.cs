using E_vent.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_vent.Business.Abstract
{
    public interface IEventService
    {
        List<Event> GetAll(Expression<Func<Event, bool>> filter = null);
        Event Get(Expression<Func<Event, bool>> filter);
        void Add(Event @event);
        void Update(Event @event);  
        void Delete(Event @event);
    }
}
