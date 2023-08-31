using Microsoft.AspNetCore.Mvc;
using Web_ShopRozkov.Data.ApplicationDbContext;
using Web_ShopRozkov.Models;

namespace Web_ShopRozkov.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Order> GetOrders()
        {
            var Orders = _context.Orders.ToList();
            return Orders;
        }

        [HttpPost]
        public List<Order> PostOrders([FromBody] Order Orders)
        {
            _context.Orders.Add(Orders);
            _context.SaveChanges();
            return _context.Orders.ToList();
        }

        [HttpDelete("/deleteOrder2/{id}")]
        public IActionResult DeleteOrder2(int id)
        {
            var Orders = _context.Orders.Find(id);

            if (Orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(Orders);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrders(int id)
        {
            var Orders = _context.Orders.Find(id);

            if (Orders == null)
            {
                return NotFound();
            }

            return Orders;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Order>> PutOrders(int id, [FromBody] Order updatedOrders)
        {
            var Orders = _context.Orders.Find(id);

            if (Orders == null)
            {
                return NotFound();
            }

            Orders.created = updatedOrders.created;
            Orders.TotalSum = updatedOrders.TotalSum;
            Orders.Paid = updatedOrders.Paid;
            Orders.CartProduct = updatedOrders.CartProduct;
            Orders.PersonId = updatedOrders.PersonId;


            _context.Orders.Update(Orders);
            _context.SaveChanges();

            return Ok(_context.Orders);
        }
    }
}
