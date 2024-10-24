using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

// Principio da responsabilidade única: Manter a lógica de acesso a dados das regras de negócio.
public class CategoriaDefeitoRepository : ICategoriaDefeitoRepository
{
    private readonly DbContext _context;

    public CategoriaDefeitoRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<CategoriaDefeito> GetCategoriaByIdAsync(Guid id)
    {
        return await _context.Set<CategoriaDefeito>().FindAsync(id);
    }

    public async Task<IEnumerable<CategoriaDefeito>> GetAllCategoriasAsync()
    {
        return await _context.Set<CategoriaDefeito>().ToListAsync();
    }

    Task<CategoriaDefeito> ICategoriaDefeitoRepository.GetCategoriaByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<CategoriaDefeito>> ICategoriaDefeitoRepository.GetAllCategoriasAsync()
    {
        throw new NotImplementedException();
    }
}
