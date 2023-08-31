using Microsoft.AspNetCore.Mvc;
using Web_ShopRozkov.Data.ApplicationDbContext;
using Web_ShopRozkov.Models;

namespace Web_ShopRozkov.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Person> GetPersons()
        {
            var Persons = _context.Persons.ToList();
            return Persons;
        }

        [HttpPost]
        public List<Person> PostPersons([FromBody] Person Persons)
        {
            _context.Persons.Add(Persons);
            _context.SaveChanges();
            return _context.Persons.ToList();
        }

        [HttpDelete("/deletePerson2/{id}")]
        public IActionResult DeletePerson2(int id)
        {
            var Persons = _context.Persons.Find(id);

            if (Persons == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(Persons);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersons(int id)
        {
            var Persons = _context.Persons.Find(id);

            if (Persons == null)
            {
                return NotFound();
            }

            return Persons;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Person>> PutPersons(int id, [FromBody] Person updatedPersons)
        {
            var Persons = _context.Persons.Find(id);

            if (Persons == null)
            {
                return NotFound();
            }

            Persons.PersonCode = updatedPersons.PersonCode;
            Persons.FirstName = updatedPersons.FirstName;
            Persons.LastName = updatedPersons.LastName;
            Persons.Phone = updatedPersons.Phone;
            Persons.Address = updatedPersons.Address;
            Persons.Password = updatedPersons.Password;
            Persons.Admin = updatedPersons.Admin;


            _context.Persons.Update(Persons);
            _context.SaveChanges();

            return Ok(_context.Persons);
        }
    }
}
