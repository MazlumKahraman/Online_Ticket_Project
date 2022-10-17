using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Abstract
{
    public interface ICityService
    {
        List<City> GetAll(Expression<Func<City, bool>> filter = null);
        List<City> GetAll(Expression<Func<City, bool>> filter = null, bool navigate = false);

        City Get(Expression<Func<City, bool>> filter);
        City Get(Expression<Func<City, bool>> filter, bool navigate = false);
        void Add(City city);
        void Update(City city);
        void Delete(City city);
    }
}
