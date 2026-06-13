using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.Models.Dtos;
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
            var applications = _applications.ToList();
            return Ok(applications);
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
        public ActionResult Create(CreateApplicationDto request)
        {
            if (request.PersonId <= 0)
            {
                return BadRequest("PersonId must be provided and positive.");
            }
            if (request.VaccineId <= 0)
            {
                return BadRequest("VaccineId must be provided and positive.");
            }
            if (request.DriveId <= 0)
            {
                return BadRequest("DriveId must be provided and positive.");
            }

            var newId = _applications.Any() ? _applications.Max(a => a.Id) + 1 : 1;

            var application = new Application
            {
                Id = newId,
                PersonId = request.PersonId,
                VaccineId = request.VaccineId,
                DriveId = request.DriveId,
                ApplicationDate = request.ApplicationDate,
                DoseNumber = request.DoseNumber
            };

            _applications.Add(application);
            return Ok(new
            {
                personId = application.PersonId,
                vaccineId = application.VaccineId,
                driveId = application.DriveId,
                applicationDate = application.ApplicationDate,
                doseNumber = application.DoseNumber
            });
        }

        [HttpPut("{id}")] // PUT: api/applications/5
        public IActionResult Update(int id, UpdateApplicationDto request)
        {
            var existing = _applications.FirstOrDefault(a => a.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            if (request.PersonId <= 0)
            {
                return BadRequest("PersonId must be provided and positive.");
            }
            if (request.VaccineId <= 0)
            {
                return BadRequest("VaccineId must be provided and positive.");
            }
            if (request.DriveId <= 0)
            {
                return BadRequest("DriveId must be provided and positive.");
            }

            existing.PersonId = request.PersonId;
            existing.VaccineId = request.VaccineId;
            existing.DriveId = request.DriveId;
            existing.ApplicationDate = request.ApplicationDate;
            existing.DoseNumber = request.DoseNumber;

            return Ok(new
            {
                personId = existing.PersonId,
                vaccineId = existing.VaccineId,
                driveId = existing.DriveId,
                applicationDate = existing.ApplicationDate,
                doseNumber = existing.DoseNumber
            });
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
