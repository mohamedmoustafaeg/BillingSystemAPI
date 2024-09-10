using Billing_System.BuissnessLogic.DTO.Client;
using Billing_System.BuissnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;
        public ClientController(IClientService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult AddClient(ClientToAddDTO client)
        {
            if (client == null)
                return BadRequest("Client cant be null");
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Add(client);
                    return Ok(client);
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
            var clients = _service.GetAll();
            if (clients == null)
                return NotFound();
            return Ok(clients);
        }
        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            try
            {
                var client = _service.GetById(id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
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
        public IActionResult EditClient(int id, [FromBody] ClientToAddDTO client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _service.Edit(id, client);
                return Ok("Client updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
