using AssetManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces
{
    public interface IEquipmentAppRepository
    {
        Task<Equipment> GetByIdAsync(Guid id);
        Task<List<Equipment>> GetAllAsync();
        Task AddAsync(Equipment equipment);
        Task UpdateAsync(Equipment equipment);
        Task DeleteAsync(Guid id);
    }
}
