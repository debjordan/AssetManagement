using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Application.DTOs
{
    public class EquipmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateEquipmentDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 20 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Serial number is required")]
        [MinLength(5, ErrorMessage = "Serial number must be at least 5 characters")]
        [MaxLength(50, ErrorMessage = "Serial number cannot exceed 50 characters")]
        public string SerialNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required")]
        [MaxLength(100, ErrorMessage = "Model cannot exceed 100 characters")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "Purchase date is required")]
        public DateTime PurchaseDate { get; set; }
    }

    public class UpdateEquipmentDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 20 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required")]
        [MaxLength(100, ErrorMessage = "Model cannot exceed 10 characters")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        [MaxLength(50, ErrorMessage = "Status cannot exceed 50 characters")]
        public string Status { get; set; } = string.Empty;
    }
}
