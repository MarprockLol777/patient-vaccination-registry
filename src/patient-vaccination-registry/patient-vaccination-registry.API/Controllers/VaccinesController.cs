using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.Models.Entities;

namespace patient_vaccination_registry.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VaccinesController : ControllerBase 
    {

        private static readonly List<Vaccine> _vaccines = new List<Vaccine>
        {
            new Vaccine { Id = 1, Name = "Pfizer-BioNTech", Manufacturer = "Pfizer", Batch = "PF001", RequiredDoses = 2, IsActive = true },
            new Vaccine { Id = 2, Name = "AstraZeneca", Manufacturer = "AstraZeneca", Batch = "AZ045", RequiredDoses = 2, IsActive = true },
            new Vaccine { Id = 3, Name = "Janssen", Manufacturer = "Johnson & Johnson", Batch = "JN012", RequiredDoses = 1, IsActive = true }
        };

        [HttpGet] // GET: api/vaccines
        public ActionResult<IEnumerable<Vaccine>> GetAll()
        {
            return Ok(_vaccines);
        }

        [HttpGet("{id}")] // GET: api/vaccines/5
        public ActionResult<Vaccine> GetById(int id)
        {
            var vaccine = _vaccines.FirstOrDefault(v => v.Id == id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return Ok(vaccine);
        }

        [HttpPost] // POST: api/vaccines
        public ActionResult<Vaccine> Create(Vaccine vaccine)
        {
            if (string.IsNullOrWhiteSpace(vaccine.Name))
            {
                return BadRequest("Name of vaccine is required.");
            }

            int newId = _vaccines.Any() ? _vaccines.Max(v => v.Id) + 1 : 1;
            vaccine.Id = newId;
            vaccine.IsActive = true;

            _vaccines.Add(vaccine);
            return CreatedAtAction(
                nameof(GetById),
                new { id = vaccine.Id },
                vaccine
            );
        }

        [HttpPut("{id}")] // PUT: api/vaccines/5
        public IActionResult Update(int id, Vaccine vaccine)
        {
            var existing = _vaccines.FirstOrDefault(v => v.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = vaccine.Name;
            existing.Manufacturer = vaccine.Manufacturer;
            existing.Batch = vaccine.Batch;
            existing.RequiredDoses = vaccine.RequiredDoses;
            existing.IsActive = vaccine.IsActive;

            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/vaccines/5
        public IActionResult Delete(int id)
        {
            var existing = _vaccines.FirstOrDefault(v => v.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            _vaccines.Remove(existing);
            return NoContent();
        }
    }
}
