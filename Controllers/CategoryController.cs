using Microsoft.AspNetCore.Mvc;
using Web_ShopRozkov.Data.ApplicationDbContext;
using Web_ShopRozkov.Models;

namespace Web_ShopRozkov.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Category> GetCategories()
        {
            var Categories = _context.Categories.ToList();
            return Categories;
        }

        [HttpPost]
        public List<Category> PostCategories([FromBody] Category Categories)
        {
            _context.Categories.Add(Categories);
            _context.SaveChanges();
            return _context.Categories.ToList();
        }


        [HttpDelete("/deleteCategory2/{id}")]
        public IActionResult DeleteCategories2(int id)
        {
            var Categories = _context.Categories.Find(id);

            if (Categories == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(Categories);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategories(int id)
        {
            var Categories = _context.Categories.Find(id);

            if (Categories == null)
            {
                return NotFound();
            }

            return Categories;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Category>> PutCategories(int id, [FromBody] Category updatedCategories)
        {
            var Categories = _context.Categories.Find(id);

            if (Categories == null)
            {
                return NotFound();
            }

            Categories.Name = updatedCategories.Name;

            _context.Categories.Update(Categories);
            _context.SaveChanges();

            return Ok(_context.Categories);
        }
    }
}
