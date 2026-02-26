using BudgetAPI.Data;
using BudgetAPI.Interfaces.Repository;
using BudgetAPI.Models;
using BudgetAPI.Repositories;
using BudgetAPI.Requests;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAll()
        {
            var items = await _item.ToListAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateItemDTO dto)
        {
            var item = new Item
            {
                Name = dto.Name,
                Price = dto.Price
            };

            await _item.AddAsync(item);
            await _item.SaveChangesAsync();

            return Ok();
        }
    }
}
