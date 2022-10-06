using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Abstract
{
    public interface IEventUserService
    {
        List<EventUser> GetAll(Expression<Func<EventUser, bool>> filter = null);
        EventUser Get(Expression<Func<EventUser, bool>> filter);
        void Add(EventUser eventUser);
        void Update(EventUser eventUser);
        void Delete(EventUser eventUser);
    }
}
