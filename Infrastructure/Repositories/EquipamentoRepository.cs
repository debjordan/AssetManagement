using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EquipamentoRepository : IEquipamentoRepository
{
    private readonly DataContext _context;

    public EquipamentoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Equipamento> GetEquipamentoByIdAsync(Guid id)
    {
        return await _context.Equipamentos.FindAsync(id);
    }

    public async Task<IEnumerable<Equipamento>> GetAllEquipamentosAsync()
    {
        return await _context.Equipamentos.ToListAsync();
    }

    public async Task AddEquipamentoAsync(Equipamento equipamento)
    {
        await _context.Equipamentos.AddAsync(equipamento);
        await _context.SaveChangesAsync();
    }
}
