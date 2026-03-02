using BudgetAPI.Interfaces;
using BudgetAPI.Interfaces.Repository;
using BudgetAPI.Models;
using BudgetAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _item;

        public ItemController(IItemService item)
        {
            _item = item;
        }

        [HttpGet]
        public async Task<ActionResult<Item[]>> GetAll()
        {
            var items = await _item.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var item = await _item.GetItemAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemDTO dto)
        {
            var item = new Item
            {
                Name = dto.Name,
                Price = dto.Price
            };

            await _item.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] Item item)
        {
            var item2 = await _item.GetItemAsync(id);

            if (item2 == null)
                return NotFound();

            if (item.Id != id)
                return BadRequest();

            await _item.UpdateItemAsync(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _item.GetItemAsync(id);

            // not found
            if (item == null)
                return NotFound();

            await _item.DeleteItemAsync(id);

            return NoContent();
        }
    }
}
