using Microsoft.AspNetCore.Mvc;
using Web_ShopRozkov.Data.ApplicationDbContext;
using Web_ShopRozkov.Models;

namespace Web_ShopRozkov.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<CartProduct> GetCartProducts()
        {
            var CartProducts = _context.CartProducts.ToList();
            return CartProducts;
        }

        [HttpPost]
        public List<CartProduct> PostCartProducts([FromBody] CartProduct CartProducts)
        {
            _context.CartProducts.Add(CartProducts);
            _context.SaveChanges();
            return _context.CartProducts.ToList();
        }


        [HttpDelete("/deleteCartProduct2/{id}")]
        public IActionResult DeleteCartProducts2(int id)
        {
            var CartProducts = _context.CartProducts.Find(id);

            if (CartProducts == null)
            {
                return NotFound();
            }

            _context.CartProducts.Remove(CartProducts);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<CartProduct> GetCartProducts(int id)
        {
            var CartProducts = _context.CartProducts.Find(id);

            if (CartProducts == null)
            {
                return NotFound();
            }

            return CartProducts;
        }

        [HttpPut("{id}")]
        public ActionResult<List<CartProduct>> PutCartProducts(int id, [FromBody] CartProduct updatedCartProducts)
        {
            var CartProducts = _context.CartProducts.Find(id);

            if (CartProducts == null)
            {
                return NotFound();
            }

            CartProducts.ProductId = updatedCartProducts.ProductId;
            CartProducts.Quantity = updatedCartProducts.Quantity;

            _context.CartProducts.Update(CartProducts);
            _context.SaveChanges();

            return Ok(_context.CartProducts);
        }
    }
}
