using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Concrete
{
    public class CategoryDal : EntityRepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(EventOnlineTicketContext context) : base(context)
        {
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null, bool navigate = false)
        {
            return (navigate)
                ? _context.Categories.Where(filter).Include(c=>c.Events).ToList()
                : base.GetAll(filter);
        }
        public Category Get(Expression<Func<Category, bool>> filter, bool navigate = false)
        {
            return (navigate)
                ? _context.Categories.Where(filter).Include(c => c.Events).SingleOrDefault()
                : base.Get(filter);
        }
    }
}
