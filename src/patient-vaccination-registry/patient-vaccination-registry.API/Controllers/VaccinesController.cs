using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.Models.Dtos;
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
            var vaccines = _vaccines.ToList();
            return Ok(vaccines);
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
        public ActionResult Create(CreateVaccineDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of vaccine is required.");
            }

            var newId = _vaccines.Any() ? _vaccines.Max(v => v.Id) + 1 : 1;

            var vaccine = new Vaccine
            {
                Id = newId,
                Name = request.Name,
                Manufacturer = request.Manufacturer,
                Batch = request.Batch,
                RequiredDoses = request.RequiredDoses,
                IsActive = true
            };

            _vaccines.Add(vaccine);
            return Ok(new
            {
                name = vaccine.Name,
                manufacturer = vaccine.Manufacturer,
                batch = vaccine.Batch,
                requiredDoses = vaccine.RequiredDoses
            });
        }

        [HttpPut("{id}")] // PUT: api/vaccines/5
        public IActionResult Update(int id, UpdateVaccineDto request)
        {
            var existing = _vaccines.FirstOrDefault(v => v.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = request.Name;
            existing.Manufacturer = request.Manufacturer;
            existing.Batch = request.Batch;
            existing.RequiredDoses = request.RequiredDoses;
            existing.IsActive = request.IsActive;

            return Ok(new
            {
                name = existing.Name,
                manufacturer = existing.Manufacturer,
                batch = existing.Batch,
                requiredDoses = existing.RequiredDoses,
                isActive = existing.IsActive
            });
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
