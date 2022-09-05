using Microsoft.AspNetCore.Mvc;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Contracts
{
    public  interface ICategoryService
    {

        public ActionResult<IEnumerable<Category>> getCategories();

        public Category getOneCategory(int id);

        public ActionResult<Category> updateCategory(int id, Category category);

        public ActionResult<Category> createCategory(Category category);

        public ActionResult<Category> deleteCategory(int id);
    }
}
