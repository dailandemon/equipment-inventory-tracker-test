//data transfer object, for decoupling the API from the database model

namespace EquipmentInventoryTracker.Dtos
{
    public class EquipmentDto
    {
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}