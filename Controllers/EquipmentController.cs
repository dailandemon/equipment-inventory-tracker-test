using EquipmentInventoryTracker.Data;
using EquipmentInventoryTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EquipmentInventoryTracker.Dtos;
using Microsoft.AspNetCore.Authorization;


namespace EquipmentInventoryTracker.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetAll()
        {
            return await _context.Equipments.Include(e => e.Category).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> Get(int id)
        {
            var equipment = await _context.Equipments.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
            if (equipment == null)
                return NotFound();

            return equipment;
        }

        [HttpPost]
        public async Task<ActionResult<Equipment>> Create(EquipmentDto dto)
        {
            var category = await _context.EquipmentCategories.FindAsync(dto.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid CategoryId.");
            }

            var equipment = new Equipment
            {
                Name = dto.Name,
                Status = dto.Status,
                CategoryId = dto.CategoryId,
                SerialNumber = dto.SerialNumber,
                Category = category
            };



            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = equipment.Id }, equipment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EquipmentDto dto)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
                return NotFound();

            equipment.Name = dto.Name;
            equipment.Status = dto.Status;
            equipment.CategoryId = dto.CategoryId;
            equipment.SerialNumber = dto.SerialNumber;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
                return NotFound();

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetByCategory(int categoryId)
        {
            return await _context.Equipments
                .Where(e => e.CategoryId == categoryId)
                .Include(e => e.Category)
                .ToListAsync();
        }


        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetByStatus(string status)
        {
            return await _context.Equipments
                .Where(e => e.Status.ToLower() == status.ToLower())
                .Include(e => e.Category)
                .ToListAsync();
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Equipment>>> SearchByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length <= 4) //min 4 characters for search
            {
                return BadRequest("Search term must be at least 4 characters.");
            }

            var matches = await _context.Equipments
                .Include(e => e.Category)
                .Where(e => EF.Functions.Like(e.Name, $"%{name}%"))
                .ToListAsync();

            return Ok(matches);
        }

        [HttpGet("search-by-category")]
        public async Task<ActionResult<IEnumerable<Equipment>>> SearchByCategoryName([FromQuery] string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return BadRequest("Category name is required.");
            }

            var equipmentInCategory = await _context.Equipments
                .Include(e => e.Category)
                .Where(e => e.Category.Name.ToLower() == category.ToLower())
                .ToListAsync();

            if (!equipmentInCategory.Any())
            {
                return NotFound($"No equipment found in category '{category}'.");
            }

            return Ok(equipmentInCategory);
        }
    }
}