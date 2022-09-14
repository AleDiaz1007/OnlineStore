using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Context;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly DbContextOptions<OnlineStoreContext> _optionsBuilder;

        public ProductRepository(DbContextOptions<OnlineStoreContext> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public ActionResult<IEnumerable<Product>> getProducts()
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                List<Product> products = db.Product.Select(x => x).ToList();

                if(products.Any())
                {
                    return products;
                }

                return null; 
            }
        }

        public ActionResult<Product> getProduct(int id)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Product product = db.Product.FirstOrDefault(x => x.Id == id);

                if(product != null)
                {
                    return product;
                }

                return null;

            }
        }

        public ActionResult<Product> createProduct(Product product)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Users validateUser = db.Users.FirstOrDefault(x => x.id == product.UserID);

                Category validateCategory = db.Category.FirstOrDefault(x => x.Id == product.CategoryID);

                if(validateUser != null && validateCategory != null)
                {
                    db.Product.Add(product);

                    db.SaveChanges();

                    return product;
                }

                return null;
            }
        }

        public ActionResult<Product> updateProduct(int id, Product product)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Product selectedProduct = db.Product.FirstOrDefault(x => x.Id == id);

                if(selectedProduct != null)
                {
                    selectedProduct.Name = product.Name;
                    selectedProduct.Price = product.Price;
                    selectedProduct.Quantity = product.Quantity;
                    selectedProduct.Description = product.Description;
                    selectedProduct.UserID = product.UserID;
                    selectedProduct.CategoryID = product.CategoryID;

                    db.SaveChanges();

                    return selectedProduct;

                }

                return null;
            }
        }

        public ActionResult<Product> deleteProduct(int id)
        {
            using(var db = new OnlineStoreContext(_optionsBuilder))
            {
                Product productToDelete = db.Product.FirstOrDefault(x => x.Id == id);

                if(productToDelete != null)
                {
                    db.Product.Remove(productToDelete);

                    db.SaveChanges();

                    return productToDelete;
                }

                return null;

            }
        }
    }            
}
