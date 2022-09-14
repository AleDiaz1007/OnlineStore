
using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Models;
using OnlineStore.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public ActionResult<IEnumerable<Category>> getCategories()
        {
            return _repository.getCategories();

        }

        public ActionResult<Category> getOneCategory(int id)
        {
            return _repository.getOneCategory(id);
        }

        public ActionResult<Category> updateCategory(int id, Category category)
        {
            return _repository.updateCategory(id, category);
        }

        public ActionResult<Category> createCategory(Category category)
        {
            return _repository.createCategory(category); 
        }

        public ActionResult<Category> deleteCategory(int id)
        {
            return _repository.deleteCategory(id);
        }
    }
}
