using Microsoft.AspNetCore.Mvc;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Contracts
{
    public interface IProductRepository
    {

        public ActionResult<IEnumerable<Product>> getProducts();

        public ActionResult<Product> getProduct(int id);

        public ActionResult<Product> createProduct(Product product);

        public ActionResult<Product> updateProduct(int id, Product product);

        public ActionResult<Product> deleteProduct(int id);
    }
}
