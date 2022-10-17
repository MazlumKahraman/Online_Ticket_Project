using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null, bool navigate = false);
        Category Get(Expression<Func<Category, bool>> filter);
        Category Get(Expression<Func<Category, bool>> filter, bool navigate = false);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
