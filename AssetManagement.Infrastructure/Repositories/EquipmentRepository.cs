using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AssetManagementDbContext _context;

        public EquipmentRepository(AssetManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Equipment equipment)
        {
            await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null) return;

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Equipment>> GetAllAsync()
        {
            return await _context.Equipments.ToListAsync();
        }

        public async Task<Equipment> GetByIdAsync(Guid id)
        {
            return await _context.Equipments.FindAsync(id);
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            await _context.SaveChangesAsync();
        }
    }
}
