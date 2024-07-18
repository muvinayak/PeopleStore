using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleStore.Server.Models;
using PeopleStore.Server.Services;
using System.Security.Claims;

namespace PeopleStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productService;

        public ProductsController(ProductsService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpGet("GetProductsByCatgory/{categoryId}")]
        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            var products = _productService.GetProductsByCategory(categoryId);

            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(long id)
        {
            var product = _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutProduct(long id, Product newProduct)
        {
            if (id != newProduct.Id)
            {
                return BadRequest();
            }

            var product = _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            try
            {
                _productService.UpdateProduct(newProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public IActionResult PostProduct(Product newProduct)
        {
            newProduct.OwnerId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            
            var product = _productService.Create(newProduct);

            return CreatedAtAction(nameof(PostProduct), new { id = product!.Id }, product);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteProduct(long id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(product);

            return NoContent();
        }
    }
}
