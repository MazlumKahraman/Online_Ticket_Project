using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_vent.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            //validate
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
            }
            catch
            {
                throw new Exception("Deleting Failed!!!");
            }
        }


        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetAll(filter);
        }

        User IUserService.Get(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter);
        }
    }
}
