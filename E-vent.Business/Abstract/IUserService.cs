using E_vent.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_vent.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll(Expression<Func<User, bool>> filter = null);
        User Get(Expression<Func<User, bool>> filter);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
