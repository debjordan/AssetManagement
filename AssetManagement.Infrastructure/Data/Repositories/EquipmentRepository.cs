using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Repositories;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Data.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Equipment> GetByIdAsync(Guid id)
        {
            return await _context.Equipments
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments
                .Where(e => e.Status != "Deleted")
                .ToListAsync();
        }

        public async Task AddAsync(Equipment equipment)
        {
            await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var equipment = await GetByIdAsync(id);
            if (equipment != null)
            {
                equipment.Deactivate();
                await UpdateAsync(equipment);
            }
        }

        public async Task<Equipment> GetBySerialNumberAsync(string serialNumber)
        {
            return await _context.Equipments
                .FirstOrDefaultAsync(e => e.SerialNumber.Value == serialNumber);
        }
    }
}
