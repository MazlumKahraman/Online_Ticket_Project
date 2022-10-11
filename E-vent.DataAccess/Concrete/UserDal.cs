using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;

namespace E_vent.DataAccess.Concrete
{
    public class UserDal : EntityRepositoryBase<User>, IUserDal
    {
        public UserDal(EventOnlineTicketContext context) : base(context)
        {
        }
    }
}
