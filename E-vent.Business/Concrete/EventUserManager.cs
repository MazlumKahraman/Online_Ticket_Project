using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Concrete
{
    public class EventUserManager : IEventUserService
    {
        private IEventUserDal _eventUserDal;

        public EventUserManager(IEventUserDal eventUserDal)
        {
            _eventUserDal = eventUserDal;
        }

        public void Add(EventUser eventUser)
        {
            _eventUserDal.Add(eventUser);
        }

        public void Delete(EventUser eventUser)
        {
            _eventUserDal.Delete(eventUser);
        }

        public EventUser Get(Expression<Func<EventUser, bool>> filter)
        {
            return _eventUserDal.Get(filter);
        }

        public List<EventUser> GetAll(Expression<Func<EventUser, bool>> filter = null)
        {
            return _eventUserDal.GetAll(filter);
        }

        public void Update(EventUser eventUser)
        {
            _eventUserDal.Update(eventUser);
        }
    }
}
