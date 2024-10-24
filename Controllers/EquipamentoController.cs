using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class EquipamentosController : ControllerBase
{
    private readonly IEquipamentoRepository _equipamentoRepository;

    public EquipamentosController(IEquipamentoRepository equipamentoRepository)
    {
        _equipamentoRepository = equipamentoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipamento>>> GetEquipamentos()
    {
        var equipamentos = await _equipamentoRepository.GetAllEquipamentosAsync();
        return Ok(equipamentos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Equipamento>> GetEquipamento(Guid id)
    {
        var equipamento = await _equipamentoRepository.GetEquipamentoByIdAsync(id);
        if (equipamento == null)
        {
            return NotFound();
        }
        return Ok(equipamento);
    }

    [HttpPost]
    public async Task<ActionResult> CreateEquipamento([FromBody] Equipamento equipamento)
    {
        await _equipamentoRepository.AddEquipamentoAsync(equipamento);
        return CreatedAtAction(nameof(GetEquipamento), new { id = equipamento.Id }, equipamento);
    }
}
