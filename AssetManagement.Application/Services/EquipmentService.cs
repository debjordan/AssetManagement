using AssetManagement.Application.DTOs;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Services
{
    public class EquipmentService
    {
        private readonly IEquipmentRepository _repository;

        public EquipmentService(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EquipmentDto>> GetAllAsync()
        {
            var equipments = await _repository.GetAllAsync();
            return equipments.Select(e => new EquipmentDto
            {
                Id = e.Id,
                Name = e.Name,
                Code = e.Code,
                Description = e.Description
            }).ToList();
        }

        public async Task<EquipmentDto> GetByIdAsync(Guid id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e == null) return null;

            return new EquipmentDto
            {
                Id = e.Id,
                Name = e.Name,
                Code = e.Code,
                Description = e.Description
            };
        }

        public async Task AddAsync(EquipmentDto dto)
        {
            var equipment = new Equipment(dto.Name, dto.Code, dto.Description);
            await _repository.AddAsync(equipment);
        }

        public async Task UpdateAsync(Guid id, EquipmentDto dto)
        {
            var equipment = await _repository.GetByIdAsync(id);
            if (equipment == null) throw new Exception("Equipment not found");

            equipment.Update(dto.Name, dto.Code, dto.Description);
            await _repository.UpdateAsync(equipment);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
