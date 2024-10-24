using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Domain.Entities;

public interface ICategoriaDefeitoRepository
{
    Task<CategoriaDefeito> GetCategoriaByIdAsync(Guid id);
    Task<IEnumerable<CategoriaDefeito>> GetAllCategoriasAsync();
}
