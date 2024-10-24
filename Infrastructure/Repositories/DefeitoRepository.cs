using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class DefeitoRepository : IDefeitoRepository
{
    private readonly DbContext _context;

    public DefeitoRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<Defeito> GetDefeitoByIdAsync(Guid id)
    {
        return await _context.Set<Defeito>().FindAsync(id);
    }

    public async Task<IEnumerable<Defeito>> GetAllDefeitosAsync()
    {
        return await _context.Set<Defeito>().ToListAsync();
    }

    public async Task AddDefeitoAsync(Defeito defeito)
    {
        await _context.Set<Defeito>().AddAsync(defeito);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDefeitoAsync(Defeito defeito)
    {
        _context.Set<Defeito>().Update(defeito);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDefeitoAsync(Guid id)
    {
        var defeito = await GetDefeitoByIdAsync(id);
        if (defeito != null)
        {
            _context.Set<Defeito>().Remove(defeito);
            await _context.SaveChangesAsync();
        }
    }
}
