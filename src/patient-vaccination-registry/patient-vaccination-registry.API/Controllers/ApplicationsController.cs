using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.API.DATA;
using patient_vaccination_registry.API.Models.Dtos;
using patient_vaccination_registry.Domain.Entities;


namespace patient_vaccination_registry.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApplicationsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // GET: api/applications
        public ActionResult<IEnumerable<Application>> GetAll()
        {
            var applications = _context.Applications.ToList();
            return Ok(applications);
        }

        [HttpGet("{id}")] // GET: api/applications/5
        public ActionResult<Application> GetById(int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.Id == id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        [HttpPost] // POST: api/applications
        public ActionResult<int> Create(CreateApplicationDto request)
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

            var application = new Application
            {
                PersonId = request.PersonId,
                VaccineId = request.VaccineId,
                DriveId = request.DriveId,
                ApplicationDate = request.ApplicationDate,
                DoseNumber = request.DoseNumber
            };

            _context.Applications.Add(application);
            _context.SaveChanges();
            return Ok(new { id = application.Id });
        }

        [HttpPut("{id}")] // PUT: api/applications/5
        public IActionResult Update(int id, UpdateApplicationDto request)
        {
            var existing = _context.Applications.FirstOrDefault(a => a.Id == id);
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

            _context.Applications.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/applications/5
        public IActionResult Delete(int id)
        {
            var existing = _context.Applications.FirstOrDefault(a => a.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(existing);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
