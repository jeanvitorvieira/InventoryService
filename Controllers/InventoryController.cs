using InventoryService.DTOs;
using InventoryService.Models;
using InventoryService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryManager _inventoryManager;

        public InventoryController(IInventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _inventoryManager.GetAllAsync());
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            var item = await _inventoryManager.GetByProductIdAsync(productId);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InventoryItem item)
        {
            var created = await _inventoryManager.CreateAsync(item);
            return CreatedAtAction(nameof(Get), new { productId = created.ProductId }, created);
        }

        [HttpPut("decrease")]
        public async Task<IActionResult> Decrease([FromBody] DecreaseInventoryDto dto)
        {
            var success = await _inventoryManager.DecreaseInventoryAsync(dto.ProductId, dto.Quantity);
            if (!success)
            {
                return BadRequest("Insufficient inventory or product not found.");
            }
            return Ok();
        }
    }
}