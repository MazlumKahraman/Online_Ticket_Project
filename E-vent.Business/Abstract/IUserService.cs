using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll(Expression<Func<User, bool>> filter = null);
        List<User> GetAll(Expression<Func<User, bool>> filter = null, bool navigate = false);

        User Get(Expression<Func<User, bool>> filter);
        User Get(Expression<Func<User, bool>> filter, bool navigate = false);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
