using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.Models.Entities;

namespace patient_vaccination_registry.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController: ControllerBase
    {
        private static readonly List<Person> _persons = new List<Person>
        {
            new Person { Id = 1, Name = "Juan Perez", IdNumber = "001-1234567-8", BirthDate = new DateTime(1990, 5, 12), IsActive = true },
            new Person { Id = 2, Name = "Maria Gomez", IdNumber = "001-9876543-2", BirthDate = new DateTime(1985, 11, 30), IsActive = true },
            new Person { Id = 3, Name = "Carlos Diaz", IdNumber = "001-4567890-1", BirthDate = new DateTime(2000, 2, 20), IsActive = true }
        };

        [HttpGet] // GET: api/persons
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return Ok(_persons);
        }

        [HttpGet("{id}")] // GET: api/persons/5
        public ActionResult<Person> GetById(int id)
        {
            var person = _persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost] // POST: api/persons
        public ActionResult<Person> Create(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.Name))
            {
                return BadRequest("Name of person is required.");
            }

            int newId = _persons.Any() ? _persons.Max(p => p.Id) + 1 : 1;
            person.Id = newId;
            person.IsActive = true;

            _persons.Add(person);
            return CreatedAtAction(
                nameof(GetById),
                new { id = person.Id },
                person
            );
        }

        [HttpPut("{id}")] // PUT: api/persons/5
        public IActionResult Update(int id, Person person)
        {
            var existing = _persons.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = person.Name;
            existing.IdNumber = person.IdNumber;
            existing.BirthDate = person.BirthDate;
            existing.IsActive = person.IsActive;

            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/persons/5
        public IActionResult Delete(int id)
        {
            var existing = _persons.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            _persons.Remove(existing);
            return NoContent();
        }
    }
}
