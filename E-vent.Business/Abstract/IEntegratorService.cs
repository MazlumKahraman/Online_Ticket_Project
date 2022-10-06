using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Abstract
{
    public interface IEntegratorService
    {
        List<Entegrator> GetAll(Expression<Func<Entegrator, bool>> filter = null);
        Entegrator Get(Expression<Func<Entegrator, bool>> filter);
        void Add(Entegrator entegrator);
        void Update(Entegrator entegrator);
        void Delete(Entegrator entegrator);
    }
}
