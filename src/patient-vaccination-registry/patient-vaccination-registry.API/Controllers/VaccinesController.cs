using Microsoft.AspNetCore.Mvc;
using patient_vaccination_registry.Application.Models.Dtos;
using patient_vaccination_registry.Application.Services;

namespace patient_vaccination_registry.API.Controllers
{
    [ApiController]
    [Route("api/vaccines")]
    public class VaccinesController : ControllerBase
    {
        private readonly VaccineService _vaccineService;

        public VaccinesController(VaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }

        [HttpGet] // GET: api/vaccines
        public ActionResult GetAll()
        {
            var vaccines = _vaccineService.GetAll();
            return Ok(vaccines);
        }

        [HttpGet("{id}")] // GET: api/vaccines/5
        public ActionResult GetById(int id)
        {
            var vaccine = _vaccineService.GetById(id);
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
            var id = _vaccineService.Create(request);
            return Ok(new { id });
        }

        [HttpPut("{id}")] // PUT: api/vaccines/5
        public IActionResult Update(int id, UpdateVaccineDto request)
        {
            var result = _vaccineService.Update(id, request);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/vaccines/5
        public IActionResult Delete(int id)
        {
            var result = _vaccineService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}