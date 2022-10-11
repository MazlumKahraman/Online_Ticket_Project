using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;

namespace E_vent.DataAccess.Concrete
{
    public class StatusDal : EntityRepositoryBase<Status>, IStatusDal
    {
        public StatusDal(EventOnlineTicketContext context) : base(context)
        {
        }
    }
}
