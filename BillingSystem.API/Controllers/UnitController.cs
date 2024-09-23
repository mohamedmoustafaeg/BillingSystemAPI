using Billing_System.BuissnessLogic.DTO.Unit;
using Billing_System.BuissnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _service;

        public UnitController(IUnitService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddUnit([FromBody] UnitToAddDTO unit)
        {
            if (unit == null)
                return BadRequest("Unit cannot be null");

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Add(unit);
                    return Ok(unit);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var units = _service.GetAll();
            if (!units.Any())
                return NotFound();
            return Ok(units);
        }

        [HttpGet("{id}")]
        public IActionResult GetUnitById(int id)
        {
            try
            {
                var unit = _service.GetById(id);
                return Ok(unit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUnit(int id)
        {
            try
            {
                _service.DeleteById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditUnit(int id, [FromBody] UnitToAddDTO unit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _service.Edit(id, unit);
                return Ok(new { message = "Unit updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
