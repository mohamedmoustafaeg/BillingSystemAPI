using Billing_System.BuissnessLogic.DTO.Invoice;
using Billing_System.BuissnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;
        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddInvoice(InvoiceToAddDTO invoice)
        {

            if (invoice == null)
                return BadRequest("invoice cant be null");
            if (ModelState.IsValid)
            {
                try
                {
                    _service.AddInvoice(invoice);
                    return Ok(invoice);
                }
                catch (Exception ex)
                {
                    ModelState.TryAddModelError("error", ex.Message);

                }

            }
            return BadRequest(ModelState);

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var invoices = _service.GetAllInvoices();
            if (invoices == null)
                return NotFound();
            return Ok(invoices);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteInvoice(id);
            return NoContent();
        }
        [HttpGet("report")]
        public IActionResult GetInvoicesBetweentDates(DateTime From, DateTime To)
        {
            var invoices = _service.GetInvoicesBetweenDates(From, To);
            if (invoices == null)
                return NotFound();
            return Ok(invoices);
        }
        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            var invoice = _service.GetInvoiceById(id);
            if (invoice == null)
                return NotFound();
            return Ok(invoice);
        }
    }
}
