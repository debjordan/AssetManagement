using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Repositories
{
    public interface IEquipmentRepository
    {
        Task<Equipment?> GetByIdAsync(Guid id);
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment?> GetBySerialNumberAsync(string serialNumber);
        Task AddAsync(Equipment equipment);
        Task UpdateAsync(Equipment equipment);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsBySerialNumberAsync(string serialNumber);
    }
}
