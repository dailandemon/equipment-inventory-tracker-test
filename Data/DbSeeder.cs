using EquipmentInventoryTracker.Models;

namespace EquipmentInventoryTracker.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.EquipmentCategories.Any())
            {
                context.EquipmentCategories.AddRange(
                    new EquipmentCategory { Name = "Ammunition" },
                    new EquipmentCategory { Name = "Military Supplies" },
                    new EquipmentCategory { Name = "Communications" },
                    new EquipmentCategory { Name = "Medical" },
                    new EquipmentCategory { Name = "Computers" }
                );
                context.SaveChanges();
            }
        }
    }
}
