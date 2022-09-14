using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Contracts;
using OnlineStore.DAL.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        // Endpoint to get all products
        [HttpGet ("/getProducts")]
        public ActionResult<IEnumerable<Product>> getProducts()
        {
            var products = _service.getProducts();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // Endpoint to get one specific product
        [HttpGet ("/getProduct/{id}")]
        public ActionResult<Product> getProduct(int id)
        {
            return _service.getProduct(id);
        }

        // Endpoitn to create a product
        [HttpPost ("/createProduct")]
        public ActionResult<Product> createProduct(Product product)
        {
            return _service.createProduct(product);
        }

        // Endpoint to update a product
        [HttpPut ("/updateProduct/{id}")]
        public ActionResult<Product> updateProduct(int id, Product product)
        {
            return _service.updateProduct(id, product);
        }

        // Endpoint to delete a product
        [HttpDelete ("/deleteProduct/{id}")]
        public ActionResult<Product> deleteProduct(int id)
        {
            return _service.deleteProduct(id);
        }

        //public IActionResult Update(string id, Contact contact)
        //{
        //    var contactToUpdate = _contacts.Get(id);

        //    if (contactToUpdate == null)
        //    {
        //        return NotFound();
        //    }

        //    _contacts.Update(contact);

        //    return Ok();
        //}
    }
}
