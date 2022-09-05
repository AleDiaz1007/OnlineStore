using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.DAL.Models;
using Microsoft.Extensions.Configuration;
using OnlineStore.DAL.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContextOptions<OnlineStoreContext> _optionsBuilder;

        protected readonly IConfiguration _configuration;
        public CategoryRepository(DbContextOptions<OnlineStoreContext> context)
        {
            _optionsBuilder = context;
        }

        public ActionResult<IEnumerable<Category>> getCategories()
        {
            using (var db = new OnlineStoreContext(_optionsBuilder))
            {
                List<Category> categories = db.Category.Select(x => x).ToList();

                if (categories.Any())
                {
                    return categories;
                }

                return null;

            }
        }

        public Category getOneCategory(int id)
        {
            using (var db = new OnlineStoreContext(_optionsBuilder))
            {
                Category query = db.Category.FirstOrDefault(category => category.Id == id);

                if(query != null)
                {
                    return query;
                }

                return null;
            }
        }

        public ActionResult<Category> updateCategory(int id, Category category)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Category originalCategory = db.Category.FirstOrDefault(s => s.Id == id);

                if(originalCategory == null)
                {
                    return null;
                }

                originalCategory.Name = category.Name;

                db.SaveChanges();

                return category;
            }
        }

        public ActionResult<Category> createCategory(Category category)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                db.Category.Add(category);

                db.SaveChanges();

                return category;
            }
        }

        public ActionResult<Category> deleteCategory(int id)
        {
            using (var db = new OnlineStoreContext(_optionsBuilder))
            {
                Category categoryToRemove = db.Category.FirstOrDefault(category => category.Id == id);

                if(categoryToRemove != null)
                {
                    db.Category.Remove(categoryToRemove);

                    db.SaveChanges();

                    return categoryToRemove;
                }

                return null;
            }
        }
    }
}
