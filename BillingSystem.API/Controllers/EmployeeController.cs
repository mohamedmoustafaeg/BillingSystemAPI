using Billing_System.BuissnessLogic.DTO.Employee;
using Billing_System.BuissnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeToAddDTO employee)
        {
            if (employee == null)
                return BadRequest("Employee cannot be null");

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Add(employee);
                    return Ok(employee);
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
            var employees = _service.GetAll();
            if (employees.Count() == 0)
                return NotFound();

            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _service.GetById(id);
                if (employee == null)
                    return NotFound($"Employee with ID {id} not found.");

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
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
        public IActionResult EditEmployee(int id, [FromBody] EmployeeToAddDTO employee)
        {
            if (employee == null)
                return BadRequest("Employee cannot be null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _service.Edit(id, employee);
                return Ok("Employee updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
