using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Models;

namespace OnlineStore.Controllers
{
    
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // Endpoint to get all categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> getCategories()
        {
            var categories = _service.getCategories();

            if(categories == null)
            {
                return NotFound("There's no categories stored");
            }

            return categories;
        }

        // Endpoint to get one specific category
        [HttpGet("{id}")]
        public ActionResult<Category> getCategory(int id)
        {
            var category = _service.getOneCategory(id);

            if(category == null)
            {
                return NotFound("Selected category not found");
            }

            return category;
        }

        // Endpoint to update a category
        [HttpPut("{id}/update")]
        public ActionResult<Category> updateCategory(int id, Category category)
        {
            var updatedCategory = _service.updateCategory(id, category);

            if(updatedCategory == null)
            {
                return NotFound("Selected category not found");
            }

            return updatedCategory;
        }

        // Endpoint to create a category
        [HttpPost("create")]
        public ActionResult<Category> createCategory(Category category)
        {
            return _service.createCategory(category);
        }

        // Endpoint to delete a category
        [HttpDelete("{id}/delete")]
        public ActionResult<Category> deleteCategory(int id)
        {
            return _service.deleteCategory(id);
        }
    }
}
