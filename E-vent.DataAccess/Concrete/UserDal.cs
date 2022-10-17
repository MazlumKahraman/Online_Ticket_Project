using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Concrete
{
    public class UserDal : EntityRepositoryBase<User>, IUserDal
    {
        public UserDal(EventOnlineTicketContext context) : base(context)
        {
        }
        public override void Add(User entity)
        {
            _context.UserDetails.Add(entity.Detail);
            _context.SaveChanges();

            entity.DetailId = _context.UserDetails.Max(x => x.DetailId);
            _context.Users.Add(entity);
            _context.SaveChanges();
        }
        public List<User> GetAll(Expression<Func<User, bool>> filter = null, bool navigate = false)
        {
            return (navigate)
                ? _context.Users.Where(filter).Include(u => u.Detail).Include(u => u.Events).Include(u => u.EventUsers).ToList()
                : base.GetAll(filter);
        }
        public User Get(Expression<Func<User, bool>> filter, bool navigate = false)
        {
            return (navigate)
                ? _context.Users.Where(filter).Include(u => u.Detail).Include(u => u.Events).Include(u => u.EventUsers).SingleOrDefault()
                : base.Get(filter);
        }
    }
}
