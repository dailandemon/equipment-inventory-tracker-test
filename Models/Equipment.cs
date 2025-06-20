
namespace EquipmentInventoryTracker.Models
{


    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public required string SerialNumber { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime LastMaintenanceDate { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public int CategoryId { get; set; }
        public required EquipmentCategory Category { get; set; }
    }
}