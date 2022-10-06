using E_vent.Business.Abstract;
using E_vent.Business.Concrete;
using E_vent.DataAccess.Concrete;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryManager(new CategoryDal());
        }

        [HttpGet("GetAllCategories")]
        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAll(c => c.IsActive);
        }

        [HttpGet("GetCategory")]
        public Category GetCategory(int categoryId)
        {
            return _categoryService.Get(c => c.Id == categoryId && c.IsActive);
        }

        [HttpPost("AddCategory")]
        public ActionResult AddCategory([FromBody] Category category)
        {
            if (_categoryService.Get(c => c.Name.Equals(category.Name) && c.IsActive) is null)
            {
                _categoryService.Add(category);
                return Ok();
            }
            return BadRequest("Category name already exist, please enter another category name");
        }

        [HttpPut("DeleteCategory")]
        public ActionResult DeleteCategory(int categoryId)
        {
            var category = _categoryService.Get(d => d.Id == categoryId && d.IsActive);
            if (category is not null)
            {
                category.IsActive = false;
                _categoryService.Update(category);
                return Ok(category);
            }
            return BadRequest("Category not found");
        }

        [HttpPut("UpdateCategory")]
        public ActionResult UpdateCategory(Category category)
        {
            var updateCategory = _categoryService.Get(d => d.Id == category.Id && d.IsActive);
            if (updateCategory is not null)
            {
                updateCategory=_categoryService.Get(c=>c.Name.Equals(category.Name));
                if (updateCategory is null)
                {
                    _categoryService.Update(category);
                    return Ok();
                }
                return BadRequest("Category name already exist!");
            }
            return BadRequest("Category not found");
        }
    }
}
