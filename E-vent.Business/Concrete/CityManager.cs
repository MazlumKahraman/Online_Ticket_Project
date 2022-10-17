using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public void Add(City city)
        {
            _cityDal.Add(city);
        }

        public void Delete(City city)
        {
            try
            {
                _cityDal.Delete(city);
            }
            catch
            {
                throw new Exception("Deleting Failed!");
            }
        }

        public City Get(Expression<Func<City, bool>> filter)
        {
            return _cityDal.Get(filter);
        }
        public City Get(Expression<Func<City, bool>> filter, bool navigate = false)
        {
            return _cityDal.Get(filter, navigate);
        }

        public List<City> GetAll(Expression<Func<City, bool>> filter = null)
        {
            return _cityDal.GetAll(filter);
        }
        public List<City> GetAll(Expression<Func<City, bool>> filter = null, bool navigate = false)
        {
            return _cityDal.GetAll(filter, navigate);
        }


        public void Update(City city)
        {
            _cityDal.Update(city);
        }
    }
}
