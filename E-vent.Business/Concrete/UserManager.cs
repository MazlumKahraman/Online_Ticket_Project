using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter);
        }
        public User Get(Expression<Func<User, bool>> filter, bool navigate = false)
        {
            return _userDal.Get(filter, navigate);
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetAll(filter);
        }
        public List<User> GetAll(Expression<Func<User, bool>> filter = null, bool navigate = false)
        {
            return _userDal.GetAll(filter, navigate);
        }


        public void Add(User user)
        {
            //validate
            _userDal.Add(user);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
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
    }
}
