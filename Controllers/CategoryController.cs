using EquipmentInventoryTracker.Data;
using EquipmentInventoryTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventoryTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentCategory>>> GetAll()
        {
            return await _context.EquipmentCategories.Include(c => c.Equipments).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<EquipmentCategory>> Create(EquipmentCategory category)
        {
            _context.EquipmentCategories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = category.Id }, category);
        }
    }
}
