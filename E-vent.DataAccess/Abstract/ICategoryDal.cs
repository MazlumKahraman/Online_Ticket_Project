using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null, bool navigate = false);
        Category Get(Expression<Func<Category, bool>> filter, bool navigate = false);
    }
}
