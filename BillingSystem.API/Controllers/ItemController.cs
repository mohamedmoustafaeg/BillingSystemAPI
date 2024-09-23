using Billing_System.BuissnessLogic.DTO.Item;
using Billing_System.BuissnessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost]
        public IActionResult AddItem(ItemToAddDto item)
        {
            if (item == null)
                return BadRequest("item cant be null");

            if (ModelState.IsValid)
            {
                try
                {
                    _itemService.Add(item);
                    return Ok(item);
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
            var items = _itemService.GetAll();
            if (items == null)
                return NotFound();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            try
            {
                var client = _itemService.GetById(id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}