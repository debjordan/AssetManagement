using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Repositories;
using AssetManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AssetManagementDbContext _context;

        public EquipmentRepository(AssetManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Equipment?> GetByIdAsync(Guid id)
        {
            return await _context.Equipments.FindAsync(id);
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments.ToListAsync();
        }

        public async Task<Equipment?> GetBySerialNumberAsync(string serialNumber)
        {
            return await _context.Equipments
                .FirstOrDefaultAsync(e => e.SerialNumber.Value == serialNumber);
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
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsBySerialNumberAsync(string serialNumber)
        {
            return await _context.Equipments
                .AnyAsync(e => e.SerialNumber.Value == serialNumber);
        }
    }
}
