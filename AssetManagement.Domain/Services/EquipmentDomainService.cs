using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Repositories;
using AssetManagement.Domain.ValueObjects;

namespace AssetManagement.Domain.Services
{
    public class EquipmentDomainService : IEquipmentDomainService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentDomainService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<Equipment> CreateEquipmentAsync(string name, SerialNumber serialNumber, string model, DateTime purchaseDate)
        {
            await ValidateSerialNumberUniquenessAsync(serialNumber.Value);

            return new Equipment(name, serialNumber, model, purchaseDate);
        }

        public async Task ValidateSerialNumberUniquenessAsync(string serialNumber)
        {
            var exists = await _equipmentRepository.ExistsBySerialNumberAsync(serialNumber);
            if (exists)
            {
                throw new InvalidOperationException($"Equipment with serial number '{serialNumber}' already exists.");
            }
        }
    }
}
