using E_vent.Entities.Abstract;
using System.Linq.Expressions;

namespace E_vent.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity); 
        void Update(T entity); 
        void Delete(T entity);
    }
}
