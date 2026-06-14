using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.DATA;
using patient_vaccination_registry.API.Models.Dtos;
using patient_vaccination_registry.API.Models.Entities;

namespace patient_vaccination_registry.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VaccinesController : ControllerBase 
    {
        private readonly DataContext _context;

        public VaccinesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // GET: api/vaccines
        public ActionResult<IEnumerable<Vaccine>> GetAll()
        {
            var vaccines = _context.Vaccines.ToList();
            return Ok(vaccines);
        }

        [HttpGet("{id}")] // GET: api/vaccines/5
        public ActionResult<Vaccine> GetById(int id)
        {
            var vaccine = _context.Vaccines.FirstOrDefault(v => v.Id == id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return Ok(vaccine);
        }

        [HttpPost] // POST: api/vaccines
        public ActionResult<int> Create(CreateVaccineDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of vaccine is required.");
            }

            var vaccine = new Vaccine
            {
                Name = request.Name,
                Manufacturer = request.Manufacturer,
                Batch = request.Batch,
                RequiredDoses = request.RequiredDoses,
                IsActive = true
            };

            _context.Vaccines.Add(vaccine);
            _context.SaveChanges();
            return Ok(new { id = vaccine.Id });
        }

        [HttpPut("{id}")] // PUT: api/vaccines/5
        public IActionResult Update(int id, UpdateVaccineDto request)
        {
            var existing = _context.Vaccines.FirstOrDefault(v => v.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = request.Name;
            existing.Manufacturer = request.Manufacturer;
            existing.Batch = request.Batch;
            existing.RequiredDoses = request.RequiredDoses;
            existing.IsActive = request.IsActive;

            _context.Vaccines.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/vaccines/5
        public IActionResult Delete(int id)
        {
            var existing = _context.Vaccines.FirstOrDefault(v => v.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            _context.Vaccines.Remove(existing);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
