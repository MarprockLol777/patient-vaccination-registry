using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.Application.Models.Dtos;
using patient_vaccination_registry.Application.Services;

namespace patient_vaccination_registry.API.Controllers
{
    [ApiController]
    [Route("api/drives")]
    public class DrivesController : ControllerBase
    {
        private readonly DriveService _driveService;

        public DrivesController(DriveService driveService)
        {
            _driveService = driveService;
        }

        [HttpGet] // GET: api/drives
        public ActionResult GetAll()
        {
            var drives = _driveService.GetAll();
            return Ok(drives);
        }

        [HttpGet("{id}")] // GET: api/drives/5
        public ActionResult GetById(int id)
        {
            var drive = _driveService.GetById(id);
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
            var id = _driveService.Create(request);
            return Ok(new { id });
        }

        [HttpPut("{id}")] // PUT: api/drives/5
        public IActionResult Update(int id, UpdateDriveDto request)
        {
            var result = _driveService.Update(id, request);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/drives/5
        public IActionResult Delete(int id)
        {
            var result = _driveService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}