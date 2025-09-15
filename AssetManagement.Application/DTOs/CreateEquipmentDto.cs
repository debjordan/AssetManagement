namespace AssetManagement.Application.DTOs
{
    public class CreateEquipmentDto
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
