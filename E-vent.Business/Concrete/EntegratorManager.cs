using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Concrete
{
    public class EntegratorManager : IEntegratorService
    {
        private IEntegratorDal _entegratorDal;
        public EntegratorManager(IEntegratorDal entegratorDal)
        {
            _entegratorDal = entegratorDal;
        }

        public void Add(Entegrator entegrator)
        {
            _entegratorDal.Add(entegrator);
        }

        public void Delete(Entegrator entegrator)
        {
            try
            {
                _entegratorDal.Delete(entegrator);
            }
            catch
            {
                throw new Exception("Deleting Failed!");
            }
        }

        public Entegrator Get(Expression<Func<Entegrator, bool>> filter)
        {
            return _entegratorDal.Get(filter);
        }

        public List<Entegrator> GetAll(Expression<Func<Entegrator, bool>> filter = null)
        {
            return _entegratorDal.GetAll(filter);
        }

        public void Update(Entegrator entegrator)
        {
            _entegratorDal.Update(entegrator);
        }
    }
}
