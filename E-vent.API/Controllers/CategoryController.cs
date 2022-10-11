using E_vent.API.Helpers.Attributes;
using E_vent.Business.Abstract;
using E_vent.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_vent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public List<Category> GetAll()
        {
            return _categoryService.GetAll(c => c.IsActive);
        }

        [HttpGet("Get/{id}")]
        public Category Get(int id)
        {
            return _categoryService.Get(c => c.Id == id && c.IsActive);
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Category category)
        {
            if (_categoryService.Get(c => c.Name.Equals(category.Name) && c.IsActive) is null)
            {
                _categoryService.Add(category);
                return Ok(category);
            }
            return BadRequest("Category name already exist, please enter another category name");
        }

        [HttpPut("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var category = _categoryService.Get(d => d.Id == id && d.IsActive);
            if (category is not null)
            {
                category.IsActive = false;
                _categoryService.Update(category);
                return NoContent();
            }
            return BadRequest("Category not found");
        }

        [HttpPut("Update")]
        public ActionResult Update(Category category)
        {
            var updateCategory = _categoryService.Get(d => d.Id == category.Id && d.IsActive);
            if (updateCategory is not null)
            {
                updateCategory=_categoryService.Get(c=>c.Name.Equals(category.Name));
                if (updateCategory is null)
                {
                    _categoryService.Update(category);
                    return Ok(category);
                }
                return BadRequest("Category name already exist!");
            }
            return BadRequest("Category not found");
        }
    }
}
