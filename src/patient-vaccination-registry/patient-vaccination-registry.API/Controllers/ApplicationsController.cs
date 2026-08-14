using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.Application.Models.Dtos;
using patient_vaccination_registry.Application.Services;

namespace patient_vaccination_registry.API.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        public ApplicationsController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet] // GET: api/applications
        public ActionResult GetAll()
        {
            var applications = _applicationService.GetAll();
            return Ok(applications);
        }

        [HttpGet("{id}")] // GET: api/applications/5
        public ActionResult GetById(int id)
        {
            var application = _applicationService.GetById(id);
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
            var id = _applicationService.Create(request);
            return Ok(new { id });
        }

        [HttpPut("{id}")] // PUT: api/applications/5
        public IActionResult Update(int id, UpdateApplicationDto request)
        {
            var result = _applicationService.Update(id, request);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/applications/5
        public IActionResult Delete(int id)
        {
            var result = _applicationService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}