using Billing_System.BuissnessLogic.DTO.Company;
using Billing_System.BuissnessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        public CompanyController(ICompanyService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult AddCompany(CompanyToAddDTO company)
        {
            if (company == null)
                return BadRequest("Company Is Null");
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Add(company);
                    return Ok(company);
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
            var companies = _service.GetAll();
            if (companies == null)
                return NotFound("No Companies in DataBase");
            return Ok(companies);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _service.GetById(id);
            if (company == null)
                return NotFound();
            return Ok(company);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeletebyId(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] CompanyToAddDTO companyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _service.Edit(id, companyDto);
                return Ok(new { message = "Company updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
