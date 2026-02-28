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
        private readonly IItemRepository _item;

        public ItemController(IItemRepository item)
        {
            _item = item;
        }

        [HttpGet]
        public async Task<ActionResult<Item[]>> GetAll()
        {
            var items = await _item.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var item = await _item.GetByIdAsync(id);

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

            await _item.AddAsync(item);
            await _item.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] Item item)
        {
            var item2 = await _item.GetByIdAsync(id);

            if (item2 == null)
                return NotFound();

            if (item.Id != id)
                return BadRequest();

            _item.Update(item);
            await _item.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _item.GetByIdAsync(id);

            // not found
            if (item == null)
                return NotFound();

            _item.Remove(item);
            await _item.SaveChangesAsync();

            return NoContent();
        }
    }
}
