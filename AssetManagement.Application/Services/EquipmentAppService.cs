using AssetManagement.Application.DTOs;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Exceptions;
using AssetManagement.Domain.Repositories;
using AssetManagement.Domain.ValueObjects;

namespace AssetManagement.Application.Services
{
    public class EquipmentAppService : IEquipmentAppService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentDomainService _equipmentDomainService;

        public EquipmentAppService(
            IEquipmentRepository equipmentRepository,
            IEquipmentDomainService equipmentDomainService)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentDomainService = equipmentDomainService;
        }

        public async Task<IEnumerable<EquipmentDto>> GetAllAsync()
        {
            var equipments = await _equipmentRepository.GetAllAsync();
            return equipments.Select(e => new EquipmentDto
            {
                Id = e.Id,
                Name = e.Name,
                SerialNumber = e.SerialNumber.Value,
                Model = e.Model,
                PurchaseDate = e.PurchaseDate,
                Status = e.Status
            });
        }

        public async Task<EquipmentDto> GetByIdAsync(Guid id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment == null)
                throw new EquipmentNotFoundException(id);

            return new EquipmentDto
            {
                Id = equipment.Id,
                Name = equipment.Name,
                SerialNumber = equipment.SerialNumber.Value,
                Model = equipment.Model,
                PurchaseDate = equipment.PurchaseDate,
                Status = equipment.Status
            };
        }

        public async Task<Guid> CreateAsync(CreateEquipmentDto dto)
        {
            var serialNumber = new SerialNumber(dto.SerialNumber);
            var equipment = await _equipmentDomainService.CreateEquipmentAsync(
                dto.Name, serialNumber, dto.Model, dto.PurchaseDate);

            await _equipmentRepository.AddAsync(equipment);
            return equipment.Id;
        }

        public async Task UpdateAsync(Guid id, UpdateEquipmentDto dto)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment == null)
                throw new EquipmentNotFoundException(id);

            equipment.Update(dto.Name, dto.Model, dto.Status);
            await _equipmentRepository.UpdateAsync(equipment);
        }

        public async Task DeleteAsync(Guid id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment == null)
                throw new EquipmentNotFoundException(id);

            await _equipmentRepository.DeleteAsync(id);
        }
    }
}
