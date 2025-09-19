using AssetManagement.Application.DTOs;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.API.Controllers
{
    /// <summary>
    /// Controlador para gerenciamento de equipamentos com operações CRUD
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentAppService _equipmentAppService;

        /// <summary>
        /// Construtor do controlador de equipamentos
        /// </summary>
        /// <param name="equipmentAppService">Serviço de aplicação para operações com equipamentos</param>
        public EquipmentController(IEquipmentAppService equipmentAppService)
        {
            _equipmentAppService = equipmentAppService;
        }

        /// <summary>
        /// Obtém todos os equipamentos cadastrados
        /// </summary>
        /// <returns>Lista de equipamentos</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipments = await _equipmentAppService.GetAllAsync();
            return Ok(equipments);
        }

        /// <summary>
        /// Obtém um equipamento específico pelo ID
        /// </summary>
        /// <param name="id">ID do equipamento</param>
        /// <returns>Dados do equipamento ou NotFound</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var equipment = await _equipmentAppService.GetByIdAsync(id);
                return Ok(equipment);
            }
            catch (EquipmentNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Cria um novo equipamento
        /// </summary>
        /// <param name="dto">Dados para criação do equipamento</param>
        /// <returns>ID do equipamento criado ou BadRequest em caso de erro</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEquipmentDto dto)
        {
            try
            {
                var equipmentId = await _equipmentAppService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = equipmentId }, new { id = equipmentId });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um equipamento existente
        /// </summary>
        /// <param name="id">ID do equipamento a ser atualizado</param>
        /// <param name="dto">Dados atualizados do equipamento</param>
        /// <returns>NoContent ou NotFound</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEquipmentDto dto)
        {
            try
            {
                await _equipmentAppService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (EquipmentNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Exclui um equipamento
        /// </summary>
        /// <param name="id">ID do equipamento a ser excluído</param>
        /// <returns>NoContent ou NotFound</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _equipmentAppService.DeleteAsync(id);
                return NoContent();
            }
            catch (EquipmentNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
