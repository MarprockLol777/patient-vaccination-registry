using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.Models.Dtos;
using patient_vaccination_registry.API.Models.Entities;

namespace patient_vaccination_registry.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DrivesController : ControllerBase
    {
        private static readonly List<Drive> _drives = new List<Drive>
        {
            new Drive { Id = 1, Name = "Central Park Vaccination Day", Date = new DateTime(2026, 6, 20), Location = "Santo Domingo", IsActive = true },
            new Drive { Id = 2, Name = "Santiago Community Drive", Date = new DateTime(2026, 6, 25), Location = "Santiago de los Caballeros", IsActive = true },
            new Drive { Id = 3, Name = "Puerto Plata Outreach", Date = new DateTime(2026, 7, 1), Location = "Puerto Plata", IsActive = true }
        };

        [HttpGet] // GET: api/drives
        public ActionResult<IEnumerable<Drive>> GetAll()
        {
            var drives = _drives.ToList();
            return Ok(drives);
        }

        [HttpGet("{id}")] // GET: api/drives/5
        public ActionResult<Drive> GetById(int id)
        {
            var drive = _drives.FirstOrDefault(d => d.Id == id);
            if (drive == null)
            {
                return NotFound();
            }
            return Ok(drive);
        }

        [HttpPost] // POST: api/drives
        public ActionResult Create(CreateDriveDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of drive is required.");
            }

            var newId = _drives.Any() ? _drives.Max(d => d.Id) + 1 : 1;

            var drive = new Drive
            {
                Id = newId,
                Name = request.Name,
                Date = request.Date,
                Location = request.Location,
                IsActive = true
            };

            _drives.Add(drive);
            return Ok(new
            {
                name = drive.Name,
                date = drive.Date,
                location = drive.Location
            });
        }

        [HttpPut("{id}")] // PUT: api/drives/5
        public IActionResult Update(int id, UpdateDriveDto request)
        {
            var existing = _drives.FirstOrDefault(d => d.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = request.Name;
            existing.Date = request.Date;
            existing.Location = request.Location;
            existing.IsActive = request.IsActive;

            return Ok(new
            {
                name = existing.Name,
                date = existing.Date,
                location = existing.Location,
                isActive = existing.IsActive
            });
        }

        [HttpDelete("{id}")] // DELETE: api/drives/5
        public IActionResult Delete(int id)
        {
            var existing = _drives.FirstOrDefault(d => d.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            _drives.Remove(existing);
            return NoContent();
        }
    }
}
