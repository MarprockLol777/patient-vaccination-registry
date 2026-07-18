using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.DATA;
using patient_vaccination_registry.API.Models.Dtos;
using patient_vaccination_registry.Domain.Entities;

namespace patient_vaccination_registry.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController: ControllerBase
    {
        private readonly DataContext _context;

        public PersonsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // GET: api/persons
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var persons = _context.Persons.ToList();
            return Ok(persons);
        }

        [HttpGet("{id}")] // GET: api/persons/5
        public ActionResult<Person> GetById(int id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost] // POST: api/persons
        public ActionResult<int> Create(CreatePersonDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of person is required.");
            }

            var person = new Person
            {
                Name = request.Name,
                IdNumber = request.IdNumber,
                BirthDate = request.BirthDate,
                IsActive = true
            };

            _context.Persons.Add(person);
            _context.SaveChanges();
            return Ok(new { id = person.Id });
        }

        [HttpPut("{id}")] // PUT: api/persons/5
        public IActionResult Update(int id, UpdatePersonDto request)
        {
            var existing = _context.Persons.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = request.Name;
            existing.IdNumber = request.IdNumber;
            existing.BirthDate = request.BirthDate;
            existing.IsActive = request.IsActive;

            _context.Persons.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/persons/5
        public IActionResult Delete(int id)
        {
            var existing = _context.Persons.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(existing);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
