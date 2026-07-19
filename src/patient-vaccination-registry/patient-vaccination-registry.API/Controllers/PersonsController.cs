using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.Application.Models.Dtos;
using patient_vaccination_registry.Application.Services;

namespace patient_vaccination_registry.API.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonsController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet] // GET: api/persons
        public ActionResult GetAll()
        {
            var persons = _personService.GetAll();
            return Ok(persons);
        }

        [HttpGet("{id}")] // GET: api/persons/5
        public ActionResult GetById(int id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost] // POST: api/persons
        public ActionResult Create(CreatePersonDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of person is required.");
            }
            var id = _personService.Create(request);
            return Ok(new { id });
        }

        [HttpPut("{id}")] // PUT: api/persons/5
        public IActionResult Update(int id, UpdatePersonDto request)
        {
            var result = _personService.Update(id, request);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/persons/5
        public IActionResult Delete(int id)
        {
            var result = _personService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}