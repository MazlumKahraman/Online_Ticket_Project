using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Concrete
{
    public class CityDal : EntityRepositoryBase<City>, ICityDal
    {
        public CityDal(EventOnlineTicketContext context) : base(context)
        {
        }

        public List<City> GetAll(Expression<Func<City, bool>> filter = null, bool navigate = false)
        {
            return (navigate)
                ? _context.Cities.Where(filter).Include(c => c.Events).ToList()
                : base.GetAll(filter);
        }
        public City Get(Expression<Func<City, bool>> filter, bool navigate = false)
        {
            return (navigate)
                ? _context.Cities.Where(filter).Include(c => c.Events).SingleOrDefault()
                : base.Get(filter);
        }
    }
}
