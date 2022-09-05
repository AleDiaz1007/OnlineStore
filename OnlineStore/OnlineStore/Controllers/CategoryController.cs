﻿using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // Endpoint to get all categories
        [HttpGet("/getCategories")]
        public ActionResult<IEnumerable<Category>> getCategories()
        {
            return _service.getCategories();
        }

        // Endpoint to get one specific category
        [HttpGet("/getCategory/{id}")]
        public Category Get(int id)
        {
            Category result = _service.getOneCategory(id);

            return result;
        }

        [HttpPut("/updateCategory/{id}")]
        public ActionResult<Category> updateCategory(int id, Category category)
        {
            return _service.updateCategory(id, category);
        }

        [HttpPost("/createCategory")]
        public ActionResult<Category> createCategory(Category category)
        {
            return _service.createCategory(category);
        }

        [HttpDelete("/deleteCategory/{id}")]
        public ActionResult<Category> deleteCategory(int id)
        {
            return _service.deleteCategory(id);
        }
    }
}