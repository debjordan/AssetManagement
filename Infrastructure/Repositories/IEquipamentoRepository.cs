using AssetManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEquipamentoRepository
{
    Task<Equipamento> GetEquipamentoByIdAsync(Guid id);
    Task<IEnumerable<Equipamento>> GetAllEquipamentosAsync();
    Task AddEquipamentoAsync(Equipamento equipamento);
}
