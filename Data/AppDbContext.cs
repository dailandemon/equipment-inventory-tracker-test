using EquipmentInventoryTracker.Models;
using Microsoft.EntityFrameworkCore;


namespace EquipmentInventoryTracker.Data
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentCategory> EquipmentCategories { get; set; }
    }
}