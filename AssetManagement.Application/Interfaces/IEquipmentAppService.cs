using AssetManagement.Application.DTOs;

namespace AssetManagement.Application.Interfaces
{
    public interface IEquipmentAppService
    {
        Task<IEnumerable<EquipmentDto>> GetAllAsync();
        Task<EquipmentDto> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(CreateEquipmentDto dto);
        Task UpdateAsync(Guid id, UpdateEquipmentDto dto);
        Task DeleteAsync(Guid id);
    }
}
