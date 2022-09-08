using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services
{
    public class ProductService : IProductService
    {

        readonly IProductRepository _productRepository; 

        public ProductService(IProductRepository repo)
        {
            _productRepository = repo;
        }

        public ActionResult<IEnumerable<Product>> getProducts()
        {
            return _productRepository.getProducts();
        }

        public ActionResult<Product> getProduct(int id)
        {
            return _productRepository.getProduct(id);
        }

        public ActionResult<Product> createProduct(Product product)
        {
            return _productRepository.createProduct(product);
        }

        public ActionResult<Product> updateProduct(int id, Product product)
        {
            return _productRepository.updateProduct(id, product);
        }

        public ActionResult<Product> deleteProduct(int id)
        {
            return _productRepository.deleteProduct(id);
        }
    }
}
