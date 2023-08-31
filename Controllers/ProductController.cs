using Microsoft.AspNetCore.Mvc;
using Web_ShopRozkov.Data.ApplicationDbContext;
using Web_ShopRozkov.Models;

namespace Web_ShopRozkov.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Product> GetProducts()
        {
            var Products = _context.Products.ToList();
            return Products;
        }

        [HttpPost]
        public List<Product> PostProducts([FromBody] Product Products)
        {
            _context.Products.Add(Products);
            _context.SaveChanges();
            return _context.Products.ToList();
        }

        [HttpDelete("/deleteProduct2/{id}")]
        public IActionResult DeleteProduct2(int id)
        {
            var Products = _context.Products.Find(id);

            if (Products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(Products);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProducts(int id)
        {
            var Products = _context.Products.Find(id);

            if (Products == null)
            {
                return NotFound();
            }

            return Products;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Product>> PutProducts(int id, [FromBody] Product updatedProducts)
        {
            var Products = _context.Products.Find(id);

            if (Products == null)
            {
                return NotFound();
            }

            Products.Name = updatedProducts.Name;
            Products.Price = updatedProducts.Price;
            Products.Image = updatedProducts.Image;
            Products.Active = updatedProducts.Active;
            Products.Stock = updatedProducts.Stock;
            Products.CategoryId = updatedProducts.CategoryId;


            _context.Products.Update(Products);
            _context.SaveChanges();

            return Ok(_context.Products);
        }
    }
}
