using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.Models.Entities;


namespace patient_vaccination_registry.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private static readonly List<Application> _applications = new List<Application>
        {
            new Application { Id = 1, PersonId = 1, VaccineId = 1, DriveId = 1, ApplicationDate = new DateTime(2026, 6, 20), DoseNumber = 1 },
            new Application { Id = 2, PersonId = 2, VaccineId = 2, DriveId = 1, ApplicationDate = new DateTime(2026, 6, 20), DoseNumber = 1 },
            new Application { Id = 3, PersonId = 1, VaccineId = 1, DriveId = 2, ApplicationDate = new DateTime(2026, 6, 25), DoseNumber = 2 }
        };

        [HttpGet] // GET: api/applications
        public ActionResult<IEnumerable<Application>> GetAll()
        {
            return Ok(_applications);
        }

        [HttpGet("{id}")] // GET: api/applications/5
        public ActionResult<Application> GetById(int id)
        {
            var application = _applications.FirstOrDefault(a => a.Id == id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        [HttpPost] // POST: api/applications
        public ActionResult<Application> Create(Application application)
        {
            if (application.PersonId <= 0)
            {
                return BadRequest("PersonId must be provided and positive.");
            }
            if (application.VaccineId <= 0)
            {
                return BadRequest("VaccineId must be provided and positive.");
            }
            if (application.DriveId <= 0)
            {
                return BadRequest("DriveId must be provided and positive.");
            }

            int newId = _applications.Any() ? _applications.Max(a => a.Id) + 1 : 1;
            application.Id = newId;

            _applications.Add(application);
            return CreatedAtAction(
                nameof(GetById),
                new { id = application.Id },
                application
            );
        }

        [HttpPut("{id}")] // PUT: api/applications/5
        public IActionResult Update(int id, Application application)
        {
            var existing = _applications.FirstOrDefault(a => a.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.PersonId = application.PersonId;
            existing.VaccineId = application.VaccineId;
            existing.DriveId = application.DriveId;
            existing.ApplicationDate = application.ApplicationDate;
            existing.DoseNumber = application.DoseNumber;

            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/applications/5
        public IActionResult Delete(int id)
        {
            var existing = _applications.FirstOrDefault(a => a.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            _applications.Remove(existing);
            return NoContent();
        }
    }
}
