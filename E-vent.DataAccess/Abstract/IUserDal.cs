using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<User> GetAll(Expression<Func<User, bool>> filter = null, bool navigate = false);
        User Get(Expression<Func<User, bool>> filter, bool navigate = false);
    }
}
