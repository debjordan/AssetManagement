using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDefeitoRepository
{
    Task<Defeito> GetDefeitoByIdAsync(Guid id);
    Task<IEnumerable<Defeito>> GetAllDefeitosAsync();
    Task AddDefeitoAsync(Defeito defeito);
    Task UpdateDefeitoAsync(Defeito defeito);
    Task DeleteDefeitoAsync(Guid id);
}
