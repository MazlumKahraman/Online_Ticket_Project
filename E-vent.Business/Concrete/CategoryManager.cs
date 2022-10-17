using E_vent.Business.Abstract;
using E_vent.DataAccess.Abstract;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using System.Linq.Expressions;

namespace E_vent.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
            _categoryDal.Add(category); 
        }

        public void Delete(Category category)
        {
            try
            {
                _categoryDal.Delete(category);
            }
            catch
            {
                throw new Exception("Deleting Failed!");
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Get(filter);        
        }

        public Category Get(Expression<Func<Category, bool>> filter, bool navigate = false)
        {
            return _categoryDal.Get(filter, navigate);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetAll(filter);
        }
        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null, bool navigate = false)
        {
            return _categoryDal.GetAll(filter, navigate);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
