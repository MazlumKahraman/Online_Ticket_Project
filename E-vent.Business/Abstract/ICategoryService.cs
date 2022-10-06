using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);
        Category Get(Expression<Func<Category, bool>> filter);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
