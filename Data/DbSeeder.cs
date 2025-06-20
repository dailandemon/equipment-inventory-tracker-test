using EquipmentInventoryTracker.Models;

namespace EquipmentInventoryTracker.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.EquipmentCategories.Any())
            {
                var categories = new List<EquipmentCategory>
                {
                    new() { Name = "Ammunition" },
                    new() { Name = "Military Supplies" },
                    new() { Name = "Communications" },
                    new() { Name = "Medical" },
                    new() { Name = "Computers" }
                };

                context.EquipmentCategories.AddRange(categories);
                context.SaveChanges();

                var equipments = new List<Equipment>
                {
                    new() {
                        Name = "5.56mm NATO Rounds",
                        Status = "In Stock",
                        SerialNumber = "AMMO-556-001",
                        CategoryId = categories[0].Id,
                        Category = categories[0]
                    },
                    new() {
                        Name = "Tactical Vest Gen III",
                        Status = "Issued",
                        SerialNumber = "SUP-TACT-009",
                        CategoryId = categories[1].Id,
                        Category = categories[1]
                    },
                    new() {
                        Name = "Encrypted Radio PRC-152",
                        Status = "Maintenance",
                        SerialNumber = "COM-PRC152-104",
                        CategoryId = categories[2].Id,
                        Category = categories[2]
                    },
                    new() {
                        Name = "First Aid Field Kit",
                        Status = "In Stock",
                        SerialNumber = "MED-FAK-221",
                        CategoryId = categories[3].Id,
                        Category = categories[3]
                    },
                    new() {
                        Name = "Rugged Laptop (Panasonic Toughbook)",
                        Status = "In Use",
                        SerialNumber = "COMP-TOUGH-999",
                        CategoryId = categories[4].Id,
                        Category = categories[4]
                    },
                    new() {
                        Name = "9mm Sidearm Ammo",
                        Status = "In Stock",
                        SerialNumber = "AMMO-9MM-005",
                        CategoryId = categories[0].Id,
                        Category = categories[0]
                    },
                    new() {
                        Name = "MRE Pack - Beef Stew",
                        Status = "Expired",
                        SerialNumber = "SUP-MRE-882",
                        CategoryId = categories[1].Id,
                        Category = categories[1]
                    },
                    new() {
                        Name = "Satellite Phone",
                        Status = "Available",
                        SerialNumber = "COM-SAT-876",
                        CategoryId = categories[2].Id,
                        Category = categories[2]
                    },
                    new() {
                        Name = "Surgical Kit",
                        Status = "Sterile",
                        SerialNumber = "MED-SURG-101",
                        CategoryId = categories[3].Id,
                        Category = categories[3]
                    },
                    new() {
                        Name = "Portable Drone Control Terminal",
                        Status = "In Use",
                        SerialNumber = "COMP-DRONE-331",
                        CategoryId = categories[4].Id,
                        Category = categories[4]
                    },
                };

                context.Equipments.AddRange(equipments);
                context.SaveChanges();
            }
        }
    }
}
