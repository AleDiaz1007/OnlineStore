using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Models;

namespace OnlineStore.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        // Endpoint to get all products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> getProducts()
        {
            var products = _service.getProducts();

            if (products == null)
            {
                return NotFound("There's no products stored");
            }

            return products;
        }

        // Endpoint to get one specific product
        [HttpGet ("{id}")]
        public ActionResult<Product> getProduct(int id)
        {
            var selectedProduct = _service.getProduct(id);

            if(selectedProduct == null)
            {
                return NotFound("Selected product not found");
            }

            return selectedProduct;
        }

        // Endpoitn to create a product
        [HttpPost ("create")]
        public ActionResult<Product> createProduct(Product product)
        {
            var createdProduct =  _service.createProduct(product);

            if(createdProduct == null)
            {
                return NotFound("There was a problem with the product creation, " +
                    "it could be the categoryID or userID");
            }

            return createdProduct;
        }

        // Endpoint to update a product
        [HttpPut ("{id}/update")]
        public ActionResult<Product> updateProduct(int id, Product product)
        {
            var updatedProduct = _service.updateProduct(id, product);

            if(updatedProduct == null)
            {
                return NotFound("Selected product not found");
            }

            return updatedProduct;
        }

        // Endpoint to delete a product
        [HttpDelete ("{id}/delete")]
        public ActionResult<Product> deleteProduct(int id)
        {
            return _service.deleteProduct(id);
        }
    }
}
