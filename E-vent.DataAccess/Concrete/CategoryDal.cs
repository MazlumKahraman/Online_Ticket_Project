using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;

namespace E_vent.DataAccess.Concrete
{
    public class CategoryDal : EntityRepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(EventOnlineTicketContext context) : base(context)
        {
        }
    }
}
