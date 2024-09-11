using Billing_System.BuissnessLogic.DTO.Type;
using Billing_System.BuissnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {

        private readonly ITypeService _service;
        public TypeController(ITypeService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult AddType(TypeToAddDTO type)
        {
            if (type == null)
                return BadRequest("Type cant be null");
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Add(type);
                    return Ok(type);
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
            var types = _service.GetAll();
            if (types.Count() == 0)
                return NotFound();
            return Ok(types);
        }
        [HttpGet("{id}")]
        public IActionResult GetTypeById(int id)
        {
            try
            {
                var type = _service.GetById(id);
                return Ok(type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteType(int id)
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
        public IActionResult EditType(int id, [FromBody] TypeToAddDTO type)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _service.Edit(id, type);
                return Ok("Client updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

