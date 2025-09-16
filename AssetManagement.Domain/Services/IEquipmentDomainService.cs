using AssetManagement.Domain.Entities;
using AssetManagement.Domain.ValueObjects;

namespace AssetManagement.Domain.Services
{
    public interface IEquipmentDomainService
    {
        Task<Equipment> CreateEquipmentAsync(string name, SerialNumber serialNumber, string model, DateTime purchaseDate);
        Task ValidateSerialNumberUniquenessAsync(string serialNumber);
    }
}
