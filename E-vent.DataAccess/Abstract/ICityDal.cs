using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Abstract
{
    public interface ICityDal : IEntityRepository<City>
    {
        List<City> GetAll(Expression<Func<City, bool>> filter = null, bool navigate = false);
        City Get(Expression<Func<City, bool>> filter, bool navigate = false);
    }
}
