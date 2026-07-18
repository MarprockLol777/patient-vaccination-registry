using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.Models.Dtos;
using patient_vaccination_registry.Domain.Entities;
using patient_vaccination_registry.Infrastructure.Context;

namespace patient_vaccination_registry.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DrivesController : ControllerBase
    {
        private readonly DataContext _context;

        public DrivesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // GET: api/drives
        public ActionResult<IEnumerable<Drive>> GetAll()
        {
            var drives = _context.Drives.ToList();
            return Ok(drives);
        }

        [HttpGet("{id}")] // GET: api/drives/5
        public ActionResult<Drive> GetById(int id)
        {
            var drive = _context.Drives.FirstOrDefault(d => d.Id == id);
            if (drive == null)
            {
                return NotFound();
            }
            return Ok(drive);
        }

        [HttpPost] // POST: api/drives
        public ActionResult<int> Create(CreateDriveDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of drive is required.");
            }

            var drive = new Drive
            {
                Name = request.Name,
                Date = request.Date,
                Location = request.Location,
                IsActive = true
            };

            _context.Drives.Add(drive);
            _context.SaveChanges();
            return Ok(new { id = drive.Id });
        }

        [HttpPut("{id}")] // PUT: api/drives/5
        public IActionResult Update(int id, UpdateDriveDto request)
        {
            var existing = _context.Drives.FirstOrDefault(d => d.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = request.Name;
            existing.Date = request.Date;
            existing.Location = request.Location;
            existing.IsActive = request.IsActive;

            _context.Drives.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/drives/5
        public IActionResult Delete(int id)
        {
            var existing = _context.Drives.FirstOrDefault(d => d.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            _context.Drives.Remove(existing);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
