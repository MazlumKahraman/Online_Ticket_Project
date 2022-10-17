using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Abstract
{
    public interface IEventDal : IEntityRepository<Event>
    {
        List<Event> GetAll(Expression<Func<Event, bool>> filter = null, bool navigate = false);
        Event Get(Expression<Func<Event, bool>> filter, bool navigate = false);
    }
}
